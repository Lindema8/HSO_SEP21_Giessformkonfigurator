//-----------------------------------------------------------------------
// <copyright file="Kern.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Kern")]
    public partial class Kern : Komponente
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [Required]
        [StringLength(100)]
        public string Bezeichnung_RoCon { get; set; }

        public decimal Außendurchmesser { get; set; }

        [StringLength(10)]
        public string Toleranz_Außendurchmesser { get; set; }

        public decimal Hoehe { get; set; }

        public decimal Gießhoehe_Max { get; set; }

        public bool mit_Konusfuehrung { get; set; }

        public decimal? Konus_Außen_Max { get; set; }

        public decimal? Konus_Außen_Min { get; set; }

        public decimal? Konus_Außen_Winkel { get; set; }

        public decimal? Konus_Hoehe { get; set; }

        public bool mit_Fuehrungsstift { get; set; }

        public decimal? Hoehe_Fuehrung { get; set; }

        public decimal? Durchmesser_Fuehrung { get; set; }

        public decimal? Toleranz_Durchmesser_Fuehrung { get; set; }

        public bool mit_Lochfuehrung { get; set; }

        public decimal? Durchmesser_Adapter { get; set; }
    }
}
