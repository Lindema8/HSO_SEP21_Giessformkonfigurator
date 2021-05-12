//-----------------------------------------------------------------------
// <copyright file="LochkreisEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    using System.Data.Entity.ModelConfiguration;
    class LochkreisEntityConfiguration : EntityTypeConfiguration<Lochkreis>
    {
        public LochkreisEntityConfiguration()
        {
            this.Property(e => e.Gewinde)
            .IsUnicode(false);

            this.Property(e => e.Form)
            .HasPrecision(10, 2);
        }
    }
}