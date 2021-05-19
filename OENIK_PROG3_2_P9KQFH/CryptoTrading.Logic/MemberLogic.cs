// <copyright file="MemberLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CryptoTrading.Repository;
    using Models;

    /// <summary>
    /// member logic.
    /// </summary>
    public class MemberLogic : IMemberLogic
    {
        private IMemberRepository memberRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberLogic"/> class.
        /// ctor.
        /// </summary>
        /// <param name="memberRepo"></param>
        public MemberLogic(IMemberRepository memberRepo)
        {
            this.memberRepo = memberRepo;
        }

        /// <summary>
        /// add member to database.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Member entity)
        {
            this.memberRepo.Add(entity);
        }

        /// <summary>
        /// read a member from database.
        /// </summary>
        /// <param name="entity"></param>
        public void Read(Member entity)
        {
            this.memberRepo.GetAll();
        }

        /// <summary>
        /// remove a member from database.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(Member entity)
        {
            this.memberRepo.Delete(entity);
        }

        /// <summary>
        /// update member.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Member entity)
        {
            this.memberRepo.Update(entity);
        }

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Register(string userName, string password)
        {
            Member member = new Member()
            {
                UserName = userName,
                Password = password,
            };
            this.memberRepo.Add(member);
        }

        /// <summary>
        /// All name as string.
        /// </summary>
        /// <returns>asd.</returns>
        public string GetAllNameAsString()
        {
            List<string> memberName = this.memberRepo.GetAll().Select(x => x.FullName).ToList();
            return string.Join(", ", memberName);
        }

        /// <summary>
        /// not work yet.
        /// </summary>
        public void Buy()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// not work yet.
        /// </summary>
        public void Sell()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// actual money.
        /// </summary>
        /// <returns>asd.</returns>
        public List<double> MyMoney()
        {
            List<double> money = this.memberRepo.GetAll().Select(x => x.Money).ToList();
            return money;
        }

        /// <summary>
        /// return btc object.
        /// </summary>
        /// <returns>asd.</returns>
        public List<double> Btc()
        {
            List<double> btc = this.memberRepo.GetAll().Select(x => x.BTCWallet).ToList();
            return btc;
        }

        /// <summary>
        /// add a new member to database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="birthYear"></param>
        /// <param name="money"></param>
        public void AddNew(string userName, string password, string fullName, int birthYear, double money)
        {
            Random r = new Random();

            Member member = new Member()
            {
                UserName = userName,
                Password = password,
                BTCWallet = 0,
                ETHWallet = 0,
                FullName = fullName,
                BirthYear = birthYear,
                Money = money,
            };

            this.memberRepo.Add(member);
        }

        /// <summary>
        /// delete member from database.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>asd.</returns>
        public bool DeleteMember(string userName)
        {
            bool possible = false;

            Member[] members = this.memberRepo.GetAll().Where(x => x.UserName == userName).ToArray();
            if (members == null)
            {
                return possible;
            }
            else
            {
                for (int i = 0; i < members.Length; i++)
                {
                    this.Remove(members[i]);
                }

                return possible = true;
            }
        }

        /// <summary>
        /// deposite money.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="username"></param>
        public void Deposite(double money, string username)
        {
            List<Member> user = this.memberRepo.GetAll().Where(x => x.UserName == username).ToList();

            foreach (var item in user)
            {
                double m = item.Money;
                m += money;
                item.Money = m;

                this.Update(item);
            }
        }
    }
}
