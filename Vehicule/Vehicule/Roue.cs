using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Roue
    {
        private int largeur;
        private int pourcentageHauteur;
        private int diametreJante;
        private int indiceCharge;
        private char indiceVitesse;
        private int pression;
        private string type;

        public Roue(int largeur, int pourcentageHauteur, int diametreJante, int indiceCharge, char indiceVitesse, int pression, string type)
        {
            Largeur = largeur;
            PourcentageHauteur = pourcentageHauteur;
            DiametreJante = diametreJante;
            IndiceCharge = indiceCharge;
            IndiceVitesse = indiceVitesse;
            Pression = pression;
            Type = type;
        }

        public Roue(Roue modele)
        {
            Largeur = modele.Largeur;
            PourcentageHauteur = modele.PourcentageHauteur;
            DiametreJante = modele.DiametreJante;
            IndiceCharge = modele.IndiceCharge;
            IndiceVitesse = modele.IndiceVitesse;
            Pression = modele.Pression;
            Type = modele.Type;
        }

        public int Largeur
        {
            get
            {
                return largeur;
            }
            set
            {
                largeur = value;
            }
        }
        public int PourcentageHauteur
        {
            get
            {
                return pourcentageHauteur;
            }
            set
            {
                pourcentageHauteur = value;
            }
        }
        public int DiametreJante
        {
            get
            {
                return diametreJante;
            }
            set
            {
                diametreJante = value;
            }
        }
        public int IndiceCharge
        {
            get
            {
                return indiceCharge;
            }
            set
            {
                indiceCharge = value;
            }
        }
        public char IndiceVitesse
        {
            get
            {
                return indiceVitesse;
            }
            set
            {
                indiceVitesse = value;
            }
        }
        public int Pression
        {
            get
            {
                return pression;
            }
            set
            {
                pression = value;
            }
        }
        public string Type { get => type; set => type = value; }

        public void GonflerPneu(int ajoutPression)
        {
            Pression += ajoutPression;
            Console.WriteLine("Vous avez gonflé le pneu.");
        }
    }
}
