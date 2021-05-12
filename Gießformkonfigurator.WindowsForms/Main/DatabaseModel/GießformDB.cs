using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Gießformkonfigurator.WindowsForms.Main.DatabaseModel
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
            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Bezeichnung_RoCon)
                .IsUnicode(false);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Gewinde)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Hoehe_Fuehrung)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Bolzen>()
                .Property(e => e.Außendurchmesser_Fuehrung)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Bezeichnung_RoCon)
                .IsUnicode(false);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Toleranz_Außendurchmesser)
                .IsUnicode(false);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Außen_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Außen_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Außen_Winkel)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Innen_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Innen_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Konus_Innen_Winkel)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Einlegeplatte>()
                .Property(e => e.Toleranz_Innendurchmesser)
                .IsUnicode(false);

            modelBuilder.Entity<Einlegeplatte>()
                .HasOptional(e => e.Lochkreis)
                .WithRequired(e => e.Einlegeplatte);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Bezeichnung_RoCon)
                .IsUnicode(false);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Außen_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Außen_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Außen_Winkel)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Innen_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Innen_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Konus_Innen_Winkel)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Grundplatte>()
                .Property(e => e.Toleranz_Innendurchmesser)
                .IsUnicode(false);

            modelBuilder.Entity<Grundplatte>()
                .HasOptional(e => e.Lochkreis)
                .WithRequired(e => e.Grundplatte);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Bezeichnung_RoCon)
                .IsUnicode(false);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Toleranz_Außendurchmesser)
                .IsUnicode(false);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Konus_Außen_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Konus_Außen_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Konus_Außen_Winkel)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Hoehe_Fuehrung)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Durchmesser_Fuehrung)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Toleranz_Durchmesser_Fuehrung)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Innenkern>()
                .Property(e => e.Durchmesser_Adapter)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Lochkreis>()
                .Property(e => e.Gewinde)
                .IsUnicode(false);

            modelBuilder.Entity<Lochkreis>()
                .Property(e => e.Form)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProduktCup>()
                .Property(e => e.Grund_Cup)
                .IsUnicode(false);

            modelBuilder.Entity<ProduktCup>()
                .Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProduktCup>()
                .Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ProduktDisc>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProduktDisc>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProduktDisc>()
                .Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProduktDisc>()
                .Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Bezeichnung_RoCon)
                .IsUnicode(false);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Toleranz_Außendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Toleranz_Innendurchmesser)
                .IsUnicode(false);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Gießhoehe_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Konus_Max)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Konus_Min)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Konus_Winkel)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ring>()
                .Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);
        }
    }
}
