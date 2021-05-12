namespace Gießformkonfigurator.WindowsForms.Main.DatabaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
