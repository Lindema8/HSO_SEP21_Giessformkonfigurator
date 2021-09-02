//-----------------------------------------------------------------------
// <copyright file="ProduktDiscEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses
{
    using System.Data.Entity.ModelConfiguration;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_products;

    class ProductDiscEntityConfiguration : EntityTypeConfiguration<ProductDisc>
    {
        public ProductDiscEntityConfiguration()
        {
            this.Property(e => e.Außendurchmesser)
            .HasPrecision(10, 2);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}