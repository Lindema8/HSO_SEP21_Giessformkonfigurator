//-----------------------------------------------------------------------
// <copyright file="GießformDBContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Gießformkonfigurator.WindowsForms.Main.Db_supportClasses
{
    using System.Data.Entity;
    using Gießformkonfigurator.WindowsForms.Main.Db_components;
    using Gießformkonfigurator.WindowsForms.Main.Db_products;

    /// <summary>
    /// Implementiert die Klasse DbContext. Konfiguration der DB Grundstruktur.
    /// </summary>
    public partial class GießformDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GießformDBContext"/> class.
        /// Stellt DB Verbindung her. Connection String befindet sich in der App.Config.
        /// </summary>
        public GießformDBContext()
            : base("name=GießformDB")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bolzen> Bolzen { get; set; }

        public virtual DbSet<Einlegeplatte> Einlegeplatten { get; set; }

        public virtual DbSet<Grundplatte> Grundplatten { get; set; }

        public virtual DbSet<Kern> Innenkerne { get; set; }

        public virtual DbSet<Lochkreis> Lochkreise { get; set; }

        public virtual DbSet<ProduktCup> ProduktCups { get; set; }

        public virtual DbSet<ProduktDisc> ProduktDiscs { get; set; }

        public virtual DbSet<Ring> Ringe { get; set; }

        /// <summary>
        /// Initialisiert die EntityConfigurations für alle DB-Objekte.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GrundplatteEntityConfiguration());

            modelBuilder.Configurations.Add(new EinlegeplatteEntityConfiguration());

            modelBuilder.Configurations.Add(new BolzenEntityConfiguration());

            modelBuilder.Configurations.Add(new KernEntityConfiguration());

            modelBuilder.Configurations.Add(new LochkreisEntityConfiguration());

            modelBuilder.Configurations.Add(new ProduktCupEntityConfiguration());

            modelBuilder.Configurations.Add(new ProduktDiscEntityConfiguration());

            modelBuilder.Configurations.Add(new RingEntityConfiguration());

            modelBuilder.Configurations.Add(new CupformEntityConfiguration());
        }
    }
}
