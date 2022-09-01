using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
   public  class Moteur
    {
        private int taille;
        private int nbCylindres;
        private int puissanceChevauxVapeur;
        private double consommationParKm;

        public Moteur(int taille, int nbCylindres, int puissanceChevauxVapeur, double consommationParKm)
        {
            Taille = taille;
            NbCylindres = nbCylindres;
            PuissanceChevauxVapeur = puissanceChevauxVapeur;
            ConsommationParKm = consommationParKm;
        }

        public int Taille
        {
            get
            {
                return taille;
            }
            set
            {
                taille = value;
            }
        }
        public int NbCylindres
        {
            get
            {
                return nbCylindres;
            }
            set
            {
                nbCylindres = value;
            }
        }
        public int PuissanceChevauxVapeur
        {
            get
            {
                return puissanceChevauxVapeur;
            }
            set
            {
                puissanceChevauxVapeur = value;
            }
        }

        public double ConsommationParKm { get => consommationParKm; set => consommationParKm = value; }

        public void DemarrerMoteur()
        {
            Console.WriteLine("Vrooooom !");  
        }
    }
}
