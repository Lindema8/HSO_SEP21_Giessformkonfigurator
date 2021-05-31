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
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gießformkonfigurator.WindowsForms.Main.Gießformen;

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
            List<MGießform> mGießformenTemp = new List<MGießform>();
            List<MGießform> mGießformenFinal = new List<MGießform>();

            KombinationsObjekt co = new KombinationsObjekt(null);
            co.FiltereDiscDB();
            mGießformenFinal = co.KombiniereMGießformen();
            /*
            // TODO: Filterung der DB einbinden
            List<Grundplatte> listGrundplatten = new List<Grundplatte>();
            List<Ring> listRinge = new List<Ring>();
            List<Einlegeplatte> listEinlegeplatten = new List<Einlegeplatte>();
            List<Kern> listKerne = new List<Kern>();
            List<Lochkreis> listLochkreise = new List<Lochkreis>();
            List<Bolzen> listBolzen = new List<Bolzen>();

            using (var db = new GießformDBContext())
            {
                foreach (var grundplatte in db.Grundplatten)
                {
                    listGrundplatten.Add(grundplatte);
                }

                foreach (var ring in db.Ringe)
                {
                    listRinge.Add(ring);
                }

                foreach (var einlegeplatte in db.Einlegeplatten)
                {
                    listEinlegeplatten.Add(einlegeplatte);
                }

                foreach (var innenkern in db.Innenkerne)
                {
                    listKerne.Add(innenkern);
                }

                foreach (var lochkreis in db.Lochkreise)
                {
                    listLochkreise.Add(lochkreis);
                }

                foreach (var bolzen in db.Bolzen)
                {
                    listBolzen.Add(bolzen);
                }
            }

            // Grundplatten mit den vorhandenen Fuehrungsringen kombinieren.
            for (int iGP = 0; iGP < listGrundplatten.Count; iGP++)
            {
                for (int iRinge = 0; iRinge < listRinge.Count; iRinge++)
                {
                    if (listGrundplatten[iGP].Kombiniere(listRinge[iRinge]))
                    {
                        mGießformenTemp.Add(new MGießform(listGrundplatten[iGP], listRinge[iRinge], null, null));
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Einlegeplatten kombinieren.
            Index = mGießformenTemp.Count;
            for (int iTemp = 0; iTemp < Index; iTemp++)
            {
                if (mGießformenTemp[iTemp].Grundplatte.Mit_Konusfuehrung)
                {
                    for (int iEP = 0; iEP < listEinlegeplatten.Count; iEP++)
                    {
                        if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listEinlegeplatten[iEP]))
                        {
                            mGießformenTemp.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, listEinlegeplatten[iEP], null));
                        }
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Kernen kombinieren.
            Index = mGießformenTemp.Count;
            for (int iTemp = 0; iTemp < Index; iTemp++)
            {
                if (mGießformenTemp[iTemp].Einlegeplatte != null)
                {
                    // Einlegeplatten mit Konusfuehrung mit Kernen kombinieren.
                    if (mGießformenTemp[iTemp].Einlegeplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Einlegeplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, mGießformenTemp[iTemp].Einlegeplatte, listKerne[iKerne]));
                            }
                        }
                    }

                    // Einlegeplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp[iTemp].Einlegeplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Einlegeplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, mGießformenTemp[iTemp].Einlegeplatte, listKerne[iKerne]));
                            }
                        }
                    }
                }

                // Grundplatten mit Konusfuehrung mit Kernen kombinieren.
                else
                {
                    if (mGießformenTemp[iTemp].Grundplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, listKerne[iKerne]));
                            }
                        }
                    }

                    // Grundplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp[iTemp].Grundplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, listKerne[iKerne]));
                            }
                        }
                    }
                    else if (mGießformenTemp[iTemp].Grundplatte.Mit_Kern == true)
                    {
                        mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, null));
                    }
                }
            }
            */
            // Ausgabe:
            foreach (MGießform mGießform in mGießformenFinal)
            {
                Console.Write(mGießform.ToString() + ": ");
                Console.Write(mGießform.Grundplatte?.Bezeichnung_RoCon + ", ");
                Console.Write(mGießform.Einlegeplatte?.Bezeichnung_RoCon + ", ");
                Console.Write(mGießform.Fuehrungsring?.Bezeichnung_RoCon + ", ");
                Console.WriteLine(mGießform.Innenkern?.Bezeichnung_RoCon);
            }

            Console.Write("Am Ende");
            Console.ReadLine();
        }

        /*
        // GUI-Quellcode
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new DBLogin_View());
        */

    }
}