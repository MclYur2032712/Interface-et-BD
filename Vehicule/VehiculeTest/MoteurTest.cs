using ConsoleApp2;

namespace VehiculeTest
{
    [TestClass]
    public class MoteurTest
    {
        private int taille;
        private int nbCylindres;
        private int puissanceChevauxVapeur;
        private double consommationParKm;
        private Moteur moteur;

        [TestInitialize]
        public void Init()
        {
            taille = 100;
            nbCylindres = 6;
            puissanceChevauxVapeur = 200;
            consommationParKm = 1;

            moteur = new Moteur(taille, nbCylindres, puissanceChevauxVapeur, consommationParKm);
        }

        [TestCleanup]
        public void Clear()
        {
            taille = 0;
            nbCylindres = 0;
            puissanceChevauxVapeur = 0;
            consommationParKm = 0;

            moteur = null;
        }

        [TestMethod]
        public void Moteur_InitMoteur_ReturnSameValue()
        {
            Assert.AreEqual<int>(100, moteur.Taille);
            Assert.AreEqual<int>(6, moteur.NbCylindres);
            Assert.AreEqual<int>(200, moteur.PuissanceChevauxVapeur);
            Assert.AreEqual<double>(1, moteur.ConsommationParKm);
        }

        [TestMethod]
        public void DemarrerMoteur_ValideAffichage_Vrooooom()
        {
            const string expected = "Vrooooom !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moteur.DemarrerMoteur();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
        }

    }
}