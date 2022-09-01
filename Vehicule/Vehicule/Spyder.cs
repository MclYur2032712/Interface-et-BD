using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Spyder : Moto
    {
        public Spyder(int dureeVieKm,  int tailleReservoir, Moteur moteur, Roue roue, string couleur, string marque, string modele) : base(dureeVieKm, "Spyder", tailleReservoir, moteur, roue, couleur, marque, modele)
        {
            Style = "Spyder";
            TailleReservoir = tailleReservoir;
            Moteur = moteur;
            Roues = new Roue[] { new Roue(roue), new Roue(roue), new Roue(roue) };
            DistanceParcourue = 0;
            DureeVieKm = dureeVieKm;
            AutonomieKm = (int)Math.Floor(TailleReservoir / Moteur.ConsommationParKm);
            Couleur = couleur;
            AnneeDeProduction = 2020;
            Marque = marque;
            Modele = modele;
        }

        public override void TournerSerrer()
        {
            Console.WriteLine("Pour faire le tournant serré, vous avez simplement tourné la direction de la Spyder.");
        }
    }
}
