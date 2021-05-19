// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base logic interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILogic<T>
    {
        /// <summary>
        /// Add to database.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// remove from database.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// update something from database.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// read something from database.
        /// </summary>
        /// <param name="entity"></param>
        void Read(T entity);

        /// <summary>
        /// get something all name as string.
        /// </summary>
        /// <returns>asd.</returns>
        string GetAllNameAsString();
    }
}
