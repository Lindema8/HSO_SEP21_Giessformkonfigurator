//-----------------------------------------------------------------------
// <copyright file="ProductCup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_products
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductCup")]
    public partial class ProductCup : Product
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
