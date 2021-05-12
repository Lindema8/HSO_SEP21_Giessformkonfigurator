namespace Gießformkonfigurator.WindowsForms.Main.DatabaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
