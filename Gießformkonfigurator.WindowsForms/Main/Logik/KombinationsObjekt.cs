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
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gießformkonfigurator.WindowsForms.Main.Gießformen;

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

            // Grundplatten mit den vorhandenen Fuehrungsringen kombinieren.
            for (int iGP = 0; iGP < this.listGrundplatten.Count; iGP++)
            {
                for (int iRinge = 0; iRinge < this.listRinge.Count; iRinge++)
                {
                    if (this.listGrundplatten[iGP].Kombiniere(this.listRinge[iRinge]))
                    {
                        mGießformenTemp01.Add(new MGießform(this.listGrundplatten[iGP], this.listRinge[iRinge], null, null));
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Einlegeplatten kombinieren.
            this.Index = mGießformenTemp01.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                if (mGießformenTemp01[iTemp].Grundplatte.Mit_Konusfuehrung)
                {
                    for (int iEP = 0; iEP < this.listEinlegeplatten.Count; iEP++)
                    {
                        if (mGießformenTemp01[iTemp].Grundplatte.Kombiniere(this.listEinlegeplatten[iEP]))
                        {
                            mGießformenTemp01.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, this.listEinlegeplatten[iEP], null));
                        }
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Kernen kombinieren.
            this.Index = mGießformenTemp01.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                if (mGießformenTemp01[iTemp].Einlegeplatte != null)
                {
                    // Einlegeplatten mit Konusfuehrung mit Kernen kombinieren.
                    if (mGießformenTemp01[iTemp].Einlegeplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < this.listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp01[iTemp].Einlegeplatte.Kombiniere(this.listKerne[iKerne]))
                            {
                                mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]));
                            }
                        }
                    }

                    // Einlegeplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp01[iTemp].Einlegeplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < this.listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp01[iTemp].Einlegeplatte.Kombiniere(this.listKerne[iKerne]))
                            {
                                mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, mGießformenTemp01[iTemp].Einlegeplatte, this.listKerne[iKerne]));
                            }
                        }
                    }
                }

                // Grundplatten mit Konusfuehrung mit Kernen kombinieren.
                else
                {
                    if (mGießformenTemp01[iTemp].Grundplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < this.listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp01[iTemp].Grundplatte.Kombiniere(this.listKerne[iKerne]))
                            {
                                mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, null, this.listKerne[iKerne]));
                            }
                        }
                    }

                    // Grundplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp01[iTemp].Grundplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < this.listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp01[iTemp].Grundplatte.Kombiniere(this.listKerne[iKerne]))
                            {
                                mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, null, this.listKerne[iKerne]));
                            }
                        }
                    }
                    else if (mGießformenTemp01[iTemp].Grundplatte.Mit_Kern == true)
                    {
                        mGießformenTemp02.Add(new MGießform(mGießformenTemp01[iTemp].Grundplatte, mGießformenTemp01[iTemp].Fuehrungsring, null, null));
                    }
                }
            }

            return mGießformenTemp02;
        }

    }
}