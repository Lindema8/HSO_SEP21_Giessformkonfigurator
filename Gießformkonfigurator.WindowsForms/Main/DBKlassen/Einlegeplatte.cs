//-----------------------------------------------------------------------
// <copyright file="Einlegeplatte.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Einlegeplatte")]
    public partial class Einlegeplatte : Komponente
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [StringLength(100)]
        public string Bezeichnung_RoCon { get; set; }

        public decimal Außendurchmesser { get; set; }

        [StringLength(5)]
        public string Toleranz_Außendurchmesser { get; set; }

        public decimal Hoehe { get; set; }

        public decimal? Konus_Außen_Max { get; set; }

        public decimal? Konus_Außen_Min { get; set; }

        public decimal? Konus_Außen_Winkel { get; set; }

        public decimal? Konus_Hoehe { get; set; }

        public bool mit_Konusfuehrung { get; set; }

        public decimal? Konus_Innen_Max { get; set; }

        public decimal? Konus_Innen_Min { get; set; }

        public decimal? Konus_Innen_Winkel { get; set; }

        public bool mit_Lochfuehrung { get; set; }

        public decimal? Innendurchmesser { get; set; }

        [StringLength(5)]
        public string Toleranz_Innendurchmesser { get; set; }

        public bool mit_Kern { get; set; }

        public virtual Lochkreis Lochkreis { get; set; }
    }
}
