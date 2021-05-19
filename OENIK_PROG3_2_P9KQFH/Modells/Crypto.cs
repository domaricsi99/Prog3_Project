// <copyright file="Crypto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Crypto currency like BITCOIN.
    /// </summary>
    [Table("Crypto")]
    public class Crypto : TradeItemBase
    {
        /// <summary>
        /// Gets or sets rank in top 100.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets Popularity among 100 people.
        /// </summary>
        [MaxLength(100)]
        public int Popularity { get; set; }

        /// <summary>
        /// Gets or sets the reference Crypto.
        /// </summary>
        public int CryptoID { get; set; }

        /// <summary>
        /// copy from.
        /// </summary>
        /// <param name="other"></param>
        public void CopyFrom(Crypto other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }

        ///// <summary>
        ///// Gets reference to trade.
        ///// </summary>
        // [NotMapped]
        // public new virtual ICollection<Trade> Trades { get; }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="Crypto"/> class.
        ///// asd.
        ///// </summary>

        // public Crypto() => this.Trades = new HashSet<Trade>();
    }
}
