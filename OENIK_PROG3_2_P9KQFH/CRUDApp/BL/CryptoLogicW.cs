// <copyright file="CryptoLogicW.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDApp.BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CRUDApp.Data;
    using CryptoTrading.Logic;
    using GalaSoft.MvvmLight.Messaging;
    using Models;

    /// <summary>
    /// WPF crypto logic interface.
    /// </summary>
    public interface ICryptoLogicW
    {
        /// <summary>
        /// add crypto wpf.
        /// </summary>
        /// <param name="list"></param>
        public void AddCrypto(IList<CryptoModel> list);

        /// <summary>
        /// mod crypto wpf.
        /// </summary>
        /// <param name="cryptoToModify"></param>
        public void ModCrypto(CryptoModel cryptoToModify);

        /// <summary>
        /// del crypto wpf.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="crypto"></param>
        public void DelCrypto(IList<CryptoModel> list, CryptoModel crypto);

        /// <summary>
        /// get all crypto wpf.
        /// </summary>
        /// <returns>ASD.</returns>
        IList<CryptoModel> GetAllCrypto();
    }

    /// <summary>
    /// wpf crypto logic.
    /// </summary>
    public class CryptoLogicW : ICryptoLogicW
    {
        private IEditorService editorService;

        private IMessenger messengerService;
        private Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoLogicW"/> class.
        /// crypto logic wpf.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="messenger"></param>
        /// <param name="factory"></param>
        public CryptoLogicW(IEditorService service, IMessenger messenger, Factory factory)
        {
            this.editorService = service;
            this.messengerService = messenger;

            this.factory = factory;
        }

        /// <summary>
        /// add crypto wpf.
        /// </summary>
        /// <param name="list"></param>
        public void AddCrypto(IList<CryptoModel> list)
        {
            CryptoModel newCrypto = new CryptoModel();

            if (this.editorService.EditCrypto(newCrypto) == true)
            {
                list.Add(newCrypto);
                Crypto crypto = new Crypto()
                {
                    Name = newCrypto.Name,
                    ShortName = newCrypto.ShortName,
                    Value = newCrypto.Value,
                };

                this.factory.GetCryptoLogic.Add(crypto);

                this.messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("ADD CANCEL", "LogicResult");
            }
        }

        /// <summary>
        /// mod crypto wpf.
        /// </summary>
        /// <param name="cryptoToModify"></param>
        public void ModCrypto(CryptoModel cryptoToModify)
        {
            if (cryptoToModify == null)
            {
                this.messengerService.Send("UPDATE FAILED", "LogicResult");
                return;
            }

            CryptoModel clone = new CryptoModel();
            clone.CopyFrom(cryptoToModify);
            if (this.editorService.EditCrypto(clone) == true)
            {
                this.factory.GetCryptoLogic.Refresh();

                List<Crypto> list = new List<Crypto>();
                var q = this.factory.GetCryptoLogic.ReadAll();

                foreach (var item in q)
                {
                    if (clone.ShortName == item.ShortName)
                    {
                        item.Name = clone.Name;

                        // item.Value = clone.Value;
                    }
                    else if (clone.Name == item.Name)
                    {
                        item.ShortName = clone.ShortName;

                        // item.Value = clone.Value;
                    }
                    else if (clone.Value == item.Value)
                    {
                        item.ShortName = clone.ShortName;
                        item.Name = clone.Name;
                    }

                    list.Add(item);
                }

                cryptoToModify.CopyFrom(clone);
                var s = this.factory.GetCryptoLogic.ReadAll();
                this.messengerService.Send("EDIT OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("EDIT CANCEL", "LogicResult");
            }
        }

        /// <summary>
        /// del crypto wpf.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="crypto"></param>
        public void DelCrypto(IList<CryptoModel> list, CryptoModel crypto)
        {
            if (crypto != null && list.Remove(crypto))
            {
                Crypto newCrypto = new Crypto()
                {
                    Name = crypto.Name,
                    ShortName = crypto.ShortName,
                    Value = crypto.Value,
                };
                this.factory.GetCryptoLogic.PossibleDelet(newCrypto.ShortName);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// get all crypto wpf.
        /// </summary>
        /// <returns>ASD.</returns>
        public IList<CryptoModel> GetAllCrypto()
        {
            BindingList<CryptoModel> modelList = new BindingList<CryptoModel>();

            IList<Crypto> cryptos = this.factory.GetCryptoLogic.ReadAll();
            foreach (Crypto item in cryptos)
            {
                CryptoModel newCrypto = new CryptoModel()
                {
                    Name = item.Name,
                    ShortName = item.ShortName,
                    Value = item.Value,
                };
                modelList.Add(newCrypto);
            }

            return modelList;
        }
    }
}
