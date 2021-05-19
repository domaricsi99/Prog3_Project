// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CRUDApp.BL;
    using CRUDApp.Data;
    using Models;

    /// <summary>
    /// editor service via window.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// edit crypto.
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns>TRUE.</returns>
        public bool EditCrypto(CryptoModel crypto)
        {
            EditorWindow win = new EditorWindow(crypto);
            return win.ShowDialog() ?? false;
        }
    }
}
