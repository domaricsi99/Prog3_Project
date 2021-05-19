// <copyright file="TradeItemBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Base to Trade.
    /// </summary>
    [Table("TradeItemBase")]
    public abstract class TradeItemBase
    {
        /// <summary>
        /// Gets or sets the item name wherewith you trade.
        /// </summary>
        [Key]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item short name wherewith you trade.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets value to one USD.
        /// This prop help to which exchange rate should we exchange.
        /// </summary>
        public double ValueToOneUSD { get; set; }

        /// <summary>
        /// Gets or sets reference to Currency table.
        /// </summary>
        [NotMapped]
        public virtual Currency Currencies { get; set; }

        /// <summary>
        /// Gets or sets reference to Trade table.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Trade> Trades { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeItemBase"/> class.
        /// </summary>
        protected TradeItemBase() => this.Trades = new HashSet<Trade>();
    }
}
