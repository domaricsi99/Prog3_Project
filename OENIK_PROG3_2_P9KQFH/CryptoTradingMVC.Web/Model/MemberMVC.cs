// <copyright file="MemberMVC.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Member model in mvc.
    /// </summary>
    public class MemberMVC
    {
        /// <summary>
        /// Gets or sets adb.
        /// </summary>
        [Display(Name = "Member id")]
        public int MemberID { get; set; }

        /// <summary>
        /// Gets or sets here can we storage the Bitcoins.
        /// </summary>
        [Display(Name = "Member BTC wallet")]
        public double BTCWallet { get; set; }

        /// <summary>
        /// Gets or sets here can we storage the Ethereum.
        /// </summary>
        [Display(Name = "Member ETH wallet")]
        public double ETHWallet { get; set; }
    }
}
