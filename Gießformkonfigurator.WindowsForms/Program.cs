//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms
{
#pragma warning disable SA1519 // Braces should not be omitted from multi-line child statement
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
        public static int Grenze { get; set; }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            List<MGießform> MultiMolds1 = new List<MGießform>();
            List<MGießform> MultiMoldsFinal = new List<MGießform>();

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

            // Grundplatte und Fuehrungsring matchen
            for (int i = 0; i < listGrundplatten.Count; i++)
            {
                for (int j = 0; j < listRinge.Count; j++)
                {
                    if (listGrundplatten[i].Kombiniere(listRinge[j]))
                    {
                        MultiMolds1.Add(new MGießform(listGrundplatten[i], listRinge[j], null, null));
                    }
                }
            }

            // Multimold mit Einlegeplatten kombinieren
            Grenze = MultiMolds1.Count;
            for (int i = 0; i < Grenze; i++)
            {
                if (MultiMolds1[i].Grundplatte.mit_Konusfuehrung)
                {
                    for (int j = 0; j < listEinlegeplatten.Count; j++)
                    {
                        if (MultiMolds1[i].Grundplatte.Kombiniere(listEinlegeplatten[j]))
                        {
                            MultiMolds1.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, listEinlegeplatten[j], null));
                        }
                    }
                }
            }

            // MultiMolds mit Kernen kombinieren
            Grenze = MultiMolds1.Count;
            for (int i = 0; i < Grenze; i++)
            {
                if (MultiMolds1[i].Einlegeplatte != null)
                {
                    // Einlegeplatten vom Typ-1 (Konusfuehrung) mit Innenring kombinieren
                    if (MultiMolds1[i].Einlegeplatte.mit_Konusfuehrung == true)
                    {
                        for (int j = 0; j < listKerne.Count; j++)
                        {
                            if (MultiMolds1[i].Einlegeplatte.Konus_Innen_Max > listKerne[j].Konus_Außen_Max
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Max - 5) < listKerne[j].Konus_Außen_Max
                            && MultiMolds1[i].Einlegeplatte.Konus_Innen_Min > listKerne[j].Konus_Außen_Min
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Min - 5) < listKerne[j].Konus_Außen_Min
                            && MultiMolds1[i].Einlegeplatte.Konus_Innen_Winkel > listKerne[j].Konus_Außen_Winkel
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Winkel - 5) < listKerne[j].Konus_Außen_Winkel)
                            {
                                MultiMoldsFinal.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, MultiMolds1[i].Einlegeplatte, listKerne[j]));
                            }
                        }
                    }

                    // Einlegeplatten vom Typ-2 (Stiftfuehrung) mit Innenkernen kombinieren
                    else if (MultiMolds1[i].Einlegeplatte.mit_Lochfuehrung == true)
                    {
                        for (int j = 0; j < listKerne.Count; j++)
                        {
                            // TODO: Kombinationsalgorithmus einfügen
                        }
                    }
                }
                // Grundplatten vom Typ-1 (Konusfuehrung) mit Innenkernen kombinieren
                else
                {
                    if (MultiMolds1[i].Grundplatte.mit_Konusfuehrung == true)
                    {
                        for (int j = 0; j < listKerne.Count; j++)
                        {
                            if (MultiMolds1[i].Grundplatte.Kombiniere(listKerne[j]))
                            {
                                MultiMoldsFinal.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, null, listKerne[j]));
                            }
                        }
                    }

                    // Grundplatten vom Typ-2 (Stiftfuehrung) mit Innenkernen kombinieren
                    else if (MultiMolds1[i].Grundplatte.mit_Lochfuehrung == true)
                    {
                        for (int j = 0; j < listKerne.Count; j++)
                        {
                            if (MultiMolds1[i].Grundplatte.Kombiniere(listKerne[j]))
                            {
                                MultiMoldsFinal.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, null, listKerne[j]));
                            }
                        }
                    }
                    else if (MultiMolds1[i].Grundplatte.mit_Kern == true)
                    {
                        MultiMoldsFinal.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, null, null));
                    }
                }
            }

            foreach (MGießform mGießform in MultiMoldsFinal)
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
        // GUI-Stuff
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new DBLogin_View());
        */
    }
}