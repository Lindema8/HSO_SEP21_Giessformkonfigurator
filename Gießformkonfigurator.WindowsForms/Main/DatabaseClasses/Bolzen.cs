namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bolzen")]
    public partial class Bolzen
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [StringLength(100)]
        public string Bezeichnung_RoCon { get; set; }

        public string hallotest { get; set; }

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
