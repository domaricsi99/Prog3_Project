// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Model
{
    using System;

    /// <summary>
    /// editor view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets reguest id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether show request id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
