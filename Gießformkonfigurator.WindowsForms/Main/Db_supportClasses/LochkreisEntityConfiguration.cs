//-----------------------------------------------------------------------
// <copyright file="LochkreisEntityConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Db_supportClasses
{
    using System.Data.Entity.ModelConfiguration;
    using Gießformkonfigurator.WindowsForms.Main.Db_components;

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