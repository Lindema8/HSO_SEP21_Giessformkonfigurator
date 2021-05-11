//-----------------------------------------------------------------------
// <copyright file="Ring.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    public class Ring : Komponente
    {
        public double konusHoehe;
        public double konusWinkel;
        public double konusMax;
        public double konusMin;

        public Ring(int ID)
        {
            SAP = ID;
        }
    }
}
