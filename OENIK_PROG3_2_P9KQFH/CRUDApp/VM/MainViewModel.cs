// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows.Input;
    using CommonServiceLocator;
    using CRUDApp.BL;
    using CRUDApp.Data;
    using CryptoTrading.Logic;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Models;

    /// <summary>
    /// Main view model.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ICryptoLogicW logicW;

        /// <summary>
        /// crypto model.
        /// </summary>
        private CryptoModel cryptoSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// ctor.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ICryptoLogicW>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// ctor.
        /// </summary>
        /// <param name="logicW"></param>
        internal MainViewModel(ICryptoLogicW logicW)
        {
            this.logicW = logicW;

            this.Cryptos = new ObservableCollection<CryptoModel>(this.logicW.GetAllCrypto());

            this.AddCmd = new RelayCommand(() => this.logicW.AddCrypto(this.Cryptos), true);

            this.ModCmd = new RelayCommand(() => this.logicW.ModCrypto(this.cryptoSelected), true);

            this.DelCmd = new RelayCommand(() => this.logicW.DelCrypto(this.Cryptos, this.cryptoSelected), true);
        }

        /// <summary>
        /// Gets or sets selected crypto.
        /// </summary>
        public CryptoModel CryptoSelected
        {
            get { return this.cryptoSelected; }
            set { this.Set(ref this.cryptoSelected, value); }
        }

        /// <summary>
        /// Gets cryptos.
        /// </summary>
        public ObservableCollection<CryptoModel> Cryptos { get; private set; }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets mod command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets del command.
        /// </summary>
        public ICommand DelCmd { get; private set; }
    }
}
