using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    public partial class GießformDB : DbContext
    {
        public GießformDB()
            : base("name=GießformDB")
        {
        }

        public virtual DbSet<Bolzen> Bolzen { get; set; }
        public virtual DbSet<Einlegeplatte> Einlegeplatten { get; set; }
        public virtual DbSet<Grundplatte> Grundplatten { get; set; }
        public virtual DbSet<Innenkern> Innenkerne { get; set; }
        public virtual DbSet<Lochkreis> Lochkreise { get; set; }
        public virtual DbSet<ProduktCup> ProduktCups { get; set; }
        public virtual DbSet<ProduktDisc> ProduktDiscs { get; set; }
        public virtual DbSet<Ring> Ringe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GrundplatteEntityConfiguration());

            modelBuilder.Configurations.Add(new EinlegeplatteEntityConfiguration());

            modelBuilder.Configurations.Add(new BolzenEntityConfiguration());

            modelBuilder.Configurations.Add(new InnenkernEntityConfiguration());

            modelBuilder.Configurations.Add(new LochkreisEntityConfiguration());

            modelBuilder.Configurations.Add(new ProduktCupEntityConfiguration());

            modelBuilder.Configurations.Add(new ProduktDiscEntityConfiguration());

            modelBuilder.Configurations.Add(new RingEntityConfiguration());
        }
    }
}
