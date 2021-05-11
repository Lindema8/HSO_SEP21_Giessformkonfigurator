//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Gießformkonfigurator.WindowsForms.DataAccess;
    using Gießformkonfigurator.WindowsForms.Main.Gießformen;

    /// <summary>
    /// Program Entry.
    /// </summary>
    public static class Program
    {
        public static int Pause;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Console.ReadLine();

            List<MGießform> MultiMolds = new List<MGießform>();

            List<Einlegeplatte> ep = new List<Einlegeplatte>();
            ep.Add(new Einlegeplatte(1, 110, 120, 50));
            ep.Add(new Einlegeplatte(2, 120, 130, 60));
            ep.Add(new Einlegeplatte(3, 90, 120, 25));
            ep.Add(new Einlegeplatte(4, 70, 80, 50));
            ep.Add(new Einlegeplatte(5, 60, 80, 40));

            List<Grundplatte> gp = new List<Grundplatte>();
            gp.Add(new Grundplatte(6, 111, 122, 51, 342, 347.89, 15, 11));
            gp.Add(new Grundplatte(7, 121, 131, 61, 430.11, 435.99, 15, 11));
            gp.Add(new Grundplatte(8, 121, 131, 61, 479.69, 485.58, 15, 11));
            gp.Add(new Grundplatte(9, 0.0, 0.0, 0.0, 529.69, 535.58, 15, 11));
            gp.Add(new Grundplatte(10, 61, 81, 41, 430.11, 435.99, 15, 11));

            List<Ring> fr = new List<Ring>();
            fr.Add(new Ring(21734) { konusMin = 342.21, konusMax = 345.43, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21899) { konusMin = 640, konusMax = 643.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21789) { konusMin = 430.3, konusMax = 433.52, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21831) { konusMin = 480, konusMax = 483.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21846) { konusMin = 530, konusMax = 533.22, konusWinkel = 15, konusHoehe = 6 });
            fr.Add(new Ring(21768) { konusMin = 430.3, konusMax = 433.52, konusWinkel = 15, konusHoehe = 6 });


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
                        MultiMolds.Add(new MGießform(gp[i], fr[j], null));
                    }
                }
            }

            Pause = MultiMolds.Count;
            for (int i = 0; i < Pause; i++)
            {
                if (MultiMolds[i].Konus_Innen_Max != 0.0 ||
                    MultiMolds[i].Konus_Innen_Min != 0.0 ||
                    MultiMolds[i].Konus_Innen_Winkel != 0.0)
                {
                    for (int j = 0; j < ep.Count; j++)
                    {
                        if (MultiMolds[i].Konus_Innen_Max > ep[j].Konus_Max &&
                            (MultiMolds[i].Konus_Innen_Max - 5) < ep[j].Konus_Max &&
                            MultiMolds[i].Konus_Innen_Min > ep[j].Konus_Min &&
                            (MultiMolds[i].Konus_Innen_Min - 5) < ep[j].Konus_Min &&
                            MultiMolds[i].Konus_Innen_Winkel > ep[i].Konus_Winkel &&
                            (MultiMolds[i].Konus_Innen_Winkel - 5) < ep[j].Konus_Winkel)
                        {
                            MultiMolds.Add(new MGießform(MultiMolds[i].grundplatte, MultiMolds[i].führungsring, ep[j]));
                        }

                    }

                }

            }
            // GUI-Stuff
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DBLogin_View());*/
        }
    }
}
