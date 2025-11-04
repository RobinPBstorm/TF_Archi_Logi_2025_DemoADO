using Demo_AbstractFactory.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AbstractFactory.Models.Rouge
{
    internal class UsineRouge : Usine
    {
        public override IJeep ProduireJeep()
        {
            return new JeepRouge();
        }

        public override ITank ProduireTank()
        {
            return new TankRouge();
        }
    }
}
