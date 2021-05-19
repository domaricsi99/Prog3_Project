// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CRUDApp.Data;
    using Models;

    /// <summary>
    /// editor service interface.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// edit crypto.
        /// </summary>
        /// <param name="crypto"></param>
        /// <returns>TRUE.</returns>
        bool EditCrypto(CryptoModel crypto);
    }
}
