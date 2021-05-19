// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.Data
{
    using CryptoTrading.Data;
    using CryptoTrading.Logic;
    using CryptoTrading.Repository;
    using Nest;

    /// <summary>
    /// DB, repo.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Crypto logic field.
        /// </summary>
        private CryptoLogic cryptoLogic;

        /// <summary>
        /// Currency logic field.
        /// </summary>
        private CurrencyLogic currencyLogic;

        /// <summary>
        /// Member logic fiel.
        /// </summary>
        private MemberLogic memberLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// Initializes a new instanceof the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            CTDDataBase db = new CTDDataBase();

            MemberRepository memberRepository = new MemberRepository(db);
            CurrencyRepository currencyRepository = new CurrencyRepository(db);
            CryptoRepository cryptoRepository = new CryptoRepository(db, memberRepository);
            TradeItemBaseRepository tradeItemBaseRepository = new TradeItemBaseRepository(db);

            CryptoLogic cryptoLogic = new CryptoLogic(cryptoRepository, memberRepository);
            CurrencyLogic currencyLogic = new CurrencyLogic(currencyRepository);
            MemberLogic memberLogic = new MemberLogic(memberRepository);

            this.memberLogic = memberLogic;
            this.currencyLogic = currencyLogic;
            this.cryptoLogic = cryptoLogic;
        }

        /// <summary>
        /// Gets icryptologic ctor.
        /// </summary>
        public ICryptoLogic GetCryptoLogic => this.cryptoLogic;

        /// <summary>
        /// Gets iMemberlogic ctor.
        /// </summary>
        public IMemberLogic GetMemberLogic => this.memberLogic;

        /// <summary>
        /// Gets iCurrencyLogic ctor.
        /// </summary>
        public ICurrencyLogic GetCurrencyLogic => this.currencyLogic;
    }
}
