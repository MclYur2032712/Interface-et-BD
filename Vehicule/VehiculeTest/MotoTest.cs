using ConsoleApp2;

namespace VehiculeTest
{
    [TestClass]
    public class MotoTest
    {
        private int dureeVieKm;
        private int autonomieKm;
        private string couleur;
        private int anneeDeProduction;
        private string marque;
        private string modele;
        private Moteur moteur;
        private Roue roue;
        private string style;
        private int tailleReservoir;
        private double distanceParcourue;
        private Moto moto;

        [TestInitialize]
        public void Init()
        {
            style = "Chopper";
            tailleReservoir = 30;
            moteur = new Moteur(100, 6, 200, 1);
            roue = new Roue(200, 45, 16, 90, 'V', 30, "Été");
            distanceParcourue = 0;
            dureeVieKm = 100;
            autonomieKm = (int)Math.Floor(tailleReservoir / moteur.ConsommationParKm);
            couleur = "Red";
            anneeDeProduction = 2021;
            marque = "Harley Davidson";
            modele = "Street Bob";

            moto = new Moto(100, "Chopper", 30, moteur, roue, "Red", "Harley Davidson", "Street Bob");
        }

        [TestCleanup]
        public void Clear()
        {
            style = "null";
            tailleReservoir = 0;
            moteur = null;
            roue = null;
            distanceParcourue = 0;
            dureeVieKm = 100;
            autonomieKm = 0;
            couleur = "null";
            anneeDeProduction = 0;
            marque = "null";
            modele = "null";

            moto = null;
        }

        [TestMethod]
        public void Moto_InitParametre_ReturnSame()
        {
            Assert.AreEqual<int>(100, moto.DureeVieKm);
            Assert.AreEqual<string>("Red", moto.Couleur);
            Assert.AreEqual<int>(2021, moto.AnneeDeProduction);
            Assert.AreEqual<string>("Harley Davidson", moto.Marque);
            Assert.AreEqual<string>("Street Bob", moto.Modele);

            Assert.AreEqual<Moteur>(moteur, moto.Moteur);
            //just comparer les roues ne marchait pas, donc j'ai fait la version longue
            Assert.AreEqual<int>(roue.Largeur, moto.Roues[1].Largeur);
            Assert.AreEqual<int>(roue.PourcentageHauteur, moto.Roues[1].PourcentageHauteur);
            Assert.AreEqual<int>(roue.DiametreJante, moto.Roues[1].DiametreJante);
            Assert.AreEqual<int>(roue.IndiceCharge, moto.Roues[1].IndiceCharge);
            Assert.AreEqual<char>(roue.IndiceVitesse, moto.Roues[1].IndiceVitesse);
            Assert.AreEqual<int>(roue.Pression, moto.Roues[1].Pression);
            Assert.AreEqual<string>(roue.Type, moto.Roues[1].Type);

            Assert.AreEqual<int>(roue.Largeur, moto.Roues[0].Largeur);
            Assert.AreEqual<int>(roue.PourcentageHauteur, moto.Roues[0].PourcentageHauteur);
            Assert.AreEqual<int>(roue.DiametreJante, moto.Roues[0].DiametreJante);
            Assert.AreEqual<int>(roue.IndiceCharge, moto.Roues[0].IndiceCharge);
            Assert.AreEqual<char>(roue.IndiceVitesse, moto.Roues[0].IndiceVitesse);
            Assert.AreEqual<int>(roue.Pression, moto.Roues[0].Pression);
            Assert.AreEqual<string>(roue.Type, moto.Roues[0].Type);

            Assert.AreEqual<string>("Chopper", moto.Style);
            Assert.AreEqual<int>(30, moto.TailleReservoir);
            Assert.AreEqual<double>(0, moto.DistanceParcourue);

            int expected = (int)Math.Floor(tailleReservoir / moteur.ConsommationParKm);
            Assert.AreEqual<int>(expected, moto.AutonomieKm);
        }

        [TestMethod]
        public void Demarrer_ValideAffichage_Vrooooom()
        {
            const string expected = "Vrooooom !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.Demarrer();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
        }
        [TestMethod]
        public void DiminuerPression_DiminutionPression_DebutMoinsUn()
        {
            int pressionInitialeA = moto.Roues[0].Pression;
            int pressionInitialeB = moto.Roues[1].Pression;
            moto.DiminuerPression();
            Assert.AreEqual<int>(pressionInitialeA - 1, moto.Roues[0].Pression);
            Assert.AreEqual<int>(pressionInitialeB - 1, moto.Roues[1].Pression);
        }
        [TestMethod]
        public void AjouterPression_AugmentationPression_PressionTrenteCinq()
        {
            moto.Roues[0].Pression = 0;
            moto.Roues[1].Pression = 0;
            moto.AjouterPression();
            Assert.AreEqual<int>(35, moto.Roues[0].Pression);
            Assert.AreEqual<int>(35, moto.Roues[1].Pression);
        }

        [TestMethod]
        public void TournerSerrer_PhraseSortie_BonnePhrase()
        {
            const string expected = "Pour faire le tournant serré, vous avez dû incliner la moto.";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.TournerSerrer();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
        }
        [TestMethod]
        public void FaireLePlein_AucunePression_BonnePhrase()
        {
            moto.Roues[0].Pression = 0;
            moto.Roues[1].Pression = 0;

            string expected = "Pour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez gonflé le pneu.\r\nVous avez gonflé le pneu.\r\nVous avez fait le plein !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.FaireLePlein();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }

            Assert.AreEqual<int>(35, moto.Roues[0].Pression);
            Assert.AreEqual<int>(35, moto.Roues[1].Pression);
        }

        [TestMethod]
        public void FaireLePlein_PressionVingtSept_BonnePhrase()
        {
            moto.Roues[0].Pression = 27;
            moto.Roues[1].Pression = 27;

            string expected = "Pour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.FaireLePlein();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }

            Assert.AreEqual<int>(27, moto.Roues[0].Pression);
            Assert.AreEqual<int>(27, moto.Roues[1].Pression);
        }

        [TestMethod]
        public void AjouterUsure_UsurePlusGrande_MessageSorti()
        {
            const string expected = "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.AjouterUsure(1000);

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
            Assert.AreEqual<double>(1000, moto.DistanceParcourue);
        }
        [TestMethod]
        public void AjouterUsure_UsurePlusPetite_MessageSorti()
        {
            const string expected = "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.AjouterUsure(10);

                var result = sw.ToString().Trim();
                Assert.AreNotEqual<string>(expected, result);
            }
            Assert.AreEqual<double>(10, moto.DistanceParcourue);
        }

        [TestMethod]
        public void Rouler_DistanceInferieurUsure_PasMessageUsusre()
        {
            const string expected = "Vous avez roulé 30 km. Vous devez faire le plein avant de continuer le voyage.\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVous avez roulé 20 km !\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nLe voyage est fini.";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.Rouler(50);

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
            Assert.AreEqual<double>(50, moto.DistanceParcourue);
        }

        [TestMethod]
        public void Rouler_DistanceSuperieurUsure_MessageUsusrePresent()
        {
            const string expected = "Vous avez roulé 30 km. Vous devez faire le plein avant de continuer le voyage.\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVous avez roulé 30 km. Vous devez faire le plein avant de continuer le voyage.\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVous avez roulé 30 km. Vous devez faire le plein avant de continuer le voyage.\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVous avez roulé 30 km. Vous devez faire le plein avant de continuer le voyage.\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVous avez roulé 30 km !\r\nPour faire le tournant serré, vous avez dû incliner la moto.\r\nVous avez fait le plein !\r\nVotre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !\r\nLe voyage est fini.";
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moto.Rouler(150);

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
            Assert.AreEqual<double>(150, moto.DistanceParcourue);
        }
    }
}
