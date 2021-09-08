//-----------------------------------------------------------------------
// <copyright file="FilterJob.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_components;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses;

    class FilterJob
    {
        public List<Baseplate> listBaseplates { get; set; } = new List<Baseplate>();
        public List<Ring> listRings { get; set; } = new List<Ring>();
        public List<InsertPlate> listInsertPlates { get; set; } = new List<InsertPlate>();
        public List<Core> listCores { get; set; } = new List<Core>();
        public List<Bolt> listBolts { get; set; } = new List<Bolt>();

        public List<Cupform> listCupforms { get; set; } = new List<Cupform>();
        public ProductDisc productDisc { get; set; }
        public ProductCup productCup { get; set; }

        public FilterJob(Product product)
        {
            if (product.GetType() == typeof(ProductDisc))
            {
                this.productDisc = (ProductDisc) product;
            } 
            else if (product.GetType() == typeof(ProductCup))
            {
                this.productCup = (ProductCup) product;
            }

            this.FilterDiscDatabase();
        }

        /// <summary>
        /// Stellt eine Verbindung zur Datenbank her und speichert die Komponenten in einer lokalen Objektliste. Die Komponenten werden über die Produktparameter vorgefiltert.
        /// </summary>
        public void FilterDiscDatabase()
        {
            if (this.productDisc != null)
            {
                using (var db = new GießformDBContext())
                {
                    foreach (var grundplatte in db.Baseplates)
                    {
                        if (this.productDisc.Außendurchmesser < grundplatte.Außendurchmesser)
                        {
                            this.listBaseplates.Add(grundplatte);
                            Console.WriteLine("Grundplatte " + grundplatte + " added to the filter.");
                        }
                        else
                        {
                            Console.WriteLine("Grundplatte " + grundplatte + " removed.");
                        }
                    }

                    foreach (var ring in db.Rings)
                    {
                        if ((ring.mit_Konusfuehrung == false && this.productDisc.Innendurchmesser > ring.Außendurchmesser && this.productDisc.Außendurchmesser < ring.Außendurchmesser)
                            || (ring.mit_Konusfuehrung && this.productDisc.Außendurchmesser < ring.Außendurchmesser))
                        {
                            this.listRings.Add(ring);
                            Console.WriteLine("Ring " + ring + " added to the filter.");
                        }
                        else
                        {
                            Console.WriteLine("Ring " + ring + " removed.");
                        }
                    }

                    // no filter for insertplates
                    foreach (var einlegeplatte in db.InsertPlates)
                    {
                        this.listInsertPlates.Add(einlegeplatte);
                        Console.WriteLine("Einlegeplatte " + einlegeplatte + " added to the filter.");
                    }

                    foreach (var innenkern in db.Cores)
                    {
                        if (this.productDisc.Innendurchmesser > innenkern.Außendurchmesser)
                        {
                            this.listCores.Add(innenkern);
                            Console.WriteLine("Innenkern " + innenkern + " added to the filter.");
                        }
                        else
                        {
                            Console.WriteLine("Innenkern " + innenkern + " removed.");
                        }
                    }

                    foreach (var bolzen in db.Bolts)
                    {
                        // TODO: Abgleich hinzufügen. Produkt besitzt aktuell nur das Attribut Lochkreis, welches keine Vergleichseigenschaft besitzt. Durchmesser der Löcher benötigt.
                        if (bolzen.Außendurchmesser <= this.productDisc.Lk1Durchmesser
                            || bolzen.Außendurchmesser <= this.productDisc.Lk2Durchmesser
                            || bolzen.Außendurchmesser <= this.productDisc.Lk3Durchmesser)
                        {
                            this.listBolts.Add(bolzen);
                            Console.WriteLine("Bolzen " + bolzen + " added to the filter.");
                        }
                        else
                        {
                            Console.WriteLine("Bolzen " + bolzen + " removed.");
                        }
                    }

                    foreach (var cupform in db.Cupforms)
                    {
                        // TODO: Abgleich hinzufügen. Produkt besitzt aktuell nur das Attribut Lochkreis, welches keine Vergleichseigenschaft besitzt. Durchmesser der Löcher benötigt.
                        if (cupform.Innendurchmesser <= this.productCup.Innendurchmesser
                            //|| cupform.LK <= this.produktCup.LK
                            )
                        {
                            this.listCupforms.Add(cupform);
                            Console.WriteLine("Cupform " + cupform + " added to the filter.");
                        }
                        else
                        {
                            Console.WriteLine("Cupform " + cupform + " removed.");
                        }
                    }
                }
            }
            else
            {
                // TODO: Prüfen ob dieser Teil relevant ist. Soll das Szenario abfangen, dass kein Produkt vorhanden ist und man den Kombinationsalgorithmus trotzdem ausführen möchte.
                using (var db = new GießformDBContext())
                {
                    foreach (var grundplatte in db.Baseplates)
                    {
                        this.listBaseplates.Add(grundplatte);
                    }

                    foreach (var ring in db.Rings)
                    {
                        this.listRings.Add(ring);
                    }

                    foreach (var einlegeplatte in db.InsertPlates)
                    {
                        this.listInsertPlates.Add(einlegeplatte);
                    }

                    foreach (var innenkern in db.Cores)
                    {
                        this.listCores.Add(innenkern);
                    }

                    foreach (var bolzen in db.Bolts)
                    {
                        this.listBolts.Add(bolzen);
                    }

                    foreach (var cupform in db.Cupforms)
                    {
                        this.listCupforms.Add(cupform);
                    }
                }
            }
        }
    }
}
