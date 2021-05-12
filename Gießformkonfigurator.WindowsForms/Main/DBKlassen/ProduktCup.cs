//-----------------------------------------------------------------------
// <copyright file="ProduktCup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProduktCup")]
    public partial class ProduktCup
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [Column("Grund-Cup")]
        [Required]
        [StringLength(100)]
        public string Grund_Cup { get; set; }

        public decimal Innendurchmesser { get; set; }

        [Required]
        [StringLength(5)]
        public string LK { get; set; }
    }
}
