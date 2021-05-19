// <copyright file="CryptoVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    public class CryptoVM : ObservableObject
    {
        private string name;
        private int id;
        private string shortName;

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
        /// Gets or sets crypto id.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Gets or sets crypto model value prop.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// copy from ctor.
        /// </summary>
        /// <param name="other">crypto.</param>
        public void CopyFrom(CryptoVM other)
        {
            if (other == null)
            {
                return;
            }

            this.id = other.id;
            this.name = other.name;
            this.shortName = other.shortName;
            this.Value = other.Value;
        }
    }
}
