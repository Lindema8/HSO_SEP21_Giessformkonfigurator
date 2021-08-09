//-----------------------------------------------------------------------
// <copyright file="KombinationsObjekt.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms
{
#pragma warning disable SA1519 // Braces should not be omitted from multi-line child statement
#pragma warning disable SA1623 // Property summary documentation should match accessors
    using System;
    using System.Collections.Generic;
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gießformkonfigurator.WindowsForms.Main.Gießformen;
    using Gießformkonfigurator.WindowsForms.Main.Logik;

    /// <summary>
    /// Objekt zur Kombination der Komponenten zur Erstellung der mehrteiligen Gießformen (MGießformen).
    /// </summary>
    public class KombinationsObjekt
    {
        private List<Grundplatte> listGrundplatten = new List<Grundplatte>();
        private List<Ring> listRinge = new List<Ring>();
        private List<Einlegeplatte> listEinlegeplatten = new List<Einlegeplatte>();
        private List<Kern> listKerne = new List<Kern>();
        private List<Lochkreis> listLochkreise = new List<Lochkreis>();
        private List<Bolzen> listBolzen = new List<Bolzen>();

        // Frage: Wie kann man das universell umsetzen?
        private ProduktDisc produktDisc;
        private Produkt produktCup;

        /// <summary>
        /// Initializes a new instance of the <see cref="KombinationsObjekt"/> class.
        /// </summary>
        /// <param name="produktParam">Das ausgewählte Produkt wird übergeben.</param>
        public KombinationsObjekt(ProduktDisc produktParam)
        {
            // TODO: Konstruktur universell für ProduktDisc und ProduktCup gestalten.
            if (produktParam is ProduktDisc)
            {
                this.produktDisc = produktParam;
            }
        }

        /// <summary>
        /// Speichert den aktuellen Listenindex.
        /// </summary>
        public int Index { get; set; }

        public void ArraysTestData()
        {
            this.listGrundplatten.Add(new Grundplatte() { Bezeichnung_RoCon = "Grundplatte 12", Außendurchmesser = 375.00m, Hoehe = 20.00m, Konus_Außen_Max = 347.89m, Konus_Außen_Min = 342.00m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 11.00m, Innendurchmesser = 15.00m, Mit_Lochfuehrung = true });
            this.listGrundplatten.Add(new Grundplatte() { Bezeichnung_RoCon = "Grundplatte 22", Außendurchmesser = 700.00m, Hoehe = 20.00m, Konus_Außen_Max = 645.58m, Konus_Außen_Min = 639.31m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 11.00m, Innendurchmesser = 225.00m, Konus_Innen_Max = 265.31m, Konus_Innen_Min = 259.42m, Konus_Innen_Winkel = 15.00m, Mit_Konusfuehrung = true });
            this.listEinlegeplatten.Add(new Einlegeplatte() { Bezeichnung_RoCon = "Einsatz fuer Grundplatte 22in-24in", Außendurchmesser = 265.00m, Hoehe = 20.00m, Konus_Außen_Max = 265.00m, Konus_Außen_Min = 259.11m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 11.00m, Innendurchmesser = 30.00m, Mit_Lochfuehrung = true });
            this.listRinge.Add(new Ring() { Bezeichnung_RoCon = "Form ring", Außendurchmesser = 375.00m, Hoehe = 31.6m, Konus_Max = 345.43m, Konus_Min = 342.21m, Konus_Winkel = 15.00m, Konus_Hoehe = 6.00m, Innendurchmesser = 315.3m, Gießhoehe_Max = 25.00m, mit_Konusfuehrung = true });
            this.listRinge.Add(new Ring() { Bezeichnung_RoCon = "Formring Dichtscheibe d 324", Außendurchmesser = 375.00m, Hoehe = 21.6m, Konus_Max = 345.52m, Konus_Min = 342.3m, Konus_Winkel = 15.00m, Konus_Hoehe = 6.00m, Innendurchmesser = 330.6m, Gießhoehe_Max = 15.00m, mit_Konusfuehrung = true });
            this.listKerne.Add(new Kern() { Bezeichnung_RoCon = "Einsatz fuer Innendurchmesser d 40", Außendurchmesser = 41.4m, Hoehe = 40.6m, Konus_Hoehe = 15.00m, Durchmesser_Fuehrung = 15.00m, Gießhoehe_Max = 25.6m, Mit_Fuehrungsstift = true });
            this.listKerne.Add(new Kern() { Bezeichnung_RoCon = "Einsatz fuer Innendurchmesser d219", Außendurchmesser = 224.4m, Hoehe = 42.00m, Konus_Außen_Max = 210.00m, Konus_Außen_Min = 206.78m, Konus_Außen_Winkel = 15.00m, Konus_Hoehe = 6.00m, Gießhoehe_Max = 36.00m, Mit_Konusfuehrung = true });
            this.listKerne.Add(new Kern() { Bezeichnung_RoCon = "Einsatz fuer Innendurchmesser d=82", Außendurchmesser = 84.1m, Hoehe = 40.6m, Konus_Hoehe = 15.00m, Durchmesser_Fuehrung = 15.00m, Gießhoehe_Max = 25.6m, Hoehe_Fuehrung = 20.00m, Mit_Fuehrungsstift = true });
        }

        /// <summary>
        /// Stellt eine Verbindung zur Datenbank her und speichert die Komponenten in einer lokalen Objektliste. Die Komponenten werden über die Produktparameter vorgefiltert.
        /// </summary>
        public void FiltereDiscDB()
        {
            if (this.produktDisc != null)
            {
                using (var db = new GießformDBContext())
                {
                    foreach (var grundplatte in db.Grundplatten)
                    {
                        if (this.produktDisc.Außendurchmesser < grundplatte.Außendurchmesser)
                        {
                            this.listGrundplatten.Add(grundplatte);
                        }
                    }

                    foreach (var ring in db.Ringe)
                    {
                        if (this.produktDisc.Innendurchmesser > ring.Außendurchmesser
                            || (ring.mit_Konusfuehrung && this.produktDisc.Außendurchmesser < ring.Außendurchmesser))
                        {
                            this.listRinge.Add(ring);
                        }
                    }

                    foreach (var einlegeplatte in db.Einlegeplatten)
                    {
                        this.listEinlegeplatten.Add(einlegeplatte);
                    }

                    foreach (var innenkern in db.Innenkerne)
                    {
                        if (this.produktDisc.Innendurchmesser > innenkern.Außendurchmesser)
                        {
                            this.listKerne.Add(innenkern);
                        }
                    }

                    foreach (var lochkreis in db.Lochkreise)
                    {
                        this.listLochkreise.Add(lochkreis);
                    }

                    foreach (var bolzen in db.Bolzen)
                    {
                        // TODO: Abgleich hinzufügen. Produkt besitzt aktuell nur das Attribut Lochkreis, welches keine Vergleichseigenschaft besitzt. Durchmesser der Löcher benötigt.
                        // if (bolzen.Außendurchmesser <= produkt)
                        this.listBolzen.Add(bolzen);
                    }
                }
            }
            else
            {
                // TODO: Prüfen ob dieser Teil relevant ist. Soll das Szenario abfangen, dass kein Produkt vorhanden ist und man den Kombinationsalgorithmus trotzdem ausführen möchte.
                using (var db = new GießformDBContext())
                {
                    foreach (var grundplatte in db.Grundplatten)
                    {
                        this.listGrundplatten.Add(grundplatte);
                    }

                    foreach (var ring in db.Ringe)
                    {
                        this.listRinge.Add(ring);
                    }

                    foreach (var einlegeplatte in db.Einlegeplatten)
                    {
                        this.listEinlegeplatten.Add(einlegeplatte);
                    }

                    foreach (var innenkern in db.Innenkerne)
                    {
                        this.listKerne.Add(innenkern);
                    }

                    foreach (var lochkreis in db.Lochkreise)
                    {
                        this.listLochkreise.Add(lochkreis);
                    }

                    foreach (var bolzen in db.Bolzen)
                    {
                        this.listBolzen.Add(bolzen);
                    }
                }
            }
        }

        /// <summary>
        /// Nutzt die vorgefilterte Datenbank um alle möglichen Gieformkombinationen zu finden.
        /// </summary>
        /// <returns>List MGießformenFinal.</returns>
        [STAThread]
        public List<MGießform> KombiniereMGießformen()
        {
            // Listen, welche zur Zwischenspeicherung der mehrteiligen Gießformen genutzt werden, bevor sie vervollständigt wurden und ausgegeben werden können.
            List<MGießform> mGießformenTemp01 = new List<MGießform>();
            List<MGießform> mGießformenTemp02 = new List<MGießform>();
            var combinationRuleSet = new CombinationRuleset();

            // Grundplatten mit den vorhandenen Fuehrungsringen kombinieren.
            for (int iGP = 0; iGP < this.listGrundplatten.Count; iGP++)
            {
                for (int iRinge = 0; iRinge < this.listRinge.Count; iRinge++)
                {
                    if (combinationRuleSet.Combine(this.listGrundplatten[iGP], this.listRinge[iRinge]))
                    {
                        mGießformenTemp01.Add(new MGießform(this.listGrundplatten[iGP], this.listRinge[iRinge], null, null));
                    }
                }
            }

            // Mehrteilige Gießformen --> Einlegeplatten
            this.Index = mGießformenTemp01.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                if (mGießformenTemp01[iTemp].Grundplatte.Mit_Konusfuehrung)
                {
                    for (int iEP = 0; iEP < this.listEinlegeplatten.Count; iEP++)
                    {
                        if (combinationRuleSet.Combine(mGießformenTemp01[iTemp].Grundplatte, this.listEinlegeplatten[iEP]))
                        {
                            mGießformenTemp01.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, this.listEinlegeplatten[iEP], null));
                        }
                    }
                }
            }

            // Mehrteilige Gießformen --> Kerne
            this.Index = mGießformenTemp01.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                for (int iKerne = 0; iKerne < this.listKerne.Count; iKerne++)
                {
                    // Einlegeplatte vorhanden
                    if (mGießformenTemp01[iTemp].Einlegeplatte != null)
                    {
                        // Einlegeplatten mit Konusfuehrung
                        if (mGießformenTemp01[iTemp].Einlegeplatte.Mit_Konusfuehrung == true && combinationRuleSet.Combine(mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]))
                        {
                            mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]));
                        }

                        // Einlegeplatten mit Lochfuehrung
                        else if (mGießformenTemp01[iTemp].Einlegeplatte.Mit_Lochfuehrung == true && combinationRuleSet.Combine(mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]))
                        {
                            mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]));
                        }
                    }

                    // Ohne Einlegeplatte
                    else if (mGießformenTemp01[iTemp].Einlegeplatte == null)
                    {
                        // Grundplatten mit Konusfuehrung
                        if ((mGießformenTemp01[iTemp].Grundplatte.Mit_Konusfuehrung == true || mGießformenTemp01[iTemp].Grundplatte.Mit_Lochfuehrung == true) && combinationRuleSet.Combine(mGießformenTemp01[iTemp].Grundplatte, this.listKerne[iKerne]))
                        {
                            mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, null, this.listKerne[iKerne]));
                        }

                        // Grundplatte mit Kern
                        else if (mGießformenTemp01[iTemp].Grundplatte.Mit_Kern == true)
                        {
                            mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, null, null));
                        }
                    }
                }
            }

            return mGießformenTemp02;
        }
    }
}