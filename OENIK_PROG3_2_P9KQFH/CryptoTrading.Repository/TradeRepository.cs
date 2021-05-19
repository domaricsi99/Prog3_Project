// <copyright file="TradeRepository.cs" company="PlaceholderCompany">
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
    /// trade repo.
    /// </summary>
    public class TradeRepository : DBRepository<Trade>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeRepository"/> class.
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public TradeRepository(CTDDataBase dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// get one.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public override Trade GetOne(string shortName)
        {
            return this.GetAll().SingleOrDefault(x => x.MemberID == int.Parse(shortName));
        }
    }
}
