// <copyright file="IMemberLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// member logic interface.
    /// </summary>
    public interface IMemberLogic : ILogic<Member>
    {
        /// <summary>
        /// buy crypto or currency.
        /// </summary>
        public void Buy();

        /// <summary>
        /// sell crypto or currency.
        /// </summary>
        public void Sell();

        /// <summary>
        /// Member actual money.
        /// </summary>
        /// <returns>asd.</returns>
        public List<double> MyMoney();

        /// <summary>
        /// btc list.
        /// </summary>
        /// <returns>asd.</returns>
        public List<double> Btc();

        /// <summary>
        /// Add new member to database.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="birthYear"></param>
        /// <param name="money"></param>
        void AddNew(string userName, string password, string fullName, int birthYear, double money);

        /// <summary>
        /// delete member from database.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>asd.</returns>
        public bool DeleteMember(string userName);

        /// <summary>
        /// deposite money.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="username"></param>
        public void Deposite(double money, string username);
    }
}
