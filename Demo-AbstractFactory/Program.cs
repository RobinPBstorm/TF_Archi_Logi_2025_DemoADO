using Demo_AbstractFactory.Models.Bleu;
using Demo_AbstractFactory.Models.Common;
using Demo_AbstractFactory.Models.Rouge;

namespace Demo_AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quelle couleur d'équipe:");
            Console.WriteLine("[B]leu - [R]ouge");

            ConsoleKey key;
            do {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.B &&  key != ConsoleKey.R);

            IUsine usine;
            switch (key)
            {
                case ConsoleKey.B:
                    usine = new UsineBleu();
                    break;
                case ConsoleKey.R:
                default:
                    usine = new UsineRouge();
                    break;
            }

            ITank t_r = usine.ProduireTank();

            Console.WriteLine(t_r);
        }
    }
}
