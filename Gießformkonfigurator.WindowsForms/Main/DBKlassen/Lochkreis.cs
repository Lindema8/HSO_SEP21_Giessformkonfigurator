//-----------------------------------------------------------------------
// <copyright file="Lochkreis.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Lochkreis
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [Column("LK-Nr.")]
        public int LK_Nr_ { get; set; }

        public int Anzahl_Bohrungen { get; set; }

        [Required]
        [StringLength(5)]
        public string Gewinde { get; set; }

        public decimal? Form { get; set; }

        public virtual Einlegeplatte Einlegeplatte { get; set; }

        public virtual Grundplatte Grundplatte { get; set; }
    }
}
