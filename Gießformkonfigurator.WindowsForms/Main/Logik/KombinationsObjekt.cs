﻿//-----------------------------------------------------------------------
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
            List<MGießform> mGießformenTemp = new List<MGießform>();
            List<MGießform> mGießformenFinal = new List<MGießform>();

            // TODO: Filterung der DB einbinden
            /*List<Grundplatte> listGrundplatten = new List<Grundplatte>();
            List<Ring> listRinge = new List<Ring>();
            List<Einlegeplatte> listEinlegeplatten = new List<Einlegeplatte>();
            List<Kern> listKerne = new List<Kern>();
            List<Lochkreis> listLochkreise = new List<Lochkreis>();
            List<Bolzen> listBolzen = new List<Bolzen>();*/

            // Grundplatten mit den vorhandenen Fuehrungsringen kombinieren.
            for (int iGP = 0; iGP < this.listGrundplatten.Count; iGP++)
            {
                for (int iRinge = 0; iRinge < listRinge.Count; iRinge++)
                {
                    if (this.listGrundplatten[iGP].Kombiniere(this.listRinge[iRinge]))
                    {
                        mGießformenTemp.Add(new MGießform(this.listGrundplatten[iGP], this.listRinge[iRinge], null, null));
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Einlegeplatten kombinieren.
            this.Index = mGießformenTemp.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                if (mGießformenTemp[iTemp].Grundplatte.Mit_Konusfuehrung)
                {
                    for (int iEP = 0; iEP < listEinlegeplatten.Count; iEP++)
                    {
                        if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listEinlegeplatten[iEP]))
                        {
                            mGießformenTemp.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, listEinlegeplatten[iEP], null));
                        }
                    }
                }
            }

            // Mehrteilige Gießformen aus der Liste temporärer Kombinationen mit Kernen kombinieren.
            this.Index = mGießformenTemp.Count;
            for (int iTemp = 0; iTemp < this.Index; iTemp++)
            {
                if (mGießformenTemp[iTemp].Einlegeplatte != null)
                {
                    // Einlegeplatten mit Konusfuehrung mit Kernen kombinieren.
                    if (mGießformenTemp[iTemp].Einlegeplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Einlegeplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, mGießformenTemp[iTemp].Einlegeplatte, listKerne[iKerne]));
                            }
                        }
                    }

                    // Einlegeplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp[iTemp].Einlegeplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Einlegeplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, mGießformenTemp[iTemp].Einlegeplatte, listKerne[iKerne]));
                            }
                        }
                    }
                }

                // Grundplatten mit Konusfuehrung mit Kernen kombinieren.
                else
                {
                    if (mGießformenTemp[iTemp].Grundplatte.Mit_Konusfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, listKerne[iKerne]));
                            }
                        }
                    }

                    // Grundplatten mit Lochfuehrung mit Kernen kombinieren.
                    else if (mGießformenTemp[iTemp].Grundplatte.Mit_Lochfuehrung == true)
                    {
                        for (int iKerne = 0; iKerne < listKerne.Count; iKerne++)
                        {
                            if (mGießformenTemp[iTemp].Grundplatte.Kombiniere(listKerne[iKerne]))
                            {
                                mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, listKerne[iKerne]));
                            }
                        }
                    }
                    else if (mGießformenTemp[iTemp].Grundplatte.Mit_Kern == true)
                    {
                        mGießformenFinal.Add(new MGießform(mGießformenTemp[iTemp].Grundplatte, mGießformenTemp[iTemp].Fuehrungsring, null, null));
                    }
                }
            }

            // Ausgabe:
            foreach (MGießform mGießform in mGießformenFinal)
            {
                Console.Write(mGießform.ToString() + ": ");
                Console.Write(mGießform.Grundplatte?.Bezeichnung_RoCon + ", ");
                Console.Write(mGießform.Einlegeplatte?.Bezeichnung_RoCon + ", ");
                Console.Write(mGießform.Fuehrungsring?.Bezeichnung_RoCon + ", ");
                Console.WriteLine(mGießform.Innenkern?.Bezeichnung_RoCon);
            }

            Console.Write("Am Ende");
            Console.ReadLine();

            return mGießformenFinal;
        }

    }
}