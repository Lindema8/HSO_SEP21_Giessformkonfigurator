﻿//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms
{
    using System;
    using System.Windows.Forms;
    using Gießformkonfigurator.WindowsForms.DataAccess;

    /// <summary>
    /// Program Entry.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            /*string server, name;
            Console.WriteLine("Bitte Server-IP eingeben:");
            server = Console.ReadLine();
            Console.WriteLine("Bitte Anmeldename eingeben:");
            name = Console.ReadLine();*/

            DBConnectionConsole gießformDB = new DBConnectionConsole();
            gießformDB.EstablishConnection();
            if (gießformDB.CheckConnection())
            {
                gießformDB.GetAllDataFromTable("Komponente.Grundplatte");
            }

            Console.ReadLine();

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DBLogin_View());*/
        }
    }
}
