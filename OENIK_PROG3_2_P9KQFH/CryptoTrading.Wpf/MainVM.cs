// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// Main vm.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private ObservableCollection<CryptoVM> allCrypto;
        private CryptoVM selectedCrypto;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
        {
            this.logic = new MainLogic();

            this.LoadCmd = new RelayCommand(() =>
            this.AllCrypto = new ObservableCollection<CryptoVM>(this.logic.ApiGetCrypto()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelCrypto(this.SelectedCrypto));
            this.AddCmd = new RelayCommand(() => this.logic.EditCrypto(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditCrypto(this.SelectedCrypto, this.EditorFunc));
        }

        /// <summary>
        /// Gets or sets selected crypto.
        /// </summary>
        public CryptoVM SelectedCrypto
        {
            get { return this.selectedCrypto; }
            set { this.Set(ref this.selectedCrypto, value); }
        }

        /// <summary>
        /// Gets or sets all crypto.
        /// </summary>
        public ObservableCollection<CryptoVM> AllCrypto
        {
            get { return this.allCrypto; }
            set { this.Set(ref this.allCrypto, value); }
        }

        /// <summary>
        /// Gets or sets editor function.
        /// </summary>
        public Func<CryptoVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets add cmd.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets del cmd.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets mod cmd.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets load cmd.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}
