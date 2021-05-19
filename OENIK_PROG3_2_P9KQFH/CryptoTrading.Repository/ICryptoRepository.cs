// <copyright file="ICryptoRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// crypto repostory interface.
    /// </summary>
    public interface ICryptoRepository : IRepository<Crypto>
    {
        /// <summary>
        /// add new crypto.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        public void AddNewCrypto(string name, string shortName);

        /// <summary>
        /// possible to delet a crypto.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public bool PossibleDelet(string shortName);

        /// <summary>
        /// double or quits game.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <param name="bTCValue"></param>
        /// <param name="otherValue"></param>
        /// <returns>asd.</returns>
        public double DoubleOrQuits(string username, string cryptoShortName, string answer, double bTCValue, double otherValue);

        /// <summary>
        /// refresh all crypto value.
        /// </summary>
        public void Refresh();

        /// <summary>
        /// sell all bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double SellBTC();

        /// <summary>
        /// buy bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        public double BuyBTC();
    }
}
