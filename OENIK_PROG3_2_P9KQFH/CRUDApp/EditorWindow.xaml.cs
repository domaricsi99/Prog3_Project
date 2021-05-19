// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using CRUDApp.Data;
    using CRUDApp.VM;
    using Models;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel vM;

        /// <summary>
        /// Gets editor window crypto model.
        /// </summary>
        public CryptoModel Crypto
        {
            get { return this.vM.Crypto; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// ctor.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();
            this.vM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// ctor.
        /// </summary>
        /// <param name="newCrypto"></param>
        public EditorWindow(CryptoModel newCrypto)
            : this()
        {
            this.vM.Crypto = newCrypto;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
