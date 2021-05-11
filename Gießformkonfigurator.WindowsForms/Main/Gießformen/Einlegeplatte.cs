//-----------------------------------------------------------------------
// <copyright file="Einlegeplatte.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    using System;
    public class Einlegeplatte : Komponente
    {
        public Double Konus_Außen_Min { get; set; }
        public Double Konus_Außen_Max { get; set; }
        public Double Konus_Außen_Winkel { get; set; }
        public Double Konus_Innen_Min { get; set; }
        public Double Konus_Innen_Max { get; set; }
        public Double Konus_Innen_Winkel { get; set; }

        public Einlegeplatte(int ID, string typ, Double KoAMi, Double KoAMa, Double KoAWi, Double KoIMi, Double KoIMa, Double KoIWi)
        {
            SAPNr = ID;
            Typ = typ;
            Konus_Außen_Min = KoAMi;
            Konus_Außen_Max = KoAMa;
            Konus_Außen_Winkel = KoAWi;
            Konus_Innen_Min = KoIMi;
            Konus_Innen_Max = KoIMa;
            Konus_Innen_Winkel = KoIWi;
        }
    }
}
