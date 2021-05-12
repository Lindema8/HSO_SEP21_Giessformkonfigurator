namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    class ProduktDiscEntityConfiguration : EntityTypeConfiguration<ProduktDisc>
    {
        public ProduktDiscEntityConfiguration()
        {
            this.Property(e => e.Außendurchmesser)
            .HasPrecision(10, 2);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}