// <copyright file="CryptoVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Crypto vm class.
    /// </summary>
    public class CryptoVM : ObservableObject
    {
        private int iD;
        private string name;
        private string shortName;

        /// <summary>
        /// Gets or sets crypto model name prop wpf.
        /// </summary>
        public int ID
        {
            get { return this.iD; }
            set { this.Set(ref this.iD, value); }
        }

        /// <summary>
        /// Gets or sets crypto model name prop wpf.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets crypto model short name prop.
        /// </summary>
        public string ShortName
        {
            get { return this.shortName; }
            set { this.Set(ref this.shortName, value); }
        }

        /// <summary>
        /// Gets or sets crypto model value prop.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// copy from ctor.
        /// </summary>
        /// <param name="other">other crypto.</param>
        public void CopyFrom(CryptoVM other)
        {
            if (other == null)
            {
                return;
            }

            this.ID = other.ID;
            this.Name = other.Name;
            this.ShortName = other.ShortName;
            this.Value = other.Value;
        }
    }
}
