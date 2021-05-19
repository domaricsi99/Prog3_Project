// <copyright file="CurrencyLogic.cs" company="PlaceholderCompany">
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
    using Nest;

    /// <summary>
    /// Curreny's logic class.
    /// </summary>
    public class CurrencyLogic : ICurrencyLogic
    {
        private ICurrencyRepository currencyRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyLogic"/> class.
        /// Contsructor.
        /// </summary>
        /// <param name="currencyRepo"></param>
        public CurrencyLogic(ICurrencyRepository currencyRepo)
        {
            this.currencyRepo = currencyRepo;
        }

        /// <summary>
        /// Add a new currency to the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Currency entity)
        {
            this.currencyRepo.Add(entity);
        }

        /// <summary>
        /// Back to all currency.
        /// </summary>
        /// <param name="entity"></param>
        public void Read(Currency entity)
        {
            this.currencyRepo.GetAll();
        }

        /// <summary>
        /// Remove one currency to the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(Currency entity)
        {
            this.currencyRepo.Delete(entity);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Currency entity)
        {
            Random r = new Random();
            if (entity.ShortName != "USD")
            {
                double rnd = r.Next(1, 300);
                entity.ValueToOneUSD = rnd / 100;
            }
            else
            {
                entity.ValueToOneUSD = 1;
            }

            this.currencyRepo.Update(entity);
        }

        /// <summary>
        /// Get all currency name as string.
        /// </summary>
        /// <returns>asd.</returns>
        public string GetAllNameAsString()
        {
            List<string> currenciesName = this.currencyRepo.GetAll().Select(x => x.ShortName).ToList();
            return string.Join(", ", currenciesName);
        }

        /// <summary>
        /// Add a new currency.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="shortName"></param>
        /// <param name="nationality"></param>
        /// <param name="symbol"></param>
        public void AddNewOne(string name, string shortName, string nationality, string symbol)
        {
            Random r = new Random();
            double random = r.Next(1, 300);

            Currency currency = new Currency()
            {
                Name = name,
                ShortName = shortName,
                Nationality = nationality,
                Symbol = symbol,
                Value = 5,
                ValueToOneUSD = 1 * (random / 100),
            };

            this.currencyRepo.Add(currency);
        }

        /// <summary>
        /// Refresh currencies value.
        /// </summary>
        /// <param name="currencyLogic"></param>
        public void Refresh(ICurrencyLogic currencyLogic)
        {
            List<Currency> currencies = this.currencyRepo.GetAll().ToList();

            foreach (var item in currencies)
            {
                currencyLogic.Update(item);
            }
        }

        /// <summary>
        /// Get all currency value.
        /// </summary>
        /// <returns>asd.</returns>
        public string[] CurrencyPrice()
        {
            List<Currency> currencies = this.currencyRepo.GetAll().ToList();

            string[] res = new string[currencies.Count];

            int i = 0;

            foreach (var item in currencies)
            {
                string name = item.Name;
                double value = item.ValueToOneUSD;
                res[i] = $"{name} value is: {value}";
                i++;
            }

            return res;
        }

        /// <summary>
        /// Delete currency.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public bool DeleteCurrency(string shortName)
        {
            List<Currency> cur = this.currencyRepo.GetAll().Where(x => x.ShortName == shortName).ToList();
            bool pos = false;
            foreach (var item in cur)
            {
                if (item.ShortName == shortName)
                {
                    pos = true;
                    this.currencyRepo.Delete(item);
                }
                else if (pos == false)
                {
                    pos = false;
                }
            }

            return pos;
        }
    }
}
