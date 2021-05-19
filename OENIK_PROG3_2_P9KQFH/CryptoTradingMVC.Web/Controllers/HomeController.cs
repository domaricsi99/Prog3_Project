// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTradingMVC.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using CryptoTradingMVC.Web.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Home controller class.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">loger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>action.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Privacy.
        /// </summary>
        /// <returns>action.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Error.
        /// </summary>
        /// <returns>action.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
