//-----------------------------------------------------------------------
// <copyright file="MGießform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    using System;
    public class MGießform : Gießform
    {
        public Grundplatte grundplatte { get; set; }
        public Ring führungsring { get; set; }
        public Einlegeplatte einlegeplatte { get; set; }
        public Double Konus_Innen_Min { get; set; }
        public Double Konus_Innen_Max { get; set; }
        public Double Konus_Innen_Winkel { get; set; }


        public MGießform(Grundplatte gp, Ring fr, Einlegeplatte ep)
        {
            grundplatte = gp;
            führungsring = fr;
            einlegeplatte = ep;

            if (einlegeplatte == null)
            {
                Konus_Innen_Min = grundplatte.Konus_Innen_Min;
                Konus_Innen_Max = grundplatte.Konus_Innen_Max;
                Konus_Innen_Winkel = grundplatte.Konus_Innen_Winkel;
            }
            else
            {
                Konus_Innen_Min = einlegeplatte.Konus_Min;
                Konus_Innen_Max = einlegeplatte.Konus_Max;
                Konus_Innen_Winkel = einlegeplatte.Konus_Winkel;
            }
        }
    }
}
