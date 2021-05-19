// <copyright file="Crypto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Crypto MVC class.
    /// </summary>
    public class Crypto // Form model / MVC viewModel is lesz
    {
        /// <summary>
        /// Gets or sets value.
        /// </summary>
        [Display(Name = "Crypto value")]
        [Required]
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the reference Crypto.
        /// </summary>
        [Display(Name ="Crypto id")]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the item name wherewith you trade.
        /// </summary>
        [Display(Name ="Crypto name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item short name wherewith you trade.
        /// </summary>
        [Display(Name ="Crypto short name")]
        [Required]
        public string ShortName { get; set; }
    }
}
