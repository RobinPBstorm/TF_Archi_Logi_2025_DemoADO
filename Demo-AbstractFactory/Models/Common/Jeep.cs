using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_AbstractFactory.Models.Common
{
    internal class Jeep : IJeep
    {
        public void Eclairer()
        {
            if(new Random().Next(2) == 0)
                Console.WriteLine("R.A.S.");
            else
                Console.WriteLine("Enemi en vue!");
        }
    }
}
