// <copyright file="CurrencyRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CryptoTrading.Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// currency repo.
    /// </summary>
    public class CurrencyRepository : DBRepository<Currency>, ICurrencyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepository"/> class.
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public CurrencyRepository(CTDDataBase dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Get one currency.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public override Currency GetOne(string shortName)
        {
            return this.GetAll().SingleOrDefault(x => x.ShortName == shortName);
        }
    }
}
