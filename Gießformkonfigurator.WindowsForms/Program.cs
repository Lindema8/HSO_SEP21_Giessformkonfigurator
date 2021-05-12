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
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Gießformkonfigurator.WindowsForms.Main.DatabaseModel;

    /// <summary>
    /// Program Entry.
    /// </summary>
    public static class Program
    {
        public static int Pause { get; set; }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        //[STAThread]
        public static void Main()
        {
            /*List<MGießform> MultiMolds1 = new List<MGießform>();
            List<MGießform> MultiMolds2 = new List<MGießform>();

            List<Einlegeplatte> ep = new List<Einlegeplatte>();
            ep.Add(new Einlegeplatte(1, "Typ-1", 110, 120, 50, 70, 80, 50));
            ep.Add(new Einlegeplatte(2, "Typ-1", 120, 130, 60, 110, 120, 50));
            ep.Add(new Einlegeplatte(3, "Typ-1", 90, 120, 25, 70, 80, 50));
            ep.Add(new Einlegeplatte(4, "Typ-1", 70, 80, 50, 110, 120, 50));
            ep.Add(new Einlegeplatte(5, "Typ-1", 60, 80, 40, 110, 120, 50));

            List<Grundplatte> gp = new List<Grundplatte>();
            gp.Add(new Grundplatte(6, "Typ-1", 111, 122, 51, 342, 347.89, 15, 11, 15));
            gp.Add(new Grundplatte(7, "Typ-1", 121, 131, 61, 430.11, 435.99, 15, 11, 16));
            gp.Add(new Grundplatte(8, "Typ-1", 121, 131, 61, 479.69, 485.58, 15, 11, 17));
            gp.Add(new Grundplatte(9, "Typ-2", 0.0, 0.0, 0.0, 529.69, 535.58, 15, 11, 18));
            gp.Add(new Grundplatte(10, "Typ-1", 61, 81, 41, 430.11, 435.99, 15, 11, 0.0));

            List<Ring> fr = new List<Ring>();
            fr.Add(new Ring(21734) { konusMin = 342.21, konusMax = 345.43, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21899) { konusMin = 640, konusMax = 643.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21789) { konusMin = 430.3, konusMax = 433.52, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21831) { konusMin = 480, konusMax = 483.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21846) { konusMin = 530, konusMax = 533.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21768) { konusMin = 430.3, konusMax = 433.52, konusWinkel = 15, konusHoehe = 6 });

            List<Kern> kerne = new List<Kern>();
            kerne.Add(new Kern(21728, "Typ-1", 41.4, 40.6, 79, 69, 49, 15, 15, 25.6));
            kerne.Add(new Kern(21725, "Typ-1", 41.4, 40.6, 0, 0, 0, 15, 15, 25.6));
            kerne.Add(new Kern(42640, "Typ-2", 409, 52, 350, 344.11, 15, 15, 18, 41));

            // Grundplatte und Fuehrungsring matchen
            for (int i = 0; i < gp.Count; i++)
            {
                for (int j = 0; j < fr.Count; j++)
                {
                    if (fr[j].konusMin > gp[i].Konus_Außen_Min
                        && fr[j].konusMin < gp[i].Konus_Außen_Max
                        && fr[j].konusWinkel == gp[i].Konus_Außen_Winkel
                        && fr[j].konusHoehe < gp[i].Konus_Außen_Höhe
                        && fr[j].konusMax < gp[i].Konus_Außen_Max)
                    {
                        MultiMolds1.Add(new MGießform(gp[i], fr[j], null, null));
                    }
                }
            }

            // Multimold mit Einlegeplatten kombinieren
            Pause = MultiMolds1.Count;
            for (int i = 0; i < Pause; i++)
            {
                if (MultiMolds1[i].Grundplatte.Konus_Innen_Max != 0.0 ||
                    MultiMolds1[i].Grundplatte.Konus_Innen_Min != 0.0 ||
                    MultiMolds1[i].Grundplatte.Konus_Innen_Winkel != 0.0)
                {
                    for (int j = 0; j < ep.Count; j++)
                    {
                        if (MultiMolds1[i].Grundplatte.Konus_Innen_Max > ep[j].Konus_Außen_Max &&
                            (MultiMolds1[i].Grundplatte.Konus_Innen_Max - 5) < ep[j].Konus_Außen_Max &&
                            MultiMolds1[i].Grundplatte.Konus_Innen_Min > ep[j].Konus_Außen_Min &&
                            (MultiMolds1[i].Grundplatte.Konus_Innen_Min - 5) < ep[j].Konus_Außen_Min &&
                            MultiMolds1[i].Grundplatte.Konus_Innen_Winkel > ep[j].Konus_Außen_Winkel &&
                            (MultiMolds1[i].Grundplatte.Konus_Innen_Winkel - 5) < ep[j].Konus_Außen_Winkel)
                        {
                            MultiMolds1.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, ep[j], null));
                        }

                    }

                }

            }

            // MultiMolds mit Kernen kombinieren
            for (int i = 0; i < MultiMolds1.Count; i++)
            {
                if (MultiMolds1[i].Grundplatte.Typ == "Typ-1")
                {

                    // Einlegeplatten vom Typ-1 (Konusfuehrung) mit Innenkernen kombinieren
                    if (MultiMolds1[i].Einlegeplatte != null
                        && MultiMolds1[i].Einlegeplatte.Typ == "Typ-1")
                    {
                        for (int j = 0; j < kerne.Count; j++)
                        {
                            if (MultiMolds1[i].Einlegeplatte.Konus_Innen_Max > kerne[j].Konus_Max
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Max - 5) < kerne[j].Konus_Max
                            && MultiMolds1[i].Einlegeplatte.Konus_Innen_Min > kerne[j].Konus_Min
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Min - 5) < kerne[j].Konus_Min
                            && MultiMolds1[i].Einlegeplatte.Konus_Innen_Winkel > kerne[j].Konus_Winkel
                            && (MultiMolds1[i].Einlegeplatte.Konus_Innen_Winkel - 5) < kerne[j].Konus_Winkel)
                            {
                                MultiMolds2.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, MultiMolds1[i].Einlegeplatte, kerne[j]));
                            }
                        }
                    }

                    // Einlegeplatten vom Typ-2 (Stiftfuehrung) mit Innenkernen kombinieren
                    else if (MultiMolds1[i].Einlegeplatte != null
                    && MultiMolds1[i].Einlegeplatte.Typ == "Typ-2")
                    {
                        for (int j = 0; j < kerne.Count; j++)
                        {
                            // TODO: Kombinationsalgorithmus einfügen
                        }
                    }

                    // Grundplatten vom Typ-1 (Konusfuehrung) mit Innenkernen kombinieren
                    else if (MultiMolds1[i].Einlegeplatte == null)
                    {
                        for (int j = 0; j < kerne.Count; j++)
                        {
                            if (MultiMolds1[i].Grundplatte.Konus_Innen_Max > kerne[j].Konus_Max
                            && (MultiMolds1[i].Grundplatte.Konus_Innen_Max - 5) < kerne[j].Konus_Max
                            && MultiMolds1[i].Grundplatte.Konus_Innen_Min > kerne[j].Konus_Min
                            && (MultiMolds1[i].Grundplatte.Konus_Innen_Min - 5) < kerne[j].Konus_Min
                            && MultiMolds1[i].Grundplatte.Konus_Innen_Winkel > kerne[i].Konus_Winkel
                            && (MultiMolds1[i].Grundplatte.Konus_Innen_Winkel - 5) < kerne[j].Konus_Winkel)
                            {
                                MultiMolds2.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, null, kerne[j]));
                            }
                        }
                    }
                }

                // Grundplatten vom Typ-2 (Stiftfuehrung) mit Innenkernen kombinieren
                else if (MultiMolds1[i].Grundplatte.Typ == "Typ-2")
                {
                    for (int j = 0; j < kerne.Count; j++)
                    {
                        if (MultiMolds1[i].Grundplatte.Innendurchmesser == kerne[j].Durchmesser_Fuehrung)
                        {
                            MultiMolds2.Add(new MGießform(MultiMolds1[i].Grundplatte, MultiMolds1[i].Fuehrungsring, null, kerne[j]));
                        }
                    }
                }
            }

            foreach (MGießform mGießform in MultiMolds2)
            {
                Console.WriteLine(MultiMolds1.ToString());
                Console.WriteLine(mGießform.Grundplatte.printSAP());
                Console.WriteLine(mGießform.Einlegeplatte.printSAP());
                Console.WriteLine(mGießform.Fuehrungsring.printSAP());
                Console.WriteLine(mGießform.Innenkern.printSAP());
            }

            using (var db = new DatabaseModel())
            {
                var grundpl = new Grundplatte()
                {
                    SAP_Nr_ = 12321,
                    Bezeichnung_RoCon = "Testgrundplatte0815",
                    Außendurchmesser = 32,
                    d

                }
                db.Grundplatten.Add(gp);

            }

            Console.ReadLine();
        }*/
            using (var db = new GießformDB())
            {
                /*var gp = new Grundplatte()
                {
                    SAP_Nr_ = 23412,
                    Bezeichnung_RoCon = "Testplatte",
                    Außendurchmesser = 500,
                    Innendurchmesser = 20,
                    Hoehe = 15,
                    Konus_Außen_Max = 480,
                    Konus_Außen_Min = 470,
                    Konus_Außen_Winkel = 45,
                    Konus_Hoehe = 10,
                    mit_Konusfuehrung = true,
                    Konus_Innen_Max = 55,
                    Konus_Innen_Min = 50,
                    Konus_Innen_Winkel = 45,
                    mit_Kern = false,
                    mit_Lochfuehrung = false
                };

                db.Grundplatten.Add(gp);
                db.SaveChanges();
                Console.WriteLine("Added Baseplate!");*/

                foreach (var baseplate in db.Grundplatten)
                {
                    Console.WriteLine("SAP-Nr.: {0}, Bezeichnung_RoCon: {1}", baseplate.SAP_Nr_, baseplate.Bezeichnung_RoCon);
                }
                Console.ReadLine();

                foreach (var baseplate in db.Grundplatten)
                {
                    Console.WriteLine("SAP-Nr.: {0}, Bezeichnung_RoCon: {1}", baseplate.SAP_Nr_, baseplate.Bezeichnung_RoCon);
                }
                Console.ReadLine();

                foreach (var baseplate in db.Grundplatten)
                {
                    Console.WriteLine("SAP-Nr.: {0}, Bezeichnung_RoCon: {1}", baseplate.SAP_Nr_, baseplate.Bezeichnung_RoCon);
                }
                Console.ReadLine();
            }
        }

        // GUI-Stuff
        /*Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new DBLogin_View());*/
    }
}