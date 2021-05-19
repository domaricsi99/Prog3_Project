// <copyright file="CryptoRepoTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Logic.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CryptoTrading.Repository;
    using Models;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    public class CryptoRepoTest
    {
        private Mock<IRepository<Crypto>> RepoMock;

        private Mock<ICryptoRepository> cryptoRepoMock;

        private Mock<IMemberRepository> memberRepoMock;

        private CryptoLogic logic;

        // Crypto BTC = new Crypto() { Name = "Bitcoin", ShortName = "BTC", CryptoID = 1, Rank = 1, Value = 19666, ValueToOneUSD = 0.00008 };
        private Member member = new Member() { Money = 10000, UserName = "admin", };

        /// <summary>
        /// Init mock repo and logic.
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.cryptoRepoMock = new Mock<ICryptoRepository>(MockBehavior.Loose);
            this.logic = new CryptoLogic(this.cryptoRepoMock.Object);
            this.RepoMock = new Mock<IRepository<Crypto>>(MockBehavior.Loose);
            this.memberRepoMock = new Mock<IMemberRepository>(MockBehavior.Loose);

            this.cryptoRepoMock.Setup(x => x.AddNewCrypto(It.IsAny<string>(), It.IsAny<string>()));
            this.cryptoRepoMock.Setup(x => x.DoubleOrQuits(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>()));
            this.cryptoRepoMock.Setup(x => x.PossibleDelet(It.IsAny<string>()));
            this.cryptoRepoMock.Setup(x => x.SellBTC()).Returns(It.IsAny<double>());
            this.cryptoRepoMock.Setup(x => x.BuyBTC()).Returns(It.IsAny<double>());
            this.cryptoRepoMock.Setup(x => x.GetAll());
            this.cryptoRepoMock.Setup(x => x.GetOne(It.IsAny<string>()));
            this.cryptoRepoMock.Setup(x => x.Refresh());

            this.RepoMock.Setup(x => x.GetOne(It.IsAny<string>())).Returns(It.IsAny<Crypto>());

            this.memberRepoMock.Setup(x => x.GetOne(this.member.UserName)).Returns(this.member);
        }

        /// <summary>
        /// Add new crypto.
        /// </summary>
        [Test]
        public void AddingNewCrypto()
        {
            this.logic.AddNewCrypto("Bitcoin", "BTC");

            this.cryptoRepoMock.Verify(repo => repo.AddNewCrypto("Bitcoin", "BTC"), Times.Once);
        }

        /// <summary>
        /// Double or quits test.
        /// </summary>
        [Test]
        public void TestDoubleOrQuits()
        {
            double bTCValue = this.logic.BTCValue = 1;
            double otherValue = this.logic.OtherValue = 1;

            double value = this.logic.DoubleOrQuits(this.member.UserName, "BTC", "grow");

            this.cryptoRepoMock.Verify(repo => repo.DoubleOrQuits(this.member.UserName, "BTC", "grow", bTCValue, otherValue), Times.Once);

            Assert.AreEqual(0, value);
        }

        /// <summary>
        /// Delete cryptotest.
        /// </summary>
        [Test]
        public void TestPossibleDelet()
        {
            this.logic.PossibleDelet("BTC");

            this.cryptoRepoMock.Verify(repo => repo.PossibleDelet("BTC"), Times.Once);
        }

        /// <summary>
        /// Sell btc test.
        /// </summary>
        [Test]
        public void TestSellBtc()
        {
            double ret = this.logic.SellBTC();

            this.cryptoRepoMock.Verify(r => r.SellBTC(), Times.Once);

            Assert.AreEqual(ret, 0);
        }

        /// <summary>
        /// Buy bitcoin test.
        /// </summary>
        [Test]
        public void TestBuyBtc()
        {
            double ret = this.logic.BuyBTC();

            this.cryptoRepoMock.Verify(r => r.BuyBTC(), Times.Once);

            Assert.AreEqual(ret, 0);
        }

        /// <summary>
        /// Get all test.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            List<Crypto> cryptos = new List<Crypto>()
            {
                new Crypto() { Name = "Bitcoin", ShortName = "BTC", CryptoID = 1, Rank = 1, Value = 19666, ValueToOneUSD = 0.00008 },
                new Crypto() { Name = "Ethereum", ShortName = "ETH", CryptoID = 2, Rank = 2, Value = 500, ValueToOneUSD = 0.00314 },
                new Crypto() { Name = "Ripple", ShortName = "XRP", CryptoID = 3, Rank = 3, Value = 1, ValueToOneUSD = 2 },
            };

            List<Crypto> expectedCryptos = new List<Crypto>()
            {
                new Crypto() { Name = "Bitcoin", ShortName = "BTC", CryptoID = 1, Rank = 1, Value = 19666, ValueToOneUSD = 0.00008 },
            };

            CryptoLogic cryptoLogic = new CryptoLogic(this.cryptoRepoMock.Object);
        }

        /// <summary>
        /// Get one test.
        /// </summary>
        [Test]
        public void TestGetOne()
        {
            Crypto btc = this.logic.GetOne("BTC");

            this.cryptoRepoMock.Verify(r => r.GetOne("BTC"), Times.Once);
        }

        /// <summary>
        /// Refresh test.
        /// </summary>
        [Test]
        public void TestRefresh()
        {
            this.logic.Refresh();

            this.cryptoRepoMock.Verify(r => r.Refresh(), Times.Once);
        }
    }
}
