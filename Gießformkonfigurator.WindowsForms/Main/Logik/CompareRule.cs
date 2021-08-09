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
            if (!teilTyp.IsSubclassOf(typeof(Produkt)) || !teilTyp.IsSubclassOf(typeof(Gie�form)))
            {
                return false;
            }

            return this.Typen.Contains(teilTyp);
        }

        public abstract bool Compare(Produkt a, Gie�form b);
    }

    // TODO: Not finished
    class ProduktCupCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gie�form) };

        public override bool Compare(Produkt a, Gie�form b)
        {
            object[] compareElements = new object[] { a, b };
            var product = compareElements.OfType<ProduktCup>().Single();
            var gie�form = compareElements.OfType<MGie�form>().Single();

            // TODO: Cup hinzuf�gen
            /*return product.Grund_Cup == cup.Grund_Cup
                        && (product.Innendurchmesser + 1) <= cup.Innendurchmesser
                        && product.Innendurchmesser > cup.Innendurchmesser
                        && product.LK == cup.LK;*/
            return false;
        }
    }

    // TODO: Not finished
    class ProduktDiscCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Produkt), typeof(Gie�form) };

        public override bool Compare(Produkt a, Gie�form b)
        {
            object[] compareElements = new object[] { a, b };
            var product = compareElements.OfType<ProduktDisc>().Single();
            var gie�form = compareElements.OfType<MGie�form>().Single();

            // TODO: Innenring als Attribut hinzuf�gen
            //if (gie�form.Innenring == null)
            //{
                if (product.Lk1Durchmesser != null)
                {
                    return product.Au�endurchmesser <= gie�form.Fuehrungsring.Au�endurchmesser
                        && (product.Au�endurchmesser + 1) > gie�form.Fuehrungsring.Au�endurchmesser
                        && product.Innendurchmesser > gie�form.Innenkern.Au�endurchmesser
                        && (product.Innendurchmesser + 1) < gie�form.Innenkern.Au�endurchmesser
                        && product.Lk1Durchmesser <= gie�form.Grundplatte.Hoehe;
                }
                else
                {
                    return false;
                }
            //}
            //else
            //{
                // TODO
            //    return false;
            //}
        }
    }
}