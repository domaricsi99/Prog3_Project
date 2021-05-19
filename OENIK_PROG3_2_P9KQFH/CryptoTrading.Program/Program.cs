// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Program
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading;
    using System.Threading.Tasks;
    using ConsoleTools;
    using CryptoTrading.Data;
    using CryptoTrading.Logic;
    using CryptoTrading.Repository;
    using Models;

    /// <summary>
    /// program.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // csak logic
            Factory factory = new Factory();

            Welcome();
            Thread.Sleep(1000);

            /* Console.WriteLine("Please login");
            Thread.Sleep(500);
            if (Login() == true)
            {
                ConsoleMenu logMenu = new ConsoleMenu()
                    .Add("List", () => List(factory.GetCryptoLogic, factory.GetMemberLogic, factory.GetCurrencyLogic))
                    .Add("Registration", () => AddNewMember(factory.GetMemberLogic))
                    .Add("Trade", () => CryptoSet(factory.GetCryptoLogic, factory.GetMemberLogic))
                    .Add("Member set", () => Member(factory.GetMemberLogic))
                    .Add("Currency set", () => Currency(factory.GetCurrencyLogic))
                    .Add("Close", ConsoleMenu.Close);
                logMenu.Show();
            }*/
            ConsoleMenu logMenu = new ConsoleMenu()
                    .Add("List", () => List(factory.GetCryptoLogic, factory.GetMemberLogic, factory.GetCurrencyLogic))
                    .Add("Registration", () => AddNewMember(factory.GetMemberLogic))
                    .Add("Trade", () => CryptoSet(factory.GetCryptoLogic, factory.GetMemberLogic))
                    .Add("Member set", () => Member(factory.GetMemberLogic))
                    .Add("Currency set", () => Currency(factory.GetCurrencyLogic))
                    .Add("Close", ConsoleMenu.Close);
            logMenu.Show();
        }

        private static void CryptoSet(ICryptoLogic cryptoLogic, IMemberLogic memberLogic)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu()
                    .Add("My wallet", () => MyMoney(memberLogic))
                    .Add("Cryptoes prices", () => CryptoPrice(cryptoLogic))
                    .Add("Refresh crypto price", () => Refresh(cryptoLogic))
                    .Add("Delete crypto", () => DeletBtc(cryptoLogic))
                    .Add("Add new crypto", () => AddNewCrypto(cryptoLogic))
                    .Add("Buy bitcoin", () => BuyBTC(cryptoLogic))
                    .Add("Buy bitcoin with async", () => BuyBTCAsync(cryptoLogic))
                    .Add("Sell bitcoin", () => SellBTC(cryptoLogic))
                    .Add("Sell bitcoin with async", () => SellBTCAsync(cryptoLogic))
                    .Add("Double or quits", () => DoubleOrQuits(cryptoLogic))
                    .Add("Double or quits with async", () => DoubleOrQuitsAsync(cryptoLogic))
                    .Add("Close", ConsoleMenu.Close);
            consoleMenu.Show();
        }

        private static void List(ICryptoLogic cryptoLogic, IMemberLogic memberLogic, ICurrencyLogic currencyLogic)
        {
            ConsoleMenu logMenu = new ConsoleMenu()
                    .Add("List crypto", () => AllCryptoNameAsString(cryptoLogic))
                    .Add("List crypto async", () => GetAllNameAsStringDoSomethingAsync(cryptoLogic))
                    .Add("List currency", () => AllCurrencyoNameAsString(currencyLogic))
                    .Add("User full name", () => AllMemberNameAsString(memberLogic))
                    .Add("Back", ConsoleMenu.Close);
            logMenu.Show();
        }

        private static void Member(IMemberLogic memberLogic)
        {
            ConsoleMenu logMenu = new ConsoleMenu()
                    .Add("Delete profil", () => DeleteProfil(memberLogic))
                    .Add("Deposite", () => Deposite(memberLogic))
                    .Add("Back", ConsoleMenu.Close);
            logMenu.Show();
        }

        private static void Currency(ICurrencyLogic currencyLogic)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu()
                .Add("Add new currency", () => AddNewCurrency(currencyLogic))
                .Add("Delete currency", () => DeleteCurrency(currencyLogic))
                .Add("Refresh currency value", () => UpdateCurrencyPrice(currencyLogic))
                .Add("Currency price", () => CurrencyValue(currencyLogic))
                .Add("Back", ConsoleMenu.Close);
            consoleMenu.Show();
        }

        // NON CRUD
        private static void SellBTC(ICryptoLogic cryptoLogic)
        {
            double money = cryptoLogic.SellBTC();
            Console.WriteLine($"You have {money} USD");
            Console.ReadLine();
        }

        private static void SellBTCAsync(ICryptoLogic cryptoLogic)
        {
            Task<List<double>> task2 = cryptoLogic.SellBTCAsync();

            task2.Start();
            task2.ContinueWith(x =>
            {
                foreach (var item in task2.Result)
                {
                    Console.WriteLine($"You have {item} USD");
                }
            });

            Console.ReadLine();
        }

        private static void BuyBTC(ICryptoLogic cryptoLogic)
        {
            double btc = cryptoLogic.BuyBTC();
            Console.WriteLine($"You have {btc} BITCOIN");
            Console.ReadLine();
        }

        private static void BuyBTCAsync(ICryptoLogic cryptoLogic)
        {
            Task<List<double>> task = cryptoLogic.BuyBTCAsync();

            task.Start();
            task.ContinueWith(x =>
            {
                foreach (var item in task.Result)
                {
                    Console.WriteLine($"You have {item} BITCOIN");
                }
            });

            Console.ReadLine();
        }

        private static void DoubleOrQuits(ICryptoLogic cryptoLogic)
        {
            Console.WriteLine("Add your username");
            string userName = Console.ReadLine();

            Console.WriteLine("Add crypto short name");
            string cryptSname = Console.ReadLine();

            Console.WriteLine($"{cryptSname} price fall or grow?");
            string answer = Console.ReadLine();

            double newMoney = cryptoLogic.DoubleOrQuits(userName, cryptSname, answer);

            Console.WriteLine($"Your new balance: {newMoney} USD");

            Console.ReadLine();
        }

        private static void DoubleOrQuitsAsync(ICryptoLogic cryptoLogic)
        {
            Console.WriteLine("Add your username");
            string userName = Console.ReadLine();

            Console.WriteLine("Add crypto short name");
            string cryptSname = Console.ReadLine();

            Console.WriteLine($"{cryptSname} price fall or grow?");
            string answer = Console.ReadLine();

            Task<List<double>> task = cryptoLogic.DoubleOrQuitsDoSomethingAsync(userName, cryptSname, answer);

            task.Start();
            task.ContinueWith(x =>
            {
               foreach (var item in task.Result)
               {
                   Console.WriteLine($"Your new balance: {item} USD");
               }
            });
            Console.ReadLine();
        }

        // Crypto CRUD
        private static void AddNewCrypto(ICryptoLogic cryptoLogic)
        {
            Console.WriteLine("Please add the following : ");
            Console.WriteLine();

            Console.WriteLine("Crypto name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Crypto short name: ");
            string shortName = Console.ReadLine();

            cryptoLogic.AddNewCrypto(name, shortName);
        }

        private static void DeletBtc(ICryptoLogic cryptoLogic)
        {
            Console.WriteLine("Add the crypto short name: ");
            string shortName = Console.ReadLine();
            bool pos = cryptoLogic.PossibleDelet(shortName);
            if (pos == true)
            {
                Console.WriteLine("Successful delet!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

            Console.ReadLine();
        }

        private static void CryptoPrice(ICryptoLogic logic)
        {
            string[] res = logic.CryptoPrice();

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void Refresh(ICryptoLogic logic)
        {
            logic.Refresh();
        }

        private static void AllCryptoNameAsString(ICryptoLogic logic)
        {
            Console.WriteLine(logic.GetAllNameAsString());
            Console.ReadLine();
        }

        // Member CRUD
        private static void AddNewMember(IMemberLogic memberLogic)
        {
            Console.WriteLine("Please add the following : ");
            Console.WriteLine();

            Console.WriteLine("Add your full name: ");
            string fulNname = Console.ReadLine();

            Console.WriteLine("Add your username: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Add your password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Add your birth year: ");
            int birthYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Add your money: ");
            double money = double.Parse(Console.ReadLine());

            Console.WriteLine();

            memberLogic.AddNew(userName, password, fulNname, birthYear, money);
        }

        private static void DeleteProfil(IMemberLogic memberLogic)
        {
            Console.WriteLine("Add your user name: ");
            string userName = Console.ReadLine();

            bool pos = memberLogic.DeleteMember(userName);

            if (pos == true)
            {
                Console.WriteLine("Successful delet!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

            Console.ReadLine();
        }

        private static void MyMoney(IMemberLogic memberLogic)
        {
            var money = memberLogic.MyMoney();
            Console.WriteLine("Your budget: " + money.Max() + " USD");
            var btc = memberLogic.Btc();
            Console.WriteLine("Your budget: " + btc.Max() + " BTC");

            Console.ReadLine();
        }

        private static void Deposite(IMemberLogic memberLogic)
        {
            Console.WriteLine("Your username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Amount");
            double money = int.Parse(Console.ReadLine());

            memberLogic.Deposite(money, username);
        }

        private static void AllMemberNameAsString(IMemberLogic logic)
        {
            Console.WriteLine(logic.GetAllNameAsString());
            Console.ReadLine();
        }

        // Currency CRUD
        private static void AddNewCurrency(ICurrencyLogic currencyLogic)
        {
            Console.WriteLine("Please add the following : ");
            Console.WriteLine();

            Console.WriteLine("Add currency name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Add currency short name: ");
            string shortName = Console.ReadLine();

            Console.WriteLine("Add currency symbol: ");
            string symbol = Console.ReadLine();

            Console.WriteLine("Add currency nationality: ");
            string nationality = Console.ReadLine();

            currencyLogic.AddNewOne(name, shortName, nationality, symbol);
        }

        private static void DeleteCurrency(ICurrencyLogic currencyLogic)
        {
            Console.WriteLine("Add currency short name: ");
            string shortName = Console.ReadLine();

            bool pos = currencyLogic.DeleteCurrency(shortName);

            if (pos == true)
            {
                Console.WriteLine("Successful delet!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

            Console.ReadLine();
        }

        private static void UpdateCurrencyPrice(ICurrencyLogic currencyLogic)
        {
            currencyLogic.Refresh(currencyLogic);
        }

        private static void CurrencyValue(ICurrencyLogic currencyLogic)
        {
            var res = currencyLogic.CurrencyPrice();

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private static void AllCurrencyoNameAsString(ICurrencyLogic logic)
        {
            Console.WriteLine(logic.GetAllNameAsString());
            Console.ReadLine();
        }

        // Task
        private static void GetAllNameAsStringDoSomethingAsync(ICryptoLogic logic)
        {
            Task<string> task = logic.GetAllNameAsStringDoSomethingAsync();

            task.Start();
            task.ContinueWith(x =>
           {
               Console.WriteLine(task.Result);
           });
            Console.ReadLine();
        }

        // Designe
        private static void Welcome()
        {
            Console.WriteLine("\t \t╔╦╦╦═╦╗╔═╦═╦══╦═╗");
            Thread.Sleep(500);
            Console.WriteLine("\t \t║║║║╩╣╚╣═╣║║║║║╩╣");
            Thread.Sleep(500);
            Console.WriteLine("\t \t╚══╩═╩═╩═╩═╩╩╩╩═╝");
            Thread.Sleep(500);
        }

        /*private static bool Login()
        {
            bool result = false;
            Console.WriteLine("Username: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            string[] fajlsorai = File.ReadAllLines("users.txt");
            for (int i = 0; i < fajlsorai.Length; i++)
            {
                string[] splitteltSor = fajlsorai[i].Split(';'); // username;password
                for (int j = 0; j < splitteltSor.Length; j++)
                {
                    if (userName == splitteltSor[0] && password == splitteltSor[1])
                    {
                        result = true;
                    }
                }
            }

            if (result == true)
            {
                Console.WriteLine("Succesful login!");
            }
            else
            {
                Console.WriteLine("WRONG username and/or password!");
            }

            Console.ReadLine();
            return result;
        }*/
    }
}
