using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class Vehicule
    {
        private int dureeVieKm;
        private int autonomieKm;
        private string couleur;
        private int anneeDeProduction;
        private string marque;
        private string modele;

        public Vehicule() { }

        public int DureeVieKm {
            get
            {
                return dureeVieKm;
            }
            set
            {
                dureeVieKm = value;
            }
        }
        public int AutonomieKm
        {
            get
            {
                return autonomieKm;
            }
            set
            {
                autonomieKm = value;
            }
        }
        public string Couleur
        {
            get
            {
                return couleur;
            }
            set
            {
                couleur = value;
            }
        }
        public int AnneeDeProduction
        {
            get
            {
                return anneeDeProduction;
            }
            set
            {
                anneeDeProduction = value;
            }
        }
        public string Marque
        {
            get
            {
                return marque;
            }
            set
            {
                marque = value;
            }
        }
        public string Modele
        {
            get
            {
                return modele;
            }
            set
            {
                modele = value;
            }
        }

        public abstract void Demarrer();
    }
}
