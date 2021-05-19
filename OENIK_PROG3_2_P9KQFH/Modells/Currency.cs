// <copyright file="Currency.cs" company="PlaceholderCompany">
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
    /// Like USD.
    /// </summary>
    [Table("Currency")]
    public class Currency : TradeItemBase
    {
        /// <summary>
        /// Gets or sets currency Nationality.
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the reference to currency.
        /// </summary>
        public int CurrencyID { get; set; }

        /// <summary>
        /// Gets asd.
        /// </summary>
        [NotMapped]
        public new virtual ICollection<Trade> Trades { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// ads.
        /// </summary>
        public Currency() => this.Trades = new HashSet<Trade>();
    }
}
