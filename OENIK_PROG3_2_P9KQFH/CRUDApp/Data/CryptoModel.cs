// <copyright file="CryptoModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using Models;

    /// <summary>
    /// crypto model wpf.
    /// </summary>
    public class CryptoModel : ObservableObject
    {
        private string name;

        /// <summary>
        /// Gets or sets crypto model name prop wpf.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        private string shortName;

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
        /// <param name="other"></param>
        public void CopyFrom(CryptoModel other)
        {
            this.GetType().GetProperties().ToList().
                ForEach(property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
