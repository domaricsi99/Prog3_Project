// <copyright file="TradeLogic.cs" company="PlaceholderCompany">
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
    /// trade logic.
    /// </summary>
    public class TradeLogic : ILogicTrade
    {
        private TradeRepository tradeRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeLogic"/> class.
        /// ctor.
        /// </summary>
        /// <param name="tradeRepo"></param>
        public TradeLogic(TradeRepository tradeRepo)
        {
            this.tradeRepo = tradeRepo;
        }

        /// <summary>
        /// add.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Trade entity)
        {
            this.tradeRepo.Add(entity);
        }

        /// <summary>
        /// read.
        /// </summary>
        /// <param name="entity"></param>
        public void Read(Trade entity)
        {
            this.tradeRepo.GetAll();
        }

        /// <summary>
        /// remove.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(Trade entity)
        {
            this.tradeRepo.Delete(entity);
        }

        /// <summary>
        /// update.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Trade entity)
        {
            this.tradeRepo.Update(entity);
        }

        /// <summary>
        /// get all name as stgring.
        /// </summary>
        /// <returns>asd.</returns>
        public string GetAllNameAsString()
        {
            List<string> tradeItemNames = this.tradeRepo.GetAll().Select(x => x.TradeItem.Name).ToList();
            return string.Join(", ", tradeItemNames);
        }
    }
}
