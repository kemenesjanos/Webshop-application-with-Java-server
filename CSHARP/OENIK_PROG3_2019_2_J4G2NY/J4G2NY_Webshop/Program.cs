// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Webshop.Data;
    using Webshop.Logic;

    /// <summary>
    /// The MainProgram.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">args.</param>
        public static void Main()
        {
            Logic logic = new Logic();
            string v;
            do
            {
                Console.Clear();
                Console.WriteLine("Mit szeretne tenni ? \n");
                Console.WriteLine("L: Kilistázni \nH: Hozzáadni \nT: Törölni \nM: Módosítani ");
                Console.WriteLine("U: Vásárlások, ahol ugyanabban az országban lakik a vevő és az eladó");
                Console.WriteLine("N: Azok a felhasználók akik nem voltak még se vevők, se eladók");
                Console.WriteLine("Q: Azok a felhasználók akik eddig csak vásároltak");
                Console.WriteLine("W: Azok a felhasználók akik eddig csak eladtak");
                Console.WriteLine("V: A megadott országban mennyi a vásárolt termékek átlaga");
                Console.WriteLine("K: A megadott korosztályok közül melyik kategóriára költöttek a legtöbbet");
                Console.WriteLine("R: Részesedési mutató kérése egy termékre");
                Console.WriteLine("X: Kilépés");
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
                                    }
                                    while (!er);

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
                                    }
                                    while (!er);
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
                                    }
                                    while (!er);
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
                                            Console.WriteLine("Az adattag törlése sikeres volt.");
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
                                    }
                                    while (!er);
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

                                        er = logic.DeleteSale(id);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && er)
                                        {
                                            Console.WriteLine("Az adattag törlése sikeres volt.");
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
                                    }
                                    while (!er);
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

                                        er = logic.DeleteLocation(id);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && er)
                                        {
                                            Console.WriteLine("Az adattag törlése sikeres volt.");
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
                                    }
                                    while (!er);
                                }

                                break;
                            case "m":
                                if (t == "u")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");

                                        Console.WriteLine("Módosítandó id");
                                        decimal mid;
                                        bool a6 = decimal.TryParse(Console.ReadLine(), out mid);
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

                                        User u = new User() { ID = id, FullName = fullname, Email = email, Phone_Number = phone, Birth_Date = date, Registration_Date = date2, Location_ID = locid };

                                        er = logic.UpdateUser(mid, u);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && a4 && a5 && a6 && er)
                                        {
                                            Console.WriteLine("Az adat módosítása sikeres volt.");
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
                                    }
                                    while (!er);
                                }
                                else if (t == "s")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("Módosítandó id");
                                        decimal mid;
                                        bool a7 = decimal.TryParse(Console.ReadLine(), out mid);
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

                                        Sale s = new Sale() { ID = id, Transaction_Date = tdate, Product_Name = prodname, Price = price, Category = cat, Shipping_Cost = shc, Seller_ID = sid, Buyer_ID = bid };

                                        er = logic.UpdateSale(mid, s);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && a4 && a5 && a6 && a7 && er)
                                        {
                                            Console.WriteLine("Az adat módosítása sikeres volt.");
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
                                    }
                                    while (!er);
                                }
                                else if (t == "l")
                                {
                                    bool er;

                                    do
                                    {
                                        Console.WriteLine("Írja be az adatokat!");
                                        Console.WriteLine("Módosítandó id");
                                        decimal mid;
                                        bool a4 = decimal.TryParse(Console.ReadLine(), out mid);
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

                                        Loc l = new Loc() { ID = id, Country = country, Street = street, House_Number = hnum, Zip_Code = zcode };

                                        er = logic.UpdateLocation(mid, l);

                                        DBHandler.Instance.Dispose();

                                        if (a1 && a2 && a3 && a4 && er)
                                        {
                                            Console.WriteLine("Az adat módosítása sikeres volt.");
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
                                    }
                                    while (!er);
                                }

                                break;

                            default:
                                break;
                        }
                    }
                }
                else if (v == "u")
                {
                    Display(
                        logic.SelectSalesWhereTheSellerAndTheBuyerInTheSameCountry(),
                        "Vásárlások, ahol ugyanabban az országban lakik a vevő és az eladó:");
                }
                else if (v == "n")
                {
                    Display(logic.SelectUsersWhereIsNoSale(), "Azok a felhasználók akik nem voltak még se vevők, se eladók:");
                }
                else if (v == "q")
                {
                    Display(logic.SelectUsersWhereTheyAreOnlyBuyers(), "Azok a felhasználók akik eddig csak vásároltak:");
                }
                else if (v == "w")
                {
                    Display(logic.SelectUsersWhereTheyAreOnlySellers(), "Azok a felhasználók akik eddig csak eladtak:");
                }
                else if (v == "v")
                {
                    Console.WriteLine("Adja meg az ország nevét:");
                    int avg = logic.HowMuchThePeopleOfThisCountrySpentAvg(Console.ReadLine());
                    if (avg == -1)
                    {
                        Console.WriteLine("Nem lakik ilyen nevű országban felhasználó.");
                    }
                    else
                    {
                        Console.WriteLine(avg + "- et költenek átlagosan ebben az országban.");
                    }
                }
                else if (v == "k")
                {
                    Console.WriteLine("Adja meg az alábbi adatokat:");
                    Console.WriteLine("A korosztály alsó határa: ");
                    string min = Console.ReadLine();
                    Console.WriteLine("A korosztály felső határa: ");
                    string max = Console.ReadLine();
                    if (int.TryParse(min, out int minage) && int.TryParse(max, out int maxage))
                    {
                        Console.WriteLine(logic.WhichCategoryPeopleInThisAgeGroupSpentTheMost(minage, maxage));
                    }
                    else
                    {
                        Console.WriteLine("Hibás adatok.");
                    }
                }
                else if (v == "r")
                {
                    Console.WriteLine("Írjon be egy árat:");
                    int price;
                    bool e = int.TryParse(Console.ReadLine(), out price);
                    if (e && price >= 0)
                    {
                        int er = logic.ShareholdingRequestJava(price);
                        if (er != -1)
                        {
                            Console.WriteLine("Az ajánlott részesedési összeg: " + er);
                        }
                        else
                        {
                            Console.WriteLine("Hiba adódott a java szerverrel.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hibás adat.");
                    }
                }

                if ("lhtmunqwvkr".Contains(v))
                {
                    Console.ReadKey();
                }

                Console.Clear();
            }
            while (v != "x");
        }

        /// <summary>
        /// Display some result.
        /// </summary>
        /// <typeparam name="T">Type of the object for display.</typeparam>
        /// <param name="list">Results.</param>
        /// <param name="description">Description.</param>
        public static void Display<T>(IEnumerable<T> list, string description)
        {
            Console.Clear();
            Console.WriteLine(description);
            Console.WriteLine();
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
        }
    }
}
