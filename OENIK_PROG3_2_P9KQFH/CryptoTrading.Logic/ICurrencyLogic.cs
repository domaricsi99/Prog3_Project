// <copyright file="ICurrencyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    /// <summary>
    /// interface currency logic.
    /// </summary>
    public interface ICurrencyLogic : ILogic<Currency>
    {
        /// <summary>
        /// Add new currency.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        /// <param name="nationality"></param>
        /// <param name="symbol"></param>
        void AddNewOne(string name, string shortName, string nationality, string symbol);

        /// <summary>
        /// Actual currency price.
        /// </summary>
        /// <returns>asd.</returns>
        string[] CurrencyPrice();

        /// <summary>
        /// Delet a currency from database.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        bool DeleteCurrency(string shortName);

        /// <summary>
        /// Refresh the currency value.
        /// </summary>
        /// <param name="currencyLogic"></param>
        public void Refresh(ICurrencyLogic currencyLogic);
    }
}
