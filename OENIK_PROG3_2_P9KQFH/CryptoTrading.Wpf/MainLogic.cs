// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using CryptoTrading.Logic;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Main logic.
    /// </summary>
    public class MainLogic
    {
        private string url = "http://localhost:51907/CryptoesApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// Send message.
        /// </summary>
        /// <param name="success">message.</param>
        public static void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "CryptoResult");
        }

        /// <summary>
        /// Apiit get crypto.
        /// </summary>
        /// <returns>list crypto vm.</returns>
        public List<CryptoVM> ApiGetCrypto()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<CryptoVM>>(json, this.jsonOptions);

            return list;
        }

        /// <summary>
        /// Api del crypto.
        /// </summary>
        /// <param name="crypto">crpto.</param>
        public void ApiDelCrypto(CryptoVM crypto)
        {
            bool success = false;
            if (crypto != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + crypto.ID.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);

                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            SendMessage(success);
        }

        /// <summary>
        /// Api edit crypto.
        /// </summary>
        /// <param name="crypto">crypto.</param>
        /// <param name="isEditing">editing.</param>
        /// <returns>true or false.</returns>
        public bool ApiEditCrypto(CryptoVM crypto, bool isEditing)
        {
            if (crypto == null)
            {
                return false;
            }

            string myUrl = isEditing ? this.url + "mod" : this.url + "add";

            var cryptoList = this.ApiGetCrypto();
            foreach (var item in cryptoList)
            {
                if (item.ID == crypto.ID)
                {
                    Models.Crypto crypto1 = new Models.Crypto();
                    if (crypto.Name != item.Name || crypto.ShortName != item.ShortName || crypto.Value != crypto.Value)
                    {
                        crypto1.CryptoID = crypto.ID;
                        crypto1.Name = crypto.Name;
                        crypto1.ShortName = crypto.ShortName;
                        crypto1.Value = crypto.Value;
                    }

                    this.ApiDelCrypto(item);

                    crypto.Name = crypto1.Name;
                    crypto.ShortName = crypto1.ShortName;
                    crypto.Value = crypto1.Value;
                    crypto.ID = crypto1.CryptoID;

                    this.ApiEditCrypto(crypto, false);
                }
            }

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("id", crypto.ID.ToString());
            }

            postData.Add("Name", crypto.Name);
            postData.Add("ShortName", crypto.ShortName);
            postData.Add("Value", crypto.Value.ToString());
            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).
                Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }

        /// <summary>
        /// Edit crpyot.
        /// </summary>
        /// <param name="crypto">crypto.</param>
        /// <param name="editor">editor.</param>
        public void EditCrypto(CryptoVM crypto, Func<CryptoVM, bool> editor)
        {
            CryptoVM clone = new CryptoVM();
            if (crypto != null)
            {
                clone.CopyFrom(crypto);
            }

            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (crypto != null)
                {
                    success = this.ApiEditCrypto(clone, true);
                }
                else
                {
                    success = this.ApiEditCrypto(clone, false);
                }
            }

            SendMessage(success == true);
        }
    }
}
