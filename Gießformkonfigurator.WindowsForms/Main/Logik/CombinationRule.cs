namespace Gießformkonfigurator.WindowsForms.Main.Logik
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Gießformkonfigurator.WindowsForms.Main.DBKlassen;

    abstract class CombinationRule
    {
        protected abstract IEnumerable<Type> Typen { get; }

        public virtual bool Akzeptiert(Type teilTyp)
        {
            if (!teilTyp.IsSubclassOf(typeof(Component)))
            {
                return false;
            }

            return this.Typen.Contains(teilTyp);
        }

        public abstract bool Combine(Component a, Component b);
    }

    /// <summary>
    /// No Documentation necessary.
    /// </summary>
    class BaseplateCoreCombination : CombinationRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Grundplatte), typeof(Kern) };

        public override bool Combine(Component a, Component b)
        {
            var components = new[] { a, b };
            var baseplate = components.OfType<Grundplatte>().Single();
            var core = components.OfType<Kern>().Single();
            if (baseplate.Mit_Konusfuehrung)
            {
                return core.Mit_Konusfuehrung == true
                        && baseplate.Konus_Innen_Max > core.Konus_Außen_Max
                        && (baseplate.Konus_Innen_Max - 1) <= core.Konus_Außen_Max
                        && baseplate.Konus_Innen_Min > core.Konus_Außen_Min
                        && (baseplate.Konus_Innen_Min - 1) <= core.Konus_Außen_Min
                        && baseplate.Konus_Innen_Winkel == core.Konus_Außen_Winkel;
                // && (this.Konus_Innen_Winkel - 5) < kern.Konus_Außen_Winkel;
            }

            // Grundplatte mit Lochführung akzeptiert einen Kern mit Fuehrungsstift oder Lochfuehrung
            else if (baseplate.Mit_Lochfuehrung && core.Mit_Fuehrungsstift)
            {
                // TODO: Genaue Abweichung zwischen Innendurchmesser und Fuehrungsdurchmesser festlegen.
                return baseplate.Innendurchmesser >= core.Durchmesser_Fuehrung
                    && (baseplate.Innendurchmesser - 2) <= core.Durchmesser_Fuehrung
                    && baseplate.Hoehe >= core.Hoehe_Fuehrung;
            }
            else if (baseplate.Mit_Lochfuehrung && core.Mit_Lochfuehrung)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }

    class BaseplateInsertPlateCombination : CombinationRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Grundplatte), typeof(Einlegeplatte) };

        public override bool Combine(Component a, Component b)
        {
            var components = new[] { a, b };
            var baseplate = components.OfType<Grundplatte>().Single();
            var insertPlate = components.OfType<Einlegeplatte>().Single();

            return baseplate.Konus_Innen_Max > insertPlate.Konus_Außen_Max
                            && (baseplate.Konus_Innen_Max - 1) <= insertPlate.Konus_Außen_Max
                            && baseplate.Konus_Innen_Min > insertPlate.Konus_Außen_Min
                            && (baseplate.Konus_Innen_Min - 1) <= insertPlate.Konus_Außen_Min
                            && baseplate.Konus_Innen_Winkel == insertPlate.Konus_Außen_Winkel;
        }
    }

    class BaseplateRingCombination : CombinationRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Grundplatte), typeof(Ring) };

        public override bool Combine(Component a, Component b)
        {
            var components = new[] { a, b };
            var baseplate = components.OfType<Grundplatte>().Single();
            var ring = components.OfType<Ring>().Single();

            return ring.Konus_Min > baseplate.Konus_Außen_Min
                     && ring.Konus_Min < baseplate.Konus_Außen_Max
                     && ring.Konus_Winkel == baseplate.Konus_Außen_Winkel
                     && ring.Konus_Hoehe < baseplate.Konus_Hoehe
                     && ring.Konus_Max < baseplate.Konus_Außen_Max;
        }
    }

    class InsertPlateCoreCombination : CombinationRule
    {
        protected override IEnumerable<Type> Typen => new[] { typeof(Einlegeplatte), typeof(Kern) };

        public override bool Combine(Component a, Component b)
        {
            var components = new[] { a, b };
            var insertPlate = components.OfType<Einlegeplatte>().Single();
            var core = components.OfType<Kern>().Single();

            if (insertPlate.Mit_Konusfuehrung)
            {
                return core.Mit_Konusfuehrung == true
                            && insertPlate.Konus_Innen_Max > core.Konus_Außen_Max
                            && (insertPlate.Konus_Innen_Max - 1) <= core.Konus_Außen_Max
                            && insertPlate.Konus_Innen_Min > core.Konus_Außen_Min
                            && (insertPlate.Konus_Innen_Min - 1) <= core.Konus_Außen_Min
                            && insertPlate.Konus_Innen_Winkel == core.Konus_Außen_Winkel;
            }
            else if (insertPlate.Mit_Lochfuehrung)
            {
                return core.Mit_Fuehrungsstift == true
                    && insertPlate.Innendurchmesser == core.Durchmesser_Fuehrung
                    && insertPlate.Hoehe >= core.Hoehe_Fuehrung;
            }
            else
            {
                return false;
            }
        }
    }
}
