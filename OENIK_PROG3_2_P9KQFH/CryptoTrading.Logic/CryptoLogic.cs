// <copyright file="CryptoLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CryptoTrading.Repository;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Models;

    /// <summary>
    /// Crypto logic set.
    /// </summary>
    public class CryptoLogic : ICryptoLogic
    {
        private ICryptoRepository cryptoRepo;
        private IMemberRepository memberRepo;

        /// <summary>
        /// Gets or sets bITCOIN value prop.
        /// </summary>
        public double BTCValue { get; set; }

        /// <summary>
        /// Gets or sets other crypto value prop.
        /// </summary>
        public double OtherValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoLogic"/> class.
        /// </summary>
        /// <param name="cryptoRepo"></param>
        public CryptoLogic(ICryptoRepository cryptoRepo)
        {
            this.cryptoRepo = cryptoRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoLogic"/> class.
        /// </summary>
        /// <param name="cryptoRepo"></param>
        /// <param name="memberRepository"></param>
        public CryptoLogic(CryptoRepository cryptoRepo, MemberRepository memberRepository)
        {
            this.cryptoRepo = cryptoRepo;
            this.memberRepo = memberRepository;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoLogic"/> class.
        /// </summary>
        public CryptoLogic()
        {
            Data.CTDDataBase dbContext = new Data.CTDDataBase();
            this.memberRepo = new MemberRepository(dbContext);
            this.cryptoRepo = new CryptoRepository(dbContext, this.memberRepo);
        }

        /// <summary>
        /// Get one crypto.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public Crypto GetOne(string shortName)
        {
            return this.cryptoRepo.GetOne(shortName);
        }

        /// <summary>
        /// Add new crypto.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Crypto entity)
        {
            this.cryptoRepo.Add(entity);
        }

        /// <summary>
        /// Remove one crypto.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(Crypto entity)
        {
            this.cryptoRepo.Delete(entity);
        }

        /// <summary>
        /// Update current crypto.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Crypto entity)
        {
            Random r = new Random();
            entity.Value = entity.ShortName != "BTC" ? r.Next(0, 2001) : r.Next(0, 20001);

            this.cryptoRepo.Update(entity);
        }

        /// <summary>
        /// Get all crypto.
        /// </summary>
        /// <param name="entity"></param>
        public void Read(Crypto entity)
        {
            this.cryptoRepo.GetAll();
        }

        /// <summary>
        /// Get all crypto.
        /// </summary>
        /// <returns>asd.</returns>
        public IList<Crypto> ReadAll()
        {
            return this.cryptoRepo.GetAll().ToList();
        }

        /// <summary>
        /// Get all crypto name as string.
        /// </summary>
        /// <returns>asd.</returns>
        public string GetAllNameAsString()
        {
            List<string> cryptoNames = this.cryptoRepo.GetAll().Select(x => x.Name).ToList();
            return string.Join(", ", cryptoNames);
        }

        /// <summary>
        /// Get all crypto price in USD.
        /// </summary>
        /// <returns>asd.</returns>
        public string[] CryptoPrice()
        {
            List<Crypto> cryptosValue = this.cryptoRepo.GetAll().ToList();

            string[] res = new string[cryptosValue.Count];

            int i = 0;

            foreach (var item in cryptosValue)
            {
                string name = item.Name;
                double value = item.Value;
                res[i] = $"{name} value is: {value}";
                i++;
            }

            return res;
        }

        /// <summary>
        /// Sell bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double SellBTC()
        {
            return this.cryptoRepo.SellBTC();
        }

        /// <summary>
        /// Buy bitcoin async.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<List<double>> SellBTCAsync()
        {
            Task<List<double>> task = new Task<List<double>>(() =>
            {
                double money = this.cryptoRepo.SellBTC();
                Thread.Sleep(500);

                List<double> list = new List<double>();
                list.Add(money);

                return list;
            });
            return task;
        }

        /// <summary>
        /// Buy bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double BuyBTC()
        {
            return this.cryptoRepo.BuyBTC();
        }

        /// <summary>
        /// Buy bitcoin async.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<List<double>> BuyBTCAsync()
        {
            Task<List<double>> task = new Task<List<double>>(() =>
            {
                double money = this.cryptoRepo.BuyBTC();
                Thread.Sleep(500);

                List<double> list = new List<double>();
                list.Add(money);

                return list;
            });
            return task;
        }

        /// <summary>
        /// Add a new cypto.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        public void AddNewCrypto(string name, string shortName)
        {
            this.cryptoRepo.AddNewCrypto(name, shortName);
        }

        /// <summary>
        /// Refresh the crypto value.
        /// </summary>
        public void Refresh()
        {
            this.cryptoRepo.Refresh();
        }

        /// <summary>
        /// Possible to delet crypto.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public bool PossibleDelet(string shortName)
        {
            return this.cryptoRepo.PossibleDelet(shortName);
        }

        /// <summary>
        /// Double or quits my money.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <returns>asd.</returns>
        public double DoubleOrQuits(string username, string cryptoShortName, string answer)
        {
            if (this.BTCValue == 0 && this.OtherValue == 0)
            {
                return this.cryptoRepo.DoubleOrQuits(username, cryptoShortName, answer, 0, 0);
            }
            else
            {
                return this.cryptoRepo.DoubleOrQuits(username, cryptoShortName, answer, this.BTCValue, this.OtherValue);
            }
        }

        /// <summary>
        /// TASK Double or quits my money.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <returns>asd.</returns>
        public Task<List<double>> DoubleOrQuitsDoSomethingAsync(string username, string cryptoShortName, string answer)
        {
            Task<List<double>> task = new Task<List<double>>(() =>
            {
                double money = this.cryptoRepo.DoubleOrQuits(username, cryptoShortName, answer, 0, 0);
                Thread.Sleep(500);

                List<double> list = new List<double>();
                list.Add(money);

                return list;
            });
            return task;
        }

        /// <summary>
        /// Get All Name As String Do Something Async.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<string> GetAllNameAsStringDoSomethingAsync()
        {
            Task<string> task = new Task<string>(() =>
            {
                string test = " ";

                Thread.Sleep(500);

                List<string> cryptos = this.cryptoRepo.GetAll().Select(x => x.Name).ToList();
                test = string.Join(", ", cryptos);

                return test;
            });

            return task;
        }
    }
}
