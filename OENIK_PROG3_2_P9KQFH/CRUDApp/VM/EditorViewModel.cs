// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.VM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CRUDApp.Data;
    using GalaSoft.MvvmLight;
    using Models;

    /// <summary>
    /// Editor view model.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private CryptoModel crypto;

        /// <summary>
        /// Gets or sets crypto.
        /// </summary>
        public CryptoModel Crypto
        {
            get { return this.crypto; }
            set { this.Set(ref this.crypto, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// editor view model.
        /// </summary>
        public EditorViewModel()
        {
            this.crypto = new CryptoModel();
            if (this.IsInDesignMode)
            {
                this.crypto.Name = "Proba Harom";
                this.crypto.ShortName = "PRO3";
                this.crypto.Value = 60000;
            }
        }
    }
}
