using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AbstractFactory.Models.Common
{
    internal abstract class Usine : IUsine
    {
        public abstract ITank ProduireTank();

        public abstract IJeep ProduireJeep();
    }
}
