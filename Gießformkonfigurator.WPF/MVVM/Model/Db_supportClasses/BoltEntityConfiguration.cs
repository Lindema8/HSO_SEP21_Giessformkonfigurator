//-----------------------------------------------------------------------
// <copyright file="BolzenEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WPF.MVVM.Model.Db_supportClasses
{
    using System.Data.Entity.ModelConfiguration;
    using Gießformkonfigurator.WPF.MVVM.Model.Db_components;

    class BoltEntityConfiguration : EntityTypeConfiguration<Bolt>
    {
        public BoltEntityConfiguration()
        {
            this.Property(e => e.Bezeichnung_RoCon)
            .IsUnicode(false);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Gewinde)
                .HasPrecision(10, 2);

            this.Property(e => e.Hoehe_Fuehrung)
                .HasPrecision(10, 2);

            this.Property(e => e.Außendurchmesser_Fuehrung)
                .HasPrecision(10, 2);
        }
    }
}