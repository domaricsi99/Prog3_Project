// <copyright file="Trade.cs" company="PlaceholderCompany">
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
    /// If a user want to trade do it here.
    /// </summary>
    [Table("Trade")]
    public class Trade
    {
        /// <summary>
        /// Gets or sets reference to trade.
        /// </summary>
        [Key]
        public int TradeID { get; set; }

        /// <summary>
        /// Gets or sets adb.
        /// </summary>
        // [ForeignKey(nameof(Members))]
        public int MemberID { get; set; }

        /// <summary>
        /// Gets or sets witch day you trade.
        /// </summary>
        public DateTime TradingDate { get; set; }

        /// <summary>
        /// Gets or sets Wherewith you trade.
        /// </summary>
        public TradeItemBase TradeItem { get; set; }

        /// <summary>
        /// Gets or sets reference to Member table.
        /// </summary>
        [NotMapped]
        public virtual Member Members { get; set; }

        /// <summary>
        /// Gets or sets reference to TradeItemBase table.
        /// </summary>
        [NotMapped]
        public virtual TradeItemBase TradeItemBases { get; set; }

        /// <summary>
        /// Gets or sets reference to Currency table.
        /// </summary>
        [NotMapped]
        public virtual Currency Currencies { get; set; }

        /// <summary>
        /// Gets or sets reference to Crypto table.
        /// </summary>
        [NotMapped]
        public virtual Crypto Cryptoses { get; set; }
    }
}
