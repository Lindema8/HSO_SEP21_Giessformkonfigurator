namespace Gießformkonfigurator.WindowsForms.Main.Logik
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;

    public class CombinationRuleset
    {
        private IEnumerable<CombinationRule> CombinationRules { get; set; }

        public CombinationRuleset()
        {
            // hier müssen alle Regeln registriert werden, damit sie verwendet werden.
            this.CombinationRules = new CombinationRule[]
                    {
                    new BaseplateCoreCombination(),
                    new BaseplateInsertPlateCombination(),
                    new BaseplateRingCombination(),
                    new InsertPlateCoreCombination(),
                    };
        }

        public bool Combine(Component a, Component b)
        {
            var passendeKombinationen = this.CombinationRules.Where(k => k.Akzeptiert(a.GetType()) && k.Akzeptiert(b.GetType()));

            if (!passendeKombinationen.Any())
            {
                return false;
            }

            return passendeKombinationen.All(k => k.Combine(a, b));
        }
    }
}
