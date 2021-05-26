//-----------------------------------------------------------------------
// <copyright file="Bolzen.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bolzen")]
    public partial class Bolzen : Komponente
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [StringLength(100)]
        public string Bezeichnung_RoCon { get; set; }

        public decimal Hoehe { get; set; }

        public decimal Außendurchmesser { get; set; }

        public decimal Gießhoehe_Max { get; set; }

        public bool mit_Gewinde { get; set; }

        public decimal? Gewinde { get; set; }

        public bool mit_Steckbolzen { get; set; }

        public decimal? Hoehe_Fuehrung { get; set; }

        public decimal? Außendurchmesser_Fuehrung { get; set; }
    }
}
