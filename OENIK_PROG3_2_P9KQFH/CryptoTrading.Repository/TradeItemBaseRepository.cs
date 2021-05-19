// <copyright file="TradeItemBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System.Linq;
    using CryptoTrading.Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// trade item base repo.
    /// </summary>
    public class TradeItemBaseRepository : DBRepository<TradeItemBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeItemBaseRepository"/> class.
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public TradeItemBaseRepository(CTDDataBase dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// get one.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public override TradeItemBase GetOne(string shortName)
        {
            return this.GetAll().SingleOrDefault(x => x.ShortName == shortName);
        }
    }
}
