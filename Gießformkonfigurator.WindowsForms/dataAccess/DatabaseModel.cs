//-----------------------------------------------------------------------
// <copyright file="Komponente.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.DataAccess
{
    using System.Data.Entity;
    class DatabaseModel : DbContext
    {
        public DatabaseModel()
        { }

        public DbSet<Grundplatte> Grundplatten { get; set; }

        public DbSet<Innenkern> Innenkerne { get; set; }

        public DbSet<Ring> Ringe { get; set; }

        public DbSet<Bolzen> Bolzen { get; set; }

        public DbSet<Einlegeplatte> Einlegeplatten { get; set; }

        public DbSet<Lochkreis> Lochkreise { get; set; }

        public DbSet<ProduktDisc> ProduktDiscs { get; set; }

        public DbSet<ProduktCup> ProduktCups { get; set; }
    }
}
