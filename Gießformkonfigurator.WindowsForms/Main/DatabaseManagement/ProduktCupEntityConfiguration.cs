namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    class ProduktCupEntityConfiguration : EntityTypeConfiguration<ProduktCup>
    {
        public ProduktCupEntityConfiguration()
        {
                this.Property(e => e.Grund_Cup)
                .IsUnicode(false);

                this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

                this.Property(e => e.LK)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}