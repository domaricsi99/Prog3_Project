// <copyright file="CryptoesViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Cryptoes view model.
    /// </summary>
    public class CryptoesViewModel
    {
        /// <summary>
        /// Gets or sets edited crypto.
        /// </summary>
        public Crypto EditedCrypto { get; set; }

        /// <summary>
        /// Gets or sets list of cryptoes.
        /// </summary>
        public List<Crypto> ListOfCryptoes { get; set; }
    }
}
