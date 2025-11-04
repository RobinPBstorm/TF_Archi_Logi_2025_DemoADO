using Demo_AbstractFactory.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AbstractFactory.Models.Bleu
{
    internal class UsineBleu : Usine
    {
        public override IJeep ProduireJeep()
        {
            return new JeepBleu();
        }

        public override ITank ProduireTank()
        {
            return new TankBleu();
        }
    }
}
