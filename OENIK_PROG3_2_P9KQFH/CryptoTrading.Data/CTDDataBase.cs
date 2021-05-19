// <copyright file="CTDDataBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
    using Models;

    /// <summary>
    /// Class to create database.
    /// </summary>
    public class CTDDataBase : DbContext
    {
        /// <summary>
        /// Gets or sets Member.
        /// </summary>
        [ForeignKey("MemberID")]
        public DbSet<Member> Members { get; set; }

        /// <summary>
        /// Gets or sets Crypto.
        /// </summary>
        [ForeignKey("Name")]
        public DbSet<Crypto> Cryptos { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        [ForeignKey("Name")]
        public DbSet<Currency> Currencies { get; set; }

        /// <summary>
        /// Gets or sets Trade.
        /// </summary>
        [ForeignKey("TradeID")]
        public DbSet<Trade> Trades { get; set; }

        /// <summary>
        /// Gets or sets tradeItemBase.
        /// </summary>
        public DbSet<TradeItemBase> TradeItemBases { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTDDataBase"/> class.
        /// </summary>
        public CTDDataBase() => this.Database.EnsureCreated();

        /// <summary>
        /// Create method.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random r = new Random();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasMany(mem => mem.Trades)
                .WithOne(trade => trade.Members)
                .HasForeignKey(member => member.TradeID);
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.HasOne(trade => trade.TradeItemBases)
                .WithMany(tib => tib.Trades);
            });
            Crypto btc = new Crypto()
            {
                Name = "Bitcoin",
                ShortName = "BTC",
                Value = r.Next(1, 20001),
                ValueToOneUSD = 0.000073,
                Popularity = r.Next(0, 5),
                Rank = 1,
                CryptoID = 1,
            };
            Crypto eth = new Crypto()
            {
                Name = "Ethereum",
                ShortName = "ETH",
                Value = r.Next(1, 2001),
                ValueToOneUSD = 0.026,
                Popularity = r.Next(0, 5),
                Rank = 2,
                CryptoID = 2,
            };
            Member admin = new Member()
            {
                FullName = "Domanits Richárd",
                UserName = "admin",
                Password = "admin",
                BirthYear = 1999,
                MemberID = 1,
                Money = 20000,
                BTCWallet = 0,
                ETHWallet = 0,
            };
            Currency usd = new Currency()
            {
                Name = "American dollar",
                CurrencyID = 1,
                Nationality = "american",
                ValueToOneUSD = 1,
                ShortName = "USD",
                Symbol = "$",
                Value = 5,
            };
            Trade trade = new Trade()
            {
                TradingDate = DateTime.Today,
                TradeID = 1,
            };

            modelBuilder.Entity<Trade>().HasData(trade);
            modelBuilder.Entity<Crypto>().HasData(btc, eth);
            modelBuilder.Entity<Member>().HasData(admin);
            modelBuilder.Entity<Currency>().HasData(usd);

            admin.MemberID = trade.TradeID;
        }

        /// <summary>
        /// Configuring method.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
                        |DataDirectory|\CTDB.mdf; Integrated Security = True");
        }
    }
}
