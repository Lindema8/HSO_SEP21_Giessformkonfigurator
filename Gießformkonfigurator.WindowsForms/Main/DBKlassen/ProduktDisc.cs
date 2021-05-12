//-----------------------------------------------------------------------
// <copyright file="ProduktDisc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProduktDisc")]
    public partial class ProduktDisc
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        public decimal Außendurchmesser { get; set; }

        public decimal Hoehe { get; set; }

        public decimal Innendurchmesser { get; set; }

        [Required]
        [StringLength(4)]
        public string LK { get; set; }
    }
}
