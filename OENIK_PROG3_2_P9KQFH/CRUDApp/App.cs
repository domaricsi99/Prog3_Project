// <copyright file="App.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp
{
    using System.Windows;
    using CommonServiceLocator;
    using CRUDApp.BL;
    using CRUDApp.Data;
    using CRUDApp.UI;
    using CryptoTrading.Data;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// app.
        /// </summary>
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => MyIOC.Instance);

            MyIOC.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIOC.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIOC.Instance.Register<ICryptoLogicW, CryptoLogicW>();

            MyIOC.Instance.Register<Factory, Factory>();

            CTDDataBase ctx = new CTDDataBase();
            MyIOC.Instance.Register<DbContext>(() => ctx);
        }
    }
}
