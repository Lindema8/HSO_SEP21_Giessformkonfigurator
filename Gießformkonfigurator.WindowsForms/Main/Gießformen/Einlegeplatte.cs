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
        public Double Konus_Min { get; set; }
        public Double Konus_Max { get; set; }
        public Double Konus_Winkel { get; set; }

        public Einlegeplatte(int ID, Double KoMi, Double KoMa, Double KoWi)
        {
            SAP = ID;
            Konus_Min = KoMi;
            Konus_Max = KoMa;
            Konus_Winkel = KoWi;
        }
    }
}
