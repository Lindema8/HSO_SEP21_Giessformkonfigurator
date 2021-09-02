//-----------------------------------------------------------------------
// <copyright file="Cupform.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_components
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cupform")]
    public partial class Cupform : Component
    {
        [Key]
        [Column("SAP-Nr.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SAP_Nr_ { get; set; }

        [StringLength(255)]
        public string Bezeichnung_RoCon { get; set; }

        [StringLength(20)]
        public string Cup_Typ { get; set; }

        public decimal? Innendurchmesser { get; set; }

        [StringLength(10)]
        public string Toleranz_Innendurchmesser { get; set; }

        public decimal? LK { get; set; }

        public bool Mit_Fuehrungsstift { get; set; }

        public bool Mit_Innengewinde { get; set; }

        public bool Mit_Konusfuehrung { get; set; }

        public bool Mit_Lochfuehrung { get; set; }

        public bool Mit_Innenkern { get; set; }
    }
}
