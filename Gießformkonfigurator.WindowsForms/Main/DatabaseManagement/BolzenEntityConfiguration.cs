namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    class BolzenEntityConfiguration : EntityTypeConfiguration<Bolzen>
    {
        public BolzenEntityConfiguration()
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