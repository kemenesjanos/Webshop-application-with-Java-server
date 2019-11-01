// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static void Main(string[] args)
        {
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
                v = Console.ReadLine();
                Console.Clear();
                if (v == "l" || v == "h" || v == "t" || v == "m")
                {
                    Console.WriteLine("Melyik táblával?\n");
                    Console.WriteLine("U: Users \nS: Sales \nL: Loc");
                    string t = Console.ReadLine();
                    Console.Clear();
                }

                if (v != "x")
                {
                    Console.WriteLine("Ez még nincs kész");
                }

                Console.ReadKey();
            }
            while (v != "x");
        }
    }
}
