namespace Gieﬂformkonfigurator.WindowsForms.Main.Logik
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gieﬂformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gieﬂformkonfigurator.WindowsForms.Main.Gieﬂformen;

    class CompareRuleSet
    {
        private IEnumerable<CompareRule> CompareRules { get; set; }

        public CompareRuleSet()
        {
            // hier m¸ssen alle Regeln registriert werden, damit sie verwendet werden.
            this.CompareRules = new CompareRule[]
                    {
                    new ProduktCupCompare(),
                    };
        }

        public bool Compare(Produkt a, Gieﬂform b)
        {
            var passendeKombinationen = this.CompareRules.Where(k => k.Akzeptiert(a.GetType()) && k.Akzeptiert(b.GetType()));

            if (!passendeKombinationen.Any())
            {
                return false;
            }

            return passendeKombinationen.All(k => k.Compare(a, b));
        }
    }
}
