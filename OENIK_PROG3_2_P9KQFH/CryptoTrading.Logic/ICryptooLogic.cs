// <copyright file="ICryptooLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// crypto logic interface.
    /// </summary>
    public interface ICryptooLogic
    {
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
