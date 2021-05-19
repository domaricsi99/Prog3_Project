// <copyright file="ICryptoLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Interface crypto logic.
    /// </summary>
    public interface ICryptoLogic // : ICryptooLogic // : ILogic<Crypto>
    {
        /// <summary>
        /// Get crypto price.
        /// </summary>
        /// <returns>asd.</returns>
        public string[] CryptoPrice();

        /// <summary>
        /// Sell bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        double SellBTC();

        /// <summary>
        /// Buy bitcoin.
        /// </summary>
        /// <returns>asd.</returns>
        double BuyBTC();

        /// <summary>
        /// Add new crypto.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        void AddNewCrypto(string name, string shortName);

        /// <summary>
        /// Refresh all crypto price.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Possible to delet a crypto.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        bool PossibleDelet(string shortName);

        /// <summary>
        /// Double or quits trade.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <returns>asd.</returns>
        double DoubleOrQuits(string username, string cryptoShortName, string answer);

        /// <summary>
        /// Get All Name As String Do Something Async.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<string> GetAllNameAsStringDoSomethingAsync();

        /// <summary>
        /// TASK Double or quits my money.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptoShortName"></param>
        /// <param name="answer"></param>
        /// <returns>asd.</returns>
        public Task<List<double>> DoubleOrQuitsDoSomethingAsync(string username, string cryptoShortName, string answer);

        /// <summary>
        /// Buy bitcoin ASYNC.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<List<double>> BuyBTCAsync();

        /// <summary>
        /// Buy bitcoin async.
        /// </summary>
        /// <returns>asd.</returns>
        public Task<List<double>> SellBTCAsync();

        /// <summary>
        /// Read all crypto.
        /// </summary>
        /// <returns>asd.</returns>
        public IList<Crypto> ReadAll();

        /// <summary>
        /// Add to database.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Add(Crypto entity);

        /// <summary>
        /// remove from database.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Remove(Crypto entity);

        /// <summary>
        /// update something from database.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Update(Crypto entity);

        /// <summary>
        /// read something from database.
        /// </summary>
        /// <param name="entity">entity.</param>
        void Read(Crypto entity);

        /// <summary>
        /// get something all name as string.
        /// </summary>
        /// <returns>asd.</returns>
        string GetAllNameAsString();
    }
}
