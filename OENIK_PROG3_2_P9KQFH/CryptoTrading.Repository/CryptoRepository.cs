// <copyright file="CryptoRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CryptoTrading.Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// Crypto repository.
    /// </summary>
    public class CryptoRepository : DBRepository<Crypto>, ICryptoRepository
    {
        private IMemberRepository MemberRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoRepository"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="dbContext">db.</param>
        /// <param name="memberRepository">member repo.</param>
        public CryptoRepository(CTDDataBase dbContext, IMemberRepository memberRepository)
            : base(dbContext)
        {
            this.MemberRepository = memberRepository;
        }

        /// <summary>
        /// Add a new crypto.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        public void AddNewCrypto(string name, string shortName)
        {
            Random r = new Random();

            Crypto newCrypto = new Crypto()
            {
                Name = name,
                ShortName = shortName,
                Value = r.Next(0, 500),
                Popularity = r.Next(0, 100),
                Rank = r.Next(3, 5),
                CryptoID = r.Next(3, 10000),
            };
            newCrypto.ValueToOneUSD = newCrypto.Value / 300;

            this.Add(newCrypto);
        }

        /// <summary>
        /// Double or quits my money.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <param name="bTCValue"></param>
        /// <param name="otherValue"></param>
        /// <returns>asd.</returns>
        public double DoubleOrQuits(string username, string cryptoShortName, string answer, double bTCValue, double otherValue)
        {
            Crypto crypto = this.GetOne(cryptoShortName);
            Member member = this.MemberRepository.GetOne(username);

            double ret = -1;

            double oldPrice = crypto.Value;
            if (bTCValue == 0 && otherValue == 0)
            {
                Random r = new Random();
                crypto.Value = crypto.ShortName != "BTC" ? r.Next(0, 2001) : r.Next(0, 20001);
            }
            else
            {
                crypto.Value = crypto.ShortName != "BTC" ? otherValue : bTCValue;
            }

            double newPrice = crypto.Value;

            if (member.UserName == username)
            {
                double money = member.Money;

                if (oldPrice > newPrice && answer.ToLower() == "fall")
                {
                    member.Money = money * 2;
                }
                else if (oldPrice < newPrice && answer.ToLower() == "grow")
                {
                    member.Money = money * 2;
                }
                else
                {
                    member.Money = 0;
                }

                ret = member.Money;
            }

            return ret;
        }

        /// <summary>
        /// Get one.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public override Crypto GetOne(string shortName)
        {
            return this.GetAll().SingleOrDefault(x => x.ShortName == shortName);
        }

        /// <summary>
        /// Possible to delet crypto.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public bool PossibleDelet(string shortName)
        {
            bool possible = false;
            List<Crypto> cryptos = this.GetAll().Where(x => x.ShortName == shortName).ToList();
            foreach (var item in cryptos)
            {
                if (item.ShortName == shortName)
                {
                    this.Delete(item);
                    possible = true;
                }
                else if (possible == false)
                {
                    possible = false;
                }
            }

            return possible;
        }

        /// <inheritdoc/>
        public void Refresh()
        {
            List<Crypto> cryptos = this.GetAll().ToList();
            foreach (var entity in cryptos)
            {
                Random r = new Random();
                entity.Value = entity.ShortName != "BTC" ? r.Next(0, 2001) : r.Next(0, 20001);

                this.Update(entity);
            }
        }

        /// <summary>
        /// Sell bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double SellBTC()
        {
            List<double> btcPrice = this.GetAll().Where(x => x.Name == "Bitcoin").Select(y => y.Value).ToList();
            List<double> btc = this.MemberRepository.GetAll().Select(x => x.BTCWallet).ToList();

            double money = btcPrice.Max() * btc.Max();

            List<Member> member = this.MemberRepository.GetAll().ToList();
            foreach (var item in member)
            {
                item.BTCWallet = 0;
                item.Money = money;
                this.MemberRepository.Update(item);
            }

            return Math.Round(money, 3);
        }

        /// <summary>
        /// Buy bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double BuyBTC()
        {
            List<double> btcPrice = this.GetAll().Where(x => x.Name == "Bitcoin").Select(y => y.Value).ToList();
            List<double> money = this.MemberRepository.GetAll().Select(x => x.Money).ToList();

            double btcDb = money.Max() / btcPrice.Max();

            List<Member> member = this.MemberRepository.GetAll().ToList();
            foreach (var item in member)
            {
                item.BTCWallet = btcDb;
                item.Money = 0;
                this.MemberRepository.Update(item);
            }

            return Math.Round(btcDb, 3);
        }
    }
}
