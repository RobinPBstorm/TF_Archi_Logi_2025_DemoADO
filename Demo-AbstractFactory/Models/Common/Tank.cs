using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AbstractFactory.Models.Common
{
    internal class Tank : ITank
    {
        public void TirerObus()
        {
            Console.WriteLine("BOUM!");
        }
    }
}
