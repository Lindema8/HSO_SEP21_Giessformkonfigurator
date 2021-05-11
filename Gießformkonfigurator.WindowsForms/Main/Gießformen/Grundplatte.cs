//-----------------------------------------------------------------------
// <copyright file="Grundplatte.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    using System;
    public class Grundplatte : Komponente
    {
        public Double Konus_Innen_Min { get; set; }

        public Double Konus_Innen_Max { get; set; }

        public Double Konus_Innen_Winkel { get; set; }

        public Double Konus_Außen_Min { get; set; }

        public Double Konus_Außen_Max { get; set; }

        public Double Konus_Außen_Winkel { get; set; }

        public Double Konus_Außen_Höhe { get; set; }

        public Double Innendurchmesser { get; set; }

        public Grundplatte(int ID, string typ, Double KoInMi, Double KoInMa, Double KoInWi, Double KoAuMi, Double KoAuMa, Double KoAuWi, Double KoAuHö, Double InD)
        {
            SAPNr = ID;
            Typ = typ;
            Konus_Innen_Min = KoInMi;
            Konus_Innen_Max = KoInMa;
            Konus_Innen_Winkel = KoInWi;
            Konus_Außen_Min = KoAuMi;
            Konus_Außen_Max = KoAuMa;
            Konus_Außen_Winkel = KoAuWi;
            Konus_Außen_Höhe = KoAuHö;
            Innendurchmesser = InD;

        }
    }
}
