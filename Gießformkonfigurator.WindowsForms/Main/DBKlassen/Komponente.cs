using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gießformkonfigurator.WindowsForms.Main.DBKlassen
{
    public abstract class Komponente
    {
        public abstract bool Kombiniere(Komponente);
    }
}
