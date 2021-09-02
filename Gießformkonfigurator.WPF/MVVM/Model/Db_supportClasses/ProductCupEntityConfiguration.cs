//-----------------------------------------------------------------------
// <copyright file="ProduktCupEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses
{
    using System.Data.Entity.ModelConfiguration;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;

    class ProductCupEntityConfiguration : EntityTypeConfiguration<ProductCup>
    {
        public ProductCupEntityConfiguration()
        {
                this.Property(e => e.Grund_Cup)
                .IsUnicode(false);

                this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

                this.Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}