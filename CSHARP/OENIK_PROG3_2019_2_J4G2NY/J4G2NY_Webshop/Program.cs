// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Data;
using Webshop.Logic;

namespace Program
{
    /// <summary>
    /// The MainProgram.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main(string[] args)
        {
            Logic logic = new Logic();
            string v;
            do
            {
                Console.Clear();
                Console.WriteLine("Mit szeretne tenni ? \n");
                Console.WriteLine("L: kilistázni \nH: hozzáadni \nT: törölni \nM: módosítani ");
                Console.WriteLine("U: Ugyanabban a városban lakik a vevő és az eladó");
                Console.WriteLine("V: Városokban mennyi a vásárolt termékek átlaga");
                Console.WriteLine("K: az egyes korosztályok melyik kategóriákra költöttek a legtöbbet");
                Console.WriteLine("R: részesedési mutató kérése egy termékre");
                Console.WriteLine("X: kilépni");
                v = Console.ReadLine().ToLower();
                Console.Clear();
                string t;

                if (v == "l" || v == "h" || v == "t" || v == "m")
                {
                    Console.WriteLine("Melyik táblával?\n");
                    Console.WriteLine("U: Users \nS: Sales \nL: Loc");
                    t = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (t.Length == 1)
                    {
                        switch (v)
                        {
                            case "l":
                                if (t == "u")
                                {
                                    List<User> list = logic.GetAllUsers().ToList();
                                    foreach (User item in list)
                                    {
                                        Console.WriteLine(item.FullName);
                                    }

                                    DBHandler.Instance.Dispose();
                                }
                                else if (t == "s")
                                {
                                    List<Sale> list = logic.GetAllSales().ToList();
                                    foreach (Sale item in list)
                                    {
                                        Console.WriteLine(item.Product_Name);
                                    }

                                    DBHandler.Instance.Dispose();
                                }
                                else if (t == "l")
                                {
                                    List<Loc> list = logic.GetAllLocations().ToList();
                                    foreach (Loc item in list)
                                    {
                                        Console.WriteLine(item.Country + " " + item.Street + " " + item.House_Number);
                                    }

                                    DBHandler.Instance.Dispose();
                                }

                                break;
                            case "h":
                                if (t == "u")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("ID:");
                                        decimal id;
                                        bool a1 = decimal.TryParse(Console.ReadLine(), out id);
                                        Console.WriteLine("Full name:");
                                        string fullname = Console.ReadLine();
                                        Console.WriteLine("email:");
                                        string email = Console.ReadLine();
                                        Console.WriteLine("Phone number:");
                                        decimal phone;
                                        bool a2 = decimal.TryParse(Console.ReadLine(), out phone);
                                        Console.WriteLine("Birth Date: YYYY.MM.DD");
                                        DateTime date;
                                        bool a3 = DateTime.TryParse(Console.ReadLine(), out date);
                                        Console.WriteLine("Registration date: YYYY.MM.DD");
                                        DateTime date2;
                                        bool a4 = DateTime.TryParse(Console.ReadLine(), out date2);
                                        Console.WriteLine("location id:");
                                        decimal locid;
                                        bool a5 = decimal.TryParse(Console.ReadLine(), out locid);

                                        er = logic.InsertUsersData(id, fullname, email, phone, date, date2, locid);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && a4 && a5 && er)
                                        {
                                            Console.WriteLine("Az adat felvétele sikeres volt.");
                                        }
                                        else
                                        {
                                            er = false;
                                            Console.WriteLine("Az adatok nem helyesek. Szeretné mégegyszer megpróbálni ? y/n");
                                            if (Console.ReadLine().ToLower() == "n")
                                            {
                                                er = true;
                                            }
                                        }
                                    } while (!er);

                                    Console.WriteLine();
                                }
                                else if (t == "s")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("ID:");
                                        decimal id;
                                        bool a1 = decimal.TryParse(Console.ReadLine(), out id);
                                        Console.WriteLine("Transaction date: YYYY.MM.DD");
                                        DateTime tdate;
                                        bool a2 = DateTime.TryParse(Console.ReadLine(), out tdate);
                                        Console.WriteLine("Product name:");
                                        string prodname = Console.ReadLine();
                                        Console.WriteLine("Price:");
                                        decimal price;
                                        bool a3 = decimal.TryParse(Console.ReadLine(), out price);
                                        Console.WriteLine("Category:");
                                        string cat = Console.ReadLine();
                                        Console.WriteLine("Shipping cost:");
                                        decimal shc;
                                        bool a4 = decimal.TryParse(Console.ReadLine(), out shc);
                                        Console.WriteLine("Seller id:");
                                        decimal sid;
                                        bool a5 = decimal.TryParse(Console.ReadLine(), out sid);
                                        Console.WriteLine("Buyer id:");
                                        decimal bid;
                                        bool a6 = decimal.TryParse(Console.ReadLine(), out bid);

                                        er = logic.InsertSalesData(id, tdate, prodname, price, cat, shc, sid, bid);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && a4 && a5 && a6 && er)
                                        {
                                            Console.WriteLine("Az adat felvétele sikeres volt.");
                                        }
                                        else
                                        {
                                            er = false;
                                            Console.WriteLine("Az adatok nem helyesek. Szeretné mégegyszer megpróbálni ? y/n");
                                            if (Console.ReadLine().ToLower() == "n")
                                            {
                                                er = true;
                                            }
                                        }
                                    } while (!er);
                                }
                                else if (t == "l")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("ID:");
                                        decimal id;
                                        bool a1 = decimal.TryParse(Console.ReadLine(), out id);
                                        Console.WriteLine("Country:");
                                        string country = Console.ReadLine();
                                        Console.WriteLine("Street:");
                                        string street = Console.ReadLine();
                                        Console.WriteLine("House number:");
                                        decimal hnum;
                                        bool a2 = decimal.TryParse(Console.ReadLine(), out hnum);
                                        Console.WriteLine("Zip code:");
                                        decimal zcode;
                                        bool a3 = decimal.TryParse(Console.ReadLine(), out zcode);

                                        er = logic.InsertLocationData(id, country, street, hnum, zcode);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && er)
                                        {
                                            Console.WriteLine("Az adat felvétele sikeres volt.");
                                        }
                                        else
                                        {
                                            er = false;
                                            Console.WriteLine("Az adatok nem helyesek. Szeretné mégegyszer megpróbálni ? y/n");
                                            if (Console.ReadLine().ToLower() == "n")
                                            {
                                                er = true;
                                            }
                                        }
                                    } while (!er);
                                }

                                break;
                            case "t":
                                if (t == "u")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("ID:");
                                        decimal id;
                                        bool a1 = decimal.TryParse(Console.ReadLine(), out id);

                                        er = logic.DeleteUser(id);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && er)
                                        {
                                            Console.WriteLine("Az adat felvétele sikeres volt.");
                                        }
                                        else
                                        {
                                            er = false;
                                            Console.WriteLine("Az adatok nem helyesek. Szeretné mégegyszer megpróbálni ? y/n");
                                            if (Console.ReadLine().ToLower() == "n")
                                            {
                                                er = true;
                                            }
                                        }
                                    } while (!er);
                                }
                                else if (t == "s")
                                {

                                }
                                else if (t == "l")
                                {

                                }

                                break;
                            case "m":
                                if (t == "u")
                                {

                                }
                                else if (t == "s")
                                {

                                }
                                else if (t == "l")
                                {

                                }

                                break;

                            default:
                                break;
                        }
                    }
                }
                else if (v == "u")
                {
                    Console.WriteLine("Ez még nincs kész");
                }
                else if (v == "v")
                {
                    Console.WriteLine("Ez még nincs kész");
                }
                else if (v == "k")
                {
                    Console.WriteLine("Ez még nincs kész");
                }
                else if (v == "r")
                {
                    Console.WriteLine("Ez még nincs kész");
                }

                if (v != "x")
                {
                    Console.ReadKey();
                }

                Console.Clear();
            }
            while (v != "x");
        }
    }
}
