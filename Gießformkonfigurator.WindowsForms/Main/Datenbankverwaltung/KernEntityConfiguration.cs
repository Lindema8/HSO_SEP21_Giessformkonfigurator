//-----------------------------------------------------------------------
// <copyright file="KernEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.Data.Entity.ModelConfiguration;
    class KernEntityConfiguration : EntityTypeConfiguration<Kern>
    {
        public KernEntityConfiguration()
        {
            this.Property(e => e.Bezeichnung_RoCon)
            .IsUnicode(false);

            this.Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Außendurchmesser)
                .IsUnicode(false);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Min)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Winkel)
                .HasPrecision(5, 2);

            this.Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Hoehe_Fuehrung)
                .HasPrecision(10, 2);

            this.Property(e => e.Durchmesser_Fuehrung)
                .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Durchmesser_Fuehrung)
                .HasPrecision(10, 2);

            this.Property(e => e.Durchmesser_Adapter)
                .HasPrecision(10, 2);
        }
    }
}