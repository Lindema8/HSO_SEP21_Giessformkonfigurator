namespace Gieﬂformkonfigurator.WindowsForms.Main.Logik
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gieﬂformkonfigurator.WindowsForms.Main.DBKlassen;
    using Gieﬂformkonfigurator.WindowsForms.Main.Gieﬂformen;

    abstract class CompareRule
    {
        protected abstract IEnumerable<Type> Typen { get; }

        public virtual bool Akzeptiert(Type teilTyp)
        {
            if (!teilTyp.IsSubclassOf(typeof(Produkt)) || (typeof(Gieﬂform))
            {
                return false;
            }

            return this.Typen.Contains(teilTyp);
        }

        public abstract bool Compare(Produkt a, Gieﬂform b);
    }

    class ProduktCupCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gieﬂform) };

        public override bool Compare(Produkt a, Gieﬂform b)
        {
            var components = new[] { a, b };
            var product = components.OfType<Produkt>().Single();
            var cup = components.OfType<Gieﬂform>().Single();

            return product.Grund_Cup == cup.Grund_Cup
                        && (product.Innendurchmesser + 1) <= cup.Innendurchmesser
                        && product.Innendurchmesser > cup.Innendurchmesser
                        && product.LK == cup.LK;
        }
    }

    class ProduktMGieﬂformCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gieﬂform) };

        public override bool Compare(Produkt a, Gieﬂform b)
        {
            var components = new[] { a, b };
            var product = components.OfType<Produkt>().Single();
            var gieﬂform = components.OfType<Gieﬂform>().Single();

            if (product.Lk1Durchmesser != null)
            {
                return product.Auﬂendurchmesser <= gieﬂform.Fuehrungsring.Auﬂendruchmesser
                    && (product.Auﬂendurchmesser + 1) > gieﬂform.Fuehrungsring.Auﬂendruchmesser
                    && product.Innendurchmesser > gieﬂform.Innenkern.Innendurchmesser
                    && (product.Innendurchmesser + 1) < gieﬂform.Innenkern.Innendurchmesser
                    && product.Lk1Durchmesser <= gieﬂform.Grundplatte.grˆﬂe;
            }
        }
    }


}