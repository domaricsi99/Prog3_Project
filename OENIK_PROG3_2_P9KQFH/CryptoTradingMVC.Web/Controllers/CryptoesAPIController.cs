// <copyright file="CryptoesAPIController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using CryptoTrading.Logic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// API controller.
    /// </summary>
    public class CryptoesAPIController : Controller
    {
        // logic mapper
        private ICryptoLogic logic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoesAPIController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public CryptoesAPIController(ICryptoLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// get cryptoesAPI/ getall.
        /// </summary>
        /// <returns>IEnumerable crypto.</returns>
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Web.Model.Crypto> GetAll()
        {
            var cryptoes = this.logic.ReadAll();
            return this.mapper.Map<IList<Models.Crypto>, List<Web.Model.Crypto>>(cryptoes);
        }

        /// <summary>
        /// Get cryptoesAPI/del/5.
        /// </summary>
        /// <param name="id">crypto id.</param>
        /// <returns>bool.</returns>
        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneCrypto(int id)
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

            Web.Model.Crypto delCrypto = new Web.Model.Crypto()
            {
                Name = oneCrypto.Name,
                ID = oneCrypto.CryptoID,
                ShortName = oneCrypto.ShortName,
            };

            string sname = delCrypto.ShortName;

            ApiResult apiResult = new ApiResult()
            {
                OperationResult = this.logic.PossibleDelet(oneCrypto.ShortName),
            };

            return apiResult;
        }

        /// <summary>
        /// Post CryptoesAPI/add + post 1 crypto.
        /// </summary>
        /// <param name="crypto">crypto.</param>
        /// <returns>one crypto.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneCar(Model.Crypto crypto)
        {
            bool success = true;

            if (string.IsNullOrEmpty(crypto.Name))
            {
                success = false;
            }
            else
            {
                this.logic.AddNewCrypto(crypto.Name, crypto.ShortName);
            }

            return new ApiResult()
            {
                OperationResult = success,
            };
        }

        /// <summary>
        /// POST CryptoesAPI/mod + post 1 crypto.
        /// </summary>
        /// <param name="crypto">crypto.</param>
        /// <returns>1 crypto.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneCar(Web.Model.Crypto crypto)
        {
            bool success = true;

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
                        crypto1.CryptoID = crypto.ID;
                        success = true;
                        break;
                    }
                    else
                    {
                        success = false;
                    }

                    this.logic.Remove(item);
                    this.logic.Add(crypto1);
                }
            }

            return new ApiResult()
            {
                OperationResult = success,
            };
        }
    }
}
