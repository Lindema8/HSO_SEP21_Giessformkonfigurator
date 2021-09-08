namespace Gie�formkonfigurator.WPF.MVVM.Model.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gie�formkonfigurator.WPF.MVVM.Model.Db_molds;
    using Gie�formkonfigurator.WPF.MVVM.Model.Db_products;

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
            var gie�form = compareElements.OfType<ModularMold>().Single();

            if (product.LK != null)
            {
                return product.Innendurchmesser > gie�form.Innenkern.Au�endurchmesser
                    && (product.Innendurchmesser + 1) < gie�form.Innenkern.Au�endurchmesser
                    && product.Grund_Cup == gie�form.Cupform.Cup_Typ;
            }
            else
            {
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
            var gie�form = compareElements.OfType<ModularMold>().Single();

            // TODO: Innenring als Attribut hinzuf�gen
            //if (gie�form.Innenring == null)
            //{
                if (product.Lk1Durchmesser != 0.0m)
                {
                    return product.Au�endurchmesser <= gie�form.Fuehrungsring.Innendurchmesser
                        && (product.Au�endurchmesser + 1) > gie�form.Fuehrungsring.Innendurchmesser
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