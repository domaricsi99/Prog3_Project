// <copyright file="Member.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A user who want to trade or exchange.
    /// </summary>
    [Table("Member")]
    public class Member
    {
        /// <summary>
        /// Gets or sets the  reference to Member.
        /// </summary>
        [Key]
        public int MemberID { get; set; }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the user's birth year.
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Gets or sets the user money.
        /// </summary>
        public double Money { get; set; }

        /// <summary>
        /// Gets or sets user's username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets here can we storage the Bitcoins.
        /// </summary>
        public double BTCWallet { get; set; }

        /// <summary>
        /// Gets or sets here can we storage the Ethereum.
        /// </summary>
        public double ETHWallet { get; set; }

        /// <summary>
        /// Gets reference to Trade table.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Trade> Trades { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        public Member() => this.Trades = new HashSet<Trade>();
    }
}
