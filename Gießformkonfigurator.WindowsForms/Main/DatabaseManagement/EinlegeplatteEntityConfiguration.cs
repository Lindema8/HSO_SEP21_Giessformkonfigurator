namespace Gießformkonfigurator.WindowsForms.Main.DatabaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    class EinlegeplatteEntityConfiguration : EntityTypeConfiguration<Einlegeplatte>
    {
        public EinlegeplatteEntityConfiguration()
        {

            this.Property(e => e.Bezeichnung_RoCon)
            .IsUnicode(false);

            this.Property(e => e.Außendurchmesser)
            .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Außendurchmesser)
                .IsUnicode(false);

            this.Property(e => e.Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Min)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Außen_Winkel)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Hoehe)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Innen_Max)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Innen_Min)
                .HasPrecision(10, 2);

            this.Property(e => e.Konus_Innen_Winkel)
                .HasPrecision(10, 2);

            this.Property(e => e.Innendurchmesser)
                .HasPrecision(10, 2);

            this.Property(e => e.Toleranz_Innendurchmesser)
                .IsUnicode(false);

            this.HasOptional(e => e.Lochkreis)
                .WithRequired(e => e.Einlegeplatte);
        }
    }
}
