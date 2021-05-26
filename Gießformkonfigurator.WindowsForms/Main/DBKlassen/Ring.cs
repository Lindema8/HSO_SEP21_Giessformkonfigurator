//-----------------------------------------------------------------------
// <copyright file="Ring.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ring")]
    public partial class Ring : Komponente
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [Required]
        [StringLength(255)]
        public string Bezeichnung_RoCon { get; set; }

        public decimal Außendurchmesser { get; set; }

        public decimal? Toleranz_Außendurchmesser { get; set; }

        public decimal Innendurchmesser { get; set; }

        [StringLength(10)]
        public string Toleranz_Innendurchmesser { get; set; }

        public decimal Hoehe { get; set; }

        public decimal Gießhoehe_Max { get; set; }

        public bool mit_Konusfuehrung { get; set; }

        public decimal? Konus_Max { get; set; }

        public decimal? Konus_Min { get; set; }

        public decimal? Konus_Winkel { get; set; }

        public decimal? Konus_Hoehe { get; set; }

        public bool ohne_Konusfuehrung { get; set; }

        public bool Kombiniere()
        {
            throw new System.NotImplementedException();
        }

        public bool Kombiniere(Kern kern)
        {
            throw new System.NotImplementedException();
        }
    }
}
