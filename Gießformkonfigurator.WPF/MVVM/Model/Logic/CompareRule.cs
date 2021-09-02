namespace Gieﬂformkonfigurator.WPF.MVVM.Model.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gieﬂformkonfigurator.WPF.MVVM.Model.Db_molds;
    using Gieﬂformkonfigurator.WPF.MVVM.Model.Db_products;

    abstract class CompareRule
    {
        protected abstract IEnumerable<Type> Typen { get; }

        public virtual bool Akzeptiert(Type teilTyp)
        {
            if (!teilTyp.IsSubclassOf(typeof(Product)) || !teilTyp.IsSubclassOf(typeof(Mold)))
            {
                return false;
            }

            return this.Typen.Contains(teilTyp);
        }

        public abstract bool Compare(Product a, Mold b);
    }

    // TODO: Not finished
    class ProduktCupCompare : CompareRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Product), typeof(Mold) };

        public override bool Compare(Product a, Mold b)
        {
            object[] compareElements = new object[] { a, b };
            var product = compareElements.OfType<ProductCup>().Single();
            var gieﬂform = compareElements.OfType<ModularMold>().Single();

            // TODO: Cup hinzuf¸gen
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
        protected override IEnumerable<Type> Typen => new[] { typeof(Product), typeof(Mold) };

        public override bool Compare(Product a, Mold b)
        {
            object[] compareElements = new object[] { a, b };
            var product = compareElements.OfType<ProductDisc>().Single();
            var gieﬂform = compareElements.OfType<ModularMold>().Single();

            // TODO: Innenring als Attribut hinzuf¸gen
            //if (gieﬂform.Innenring == null)
            //{
                if (product.Lk1Durchmesser != null)
                {
                    return product.Auﬂendurchmesser <= gieﬂform.Fuehrungsring.Innendurchmesser
                        && (product.Auﬂendurchmesser + 1) > gieﬂform.Fuehrungsring.Innendurchmesser
                        && product.Innendurchmesser > gieﬂform.Innenkern.Auﬂendurchmesser
                        && (product.Innendurchmesser + 1) < gieﬂform.Innenkern.Auﬂendurchmesser
                        && product.Lk1Durchmesser <= gieﬂform.Grundplatte.Hoehe;
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