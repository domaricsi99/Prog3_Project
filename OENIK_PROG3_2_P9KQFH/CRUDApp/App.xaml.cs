// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using CommonServiceLocator;
    using CryptoTrading.Logic;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// My container.
    /// </summary>
    internal class MyIOC : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets my ioc.
        /// </summary>
        public static MyIOC Instance { get; private set; } = new MyIOC();
    }
}
