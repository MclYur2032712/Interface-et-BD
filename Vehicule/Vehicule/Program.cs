using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Moteur moteur = new Moteur(100, 6, 200, 1);
            Roue roue = new Roue(200, 45, 16, 90, 'V', 30, "Été");
            Moto moto = new Moto(100, "Chopper", 30, moteur, roue, "Red", "Harley Davidson", "Street Bob");
            Spyder spyder = new Spyder(100, 30, moteur, roue, "Yellow", "Can-Am", "F3 SE6");

            moto.Demarrer();
            moto.Rouler(150);

            spyder.Demarrer();
            spyder.Rouler(210);

            Console.ReadKey();
        }
    }
}
