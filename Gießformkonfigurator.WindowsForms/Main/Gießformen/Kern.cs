//-----------------------------------------------------------------------
// <copyright file="Kern.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Gießformen
{
    public class Kern : Komponente
    {
        public double Durchmesser { get; }

        public double Hoehe { get; }

        public double Konus_Max { get; }

        public double Konus_Min { get; }

        public int Konus_Winkel { get; }

        public double Hoehe_Konus { get; }

        public double Hoehe_Fuehrung { get; }

        public double Durchmesser_Fuehrung { get; }

        public double Toleranz_Durchmesser_Fuehrung { get; }

        public double Gießhoehe_Max { get; }

        public Kern(int aSapNr, string aTyp, double aDurchmesser, double aTiefe, double aKonusAussenMax = 0, double aKonusAussenMin = 0, int aKonusWinkel = 0,
                         double aKonusFuehrungTiefe = 0, double aFuehrungsstiftDurchmesser = 0, double aGiesshoeheMax = 0)
        {
            SAPNr = aSapNr;
            Typ = aTyp;
            Durchmesser = aDurchmesser;
            Hoehe = aTiefe;
            Konus_Max = aKonusAussenMax;
            Konus_Min = aKonusAussenMin;
            Konus_Winkel = aKonusWinkel;
            Hoehe_Konus = aKonusFuehrungTiefe;
            Durchmesser_Fuehrung = aFuehrungsstiftDurchmesser;
            Gießhoehe_Max = aGiesshoeheMax;
        }
    }
}
