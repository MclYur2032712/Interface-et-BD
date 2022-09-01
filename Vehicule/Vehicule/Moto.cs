using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Moto : Vehicule
    {
        private Moteur moteur;
        private Roue[] roues;
        private string style;
        private int tailleReservoir;
        private double distanceParcourue;

        public Moto(int dureeVieKm, string style, int tailleReservoir, Moteur moteur, Roue roue, string couleur, string marque, string modele)
        {
            Style = style;
            TailleReservoir = tailleReservoir;
            Moteur = moteur;
            roues = new Roue[]{ new Roue(roue), new Roue(roue) };
            DistanceParcourue = 0;
            DureeVieKm = dureeVieKm;
            AutonomieKm = (int)Math.Floor(TailleReservoir / Moteur.ConsommationParKm);
            Couleur = couleur;
            AnneeDeProduction = 2021;
            Marque = marque;
            Modele = modele;
        }

        public string Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
            }
        }
        public int TailleReservoir
        {
            get
            {
                return tailleReservoir;
            }
            set
            {
                tailleReservoir = value;
            }
        }
        public Moteur Moteur
        {
            get
            {
                return moteur;
            }
            set
            {
                moteur = value;
            }
        }
        public Roue[] Roues
        {
            get
            {
                return roues;
            }
            set
            {
                roues = value;
            }
        }
        public double DistanceParcourue
        {
            get
            {
                return distanceParcourue;
            }
            set
            {
                distanceParcourue = value;
            }
        }

        public override void Demarrer()
        {
            //code pris à https://stackoverflow.com/questions/30799107/change-the-console-foregroundcolor-from-a-string
            ConsoleColor consoleColor = ConsoleColor.White;
            try
            {
                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Couleur, true);
            }
            catch (Exception)
            {
                consoleColor = ConsoleColor.White;
            }

            Console.ForegroundColor = consoleColor;
            Moteur.DemarrerMoteur();
        }

        public void Rouler(int km)
        {
            int kmRestant = km;
            while (kmRestant > AutonomieKm)
            {
                Console.WriteLine("Vous avez roulé {0} km. Vous devez faire le plein avant de continuer le voyage.", AutonomieKm);
                DiminuerPression();
                FaireLePlein();
                kmRestant -= AutonomieKm;
            }
                           
            Console.WriteLine("Vous avez roulé {0} km !", kmRestant);

            FaireLePlein();
            AjouterUsure(km);

            Console.WriteLine("Le voyage est fini.");
            Console.WriteLine();
        }

        public void DiminuerPression()
        {
            for(int i = 0; i < Roues.Length; i++)
            {
                Roues[i].Pression--;
            }
        }

        public void AjouterPression()
        {
            for (int i = 0; i < Roues.Length; i++)
            {
                if(Roues[i].Pression < 25)
                {
                    int pressionManquante = 35 - Roues[i].Pression;
                    Roues[i].GonflerPneu(pressionManquante);
                }
            }
        }
        public void FaireLePlein()
        {
            TournerSerrer();
            AjouterPression();
            Console.WriteLine("Vous avez fait le plein !");
        }

        public virtual void TournerSerrer()
        {
            Console.WriteLine("Pour faire le tournant serré, vous avez dû incliner la moto.");
        }

        public void AjouterUsure(int distance)
        {
            DistanceParcourue += distance;

            if(DistanceParcourue >= this.DureeVieKm)
            {
                Console.WriteLine("Votre {0} a dépassée ça durée de vie, elle peut vous lâcher à tout moment !", this.GetType().Name);
            }
        }
    }
}
