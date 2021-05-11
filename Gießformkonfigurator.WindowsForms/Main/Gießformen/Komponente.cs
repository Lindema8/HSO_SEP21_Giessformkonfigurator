//-----------------------------------------------------------------------
// <copyright file="Komponente.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    using System;
    public abstract class Komponente
    {
        public int SAPNr { get; set; }

        public string Typ { get; set; }

        public string printSAP()
        {
            return SAPNr.ToString();
        }
    }
}
