//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms
{
#pragma warning disable SA1519 // Braces should not be omitted from multi-line child statement
#pragma warning disable SA1623 // Property summary documentation should match accessors
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Gießformkonfigurator.WindowsForms.Main.Db_components;
    using Gießformkonfigurator.WindowsForms.Main.Db_molds;
    using Gießformkonfigurator.WindowsForms.Main.Db_products;

    /// <summary>
    /// Program Entry.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Speichert den aktuellen Listenindex.
        /// </summary>
        public static int Index { get; set; }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Listen, welche zur Zwischenspeicherung der mehrteiligen Gießformen genutzt werden, bevor sie vervollständigt wurden und ausgegeben werden können.
            List<MGießform> mGießformenFinal = new List<MGießform>();

            CombinationJob co = new CombinationJob(null);
            //co.FiltereDiscDB();
            co.ArraysTestData();
            mGießformenFinal = co.KombiniereMGießformen();

            foreach (MGießform mGießform in mGießformenFinal)
            {
                Console.Write(mGießform.Grundplatte?.Bezeichnung_RoCon + " + ");
                Console.Write(mGießform.Einlegeplatte?.Bezeichnung_RoCon + " + ");
                Console.Write(mGießform.Fuehrungsring?.Bezeichnung_RoCon + " + ");
                Console.WriteLine(mGießform.Innenkern?.Bezeichnung_RoCon);
            }

            Console.Write("Am Ende");
            Console.ReadLine();

            // fillDatabase();
        }

        /*
        // GUI-Quellcode
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new DBLogin_View());
        */

    }
}