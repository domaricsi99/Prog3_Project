// <copyright file="CryptoesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using CryptoTrading.Data;
    using CryptoTrading.Logic;
    using CryptoTrading.Repository;
    using CryptoTradingMVC.Web.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// MVC controller.
    /// </summary>
    public class CryptoesController : Controller
    {
        private ICryptoLogic logic;
        private IMapper mapper;
        private CryptoesViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoesController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public CryptoesController(ICryptoLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;

            this.vm = new CryptoesViewModel();
            this.vm.EditedCrypto = new Model.Crypto();

            var cryptoes = this.logic.ReadAll();
            this.vm.ListOfCryptoes = this.mapper.Map<IList<Models.Crypto>, List<Model.Crypto>>(cryptoes);
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>Action result.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("CryptoesIndex", this.vm);
        }

        /// <summary>
        /// Details.
        /// </summary>
        /// <param name="id">crypto id.</param>
        /// <returns>action.</returns>
        public IActionResult Details(int id)
        {
            return this.View("CryptoesDetails", this.GetCryptoModel(id));
        }

        /// <summary>
        /// Remove.
        /// </summary>
        /// <param name="id">crypto id.</param>
        /// <returns>action.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete OK";
            var cryptoList = this.logic.ReadAll();
            Models.Crypto oneCrypto = null;
            foreach (var item in cryptoList)
            {
                if (item.CryptoID == id)
                {
                    oneCrypto = item;
                }
            }

            this.logic.Remove(oneCrypto);

            if (oneCrypto.Name == null)
            {
                this.TempData["editResult"] = "Delete OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edit.
        /// </summary>
        /// <param name="id">crypto id.</param>
        /// <returns>action.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";

            this.vm.EditedCrypto = this.GetCryptoModel(id);

            return this.View("CryptoesIndex", this.vm);
        }

        /// <summary>
        /// Edit.
        /// </summary>
        /// <param name="crypto">crypto.</param>
        /// <param name="editAction">action.</param>
        /// <returns>ection.</returns>
        [HttpPost]
        public IActionResult Edit(Model.Crypto crypto, string editAction)
        {
            if (this.ModelState.IsValid && crypto != null)
            {
                this.TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    this.logic.AddNewCrypto(crypto.Name, crypto.ShortName);
                }
                else
                {
                    var cryptoList = this.logic.ReadAll();
                    foreach (var item in cryptoList)
                    {
                        if (crypto.ID == item.CryptoID)
                        {
                            Models.Crypto crypto1 = new Models.Crypto();
                            if (crypto.Name != item.Name || crypto.ShortName != item.ShortName || crypto.Value != crypto.Value)
                            {
                                crypto1.Name = crypto.Name;
                                crypto1.ShortName = crypto.ShortName;
                                crypto1.Value = crypto.Value;
                            }

                            this.logic.Remove(item);
                            this.logic.Add(crypto1);
                        }
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedCrypto = crypto;
                return this.View("CryptoesIndex", this.vm);
            }
        }

        private Model.Crypto GetCryptoModel(int id)
        {
            var cryptoList = this.logic.ReadAll();
            Models.Crypto oneCrypto = null;
            foreach (var item in cryptoList)
            {
                if (item.CryptoID == id)
                {
                    oneCrypto = item;
                }
            }

            return this.mapper.Map<Models.Crypto, Model.Crypto>(oneCrypto);
        }
    }
}
