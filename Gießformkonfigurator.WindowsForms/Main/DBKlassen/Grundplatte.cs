//-----------------------------------------------------------------------
// <copyright file="Grundplatte.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Grundplatte")]
    public partial class Grundplatte
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [StringLength(255)]
        public string Bezeichnung_RoCon { get; set; }

        public decimal Außendurchmesser { get; set; }

        public decimal Hoehe { get; set; }

        public decimal Konus_Außen_Max { get; set; }

        public decimal Konus_Außen_Min { get; set; }

        public decimal Konus_Außen_Winkel { get; set; }

        public decimal Konus_Hoehe { get; set; }

        public bool Mit_Konusfuehrung { get; set; }

        public decimal? Konus_Innen_Max { get; set; }

        public decimal? Konus_Innen_Min { get; set; }

        public decimal? Konus_Innen_Winkel { get; set; }

        public bool Mit_Lochfuehrung { get; set; }

        public decimal? Innendurchmesser { get; set; }

        [StringLength(10)]
        public string Toleranz_Innendurchmesser { get; set; }

        public bool Mit_Kern { get; set; }

        public virtual Lochkreis Lochkreis { get; set; }

        /// <summary>
        /// Ruft die Methode Kombiniere() des Objekts auf. Beinhaltet die Parameter, welche mit der übergebenen Komponente verglichen werden.
        /// </summary>
        /// <param name="fuehrungsring">Vergleichskomponente</param>
        /// <returns>Gibt einen True zurück, wenn die Komponenten kombiniert werden können.</returns>
        public bool Kombiniere(Ring fuehrungsring)
        {
            return fuehrungsring.Konus_Min > this.Konus_Außen_Min
                && fuehrungsring.Konus_Min < this.Konus_Außen_Max
                && fuehrungsring.Konus_Winkel == this.Konus_Außen_Winkel
                && fuehrungsring.Konus_Hoehe < this.Konus_Hoehe
                && fuehrungsring.Konus_Max < this.Konus_Außen_Max;
        }

        public bool Kombiniere(Einlegeplatte einlegeplatte)
        {
            return this.Konus_Innen_Max > einlegeplatte.Konus_Außen_Max
                    && (this.Konus_Innen_Max - 1) < einlegeplatte.Konus_Außen_Max
                    && this.Konus_Innen_Min > einlegeplatte.Konus_Außen_Min
                    && (this.Konus_Innen_Min - 1) < einlegeplatte.Konus_Außen_Min
                    && this.Konus_Innen_Winkel > einlegeplatte.Konus_Außen_Winkel
                    && (this.Konus_Innen_Winkel - 1) < einlegeplatte.Konus_Außen_Winkel;
        }

        public bool Kombiniere(Kern kern)
        {
            if (this.Mit_Konusfuehrung)
            {
                return this.Konus_Innen_Max > kern.Konus_Außen_Max
                        && (this.Konus_Innen_Max - 5) < kern.Konus_Außen_Max
                        && this.Konus_Innen_Min > kern.Konus_Außen_Min
                        && (this.Konus_Innen_Min - 5) < kern.Konus_Außen_Min
                        && this.Konus_Innen_Winkel > kern.Konus_Außen_Winkel
                        && (this.Konus_Innen_Winkel - 5) < kern.Konus_Außen_Winkel;
            }

            // Grundplatte mit Lochführung akzeptiert einen Kern mit Fuehrungsstift oder Lochfuehrung
            else if (this.Mit_Lochfuehrung && kern.Mit_Fuehrungsstift)
            {
                return this.Innendurchmesser == kern.Durchmesser_Fuehrung
                    && this.Hoehe >= kern.Hoehe_Fuehrung;
            }
            else if (this.Mit_Lochfuehrung && kern.Mit_Lochfuehrung)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
