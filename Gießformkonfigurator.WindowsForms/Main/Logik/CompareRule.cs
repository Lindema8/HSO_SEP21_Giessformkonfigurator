namespace Gie�formkonfigurator.WindowsForms.Main.Logik
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gie�formkonfigurator.WindowsForms.Main.DBKlassen;
    using Gie�formkonfigurator.WindowsForms.Main.Gie�formen;

    abstract class CompareRule
    {
        protected abstract IEnumerable<Type> Typen { get; }

        public virtual bool Akzeptiert(Type teilTyp)
        {
            if (!teilTyp.IsSubclassOf(typeof(Produkt)) || (typeof(Gie�form))
            {
                return false;
            }

            return this.Typen.Contains(teilTyp);
        }

        public abstract bool Compare(Produkt a, Gie�form b);
    }

    class ProduktCupCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gie�form) };

        public override bool Compare(Produkt a, Gie�form b)
        {
            var components = new[] { a, b };
            var product = components.OfType<Produkt>().Single();
            var cup = components.OfType<Gie�form>().Single();

            return product.Grund_Cup == cup.Grund_Cup
                        && (product.Innendurchmesser + 1) <= cup.Innendurchmesser
                        && product.Innendurchmesser > cup.Innendurchmesser
                        && product.LK == cup.LK;
        }
    }

    class ProduktMGie�formCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gie�form) };

        public override bool Compare(Produkt a, Gie�form b)
        {
            var components = new[] { a, b };
            var product = components.OfType<Produkt>().Single();
            var gie�form = components.OfType<Gie�form>().Single();

            if (product.Lk1Durchmesser != null)
            {
                return product.Au�endurchmesser <= gie�form.Fuehrungsring.Au�endruchmesser
                    && (product.Au�endurchmesser + 1) > gie�form.Fuehrungsring.Au�endruchmesser
                    && product.Innendurchmesser > gie�form.Innenkern.Innendurchmesser
                    && (product.Innendurchmesser + 1) < gie�form.Innenkern.Innendurchmesser
                    && product.Lk1Durchmesser <= gie�form.Grundplatte.gr��e;
            }
        }
    }


}