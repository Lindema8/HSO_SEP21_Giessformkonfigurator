//-----------------------------------------------------------------------
// <copyright file="RingEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.Data.Entity.ModelConfiguration;
    class RingEntityConfiguration : EntityTypeConfiguration<Ring>
    {
        public RingEntityConfiguration()
        {
            this.Property(e => e.Bezeichnung_RoCon)
            .IsUnicode(false);

            this.Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Außendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Innendurchmesser)
                .IsUnicode(false);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Min)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Winkel)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);
        }
    }
}