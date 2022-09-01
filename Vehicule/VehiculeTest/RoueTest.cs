using ConsoleApp2;

namespace VehiculeTest
{
    [TestClass]
    public class RoueTest
    {
        private int largeur;
        private int pourcentageHauteur;
        private int diametreJante;
        private int indiceCharge;
        private char indiceVitesse;
        private int pression;
        private string type;
        private Roue roue;

        [TestInitialize]
        public void Init()
        {
            largeur = 200;
            pourcentageHauteur = 45;
            diametreJante = 16;
            indiceCharge = 90;
            indiceVitesse = 'V';
            pression = 30;
            type = "Été";
            roue = new Roue(largeur, pourcentageHauteur, diametreJante, indiceCharge, indiceVitesse, pression, type);
    }
        [TestCleanup]
        public void Clear()
        {
            largeur = 0;
            pourcentageHauteur = 0;
            diametreJante = 0;
            indiceCharge = 0;
            indiceVitesse = 'n';
            pression = 0;
            type = "null";
            roue = null;
        }

        [TestMethod]
        public void Roue_InitParametre_ReturnSame()
        {
            Assert.AreEqual<int>(200, roue.Largeur);
            Assert.AreEqual<int>(45, roue.PourcentageHauteur);
            Assert.AreEqual<int>(16, roue.DiametreJante);
            Assert.AreEqual<int>(90, roue.IndiceCharge);
            Assert.AreEqual<char>('V', roue.IndiceVitesse);
            Assert.AreEqual<int>(30, roue.Pression);
            Assert.AreEqual<string>("Été", roue.Type);
        }
        [TestMethod]
        public void Roue_InitCopie_ReturnSame()
        {
            Roue roue2 = new Roue(roue);
            Assert.AreEqual<int>(roue.Largeur, roue2.Largeur);
            Assert.AreEqual<int>(roue.PourcentageHauteur, roue2.PourcentageHauteur);
            Assert.AreEqual<int>(roue.DiametreJante, roue2.DiametreJante);
            Assert.AreEqual<int>(roue.IndiceCharge, roue2.IndiceCharge);
            Assert.AreEqual<char>(roue.IndiceVitesse, roue2.IndiceVitesse);
            Assert.AreEqual<int>(roue.Pression, roue2.Pression);
            Assert.AreEqual<string>(roue.Type, roue2.Type);
        }
        [TestMethod]
        public void GonflerPneu_PneuGonfler_ReturnSame()
        {
            Assert.AreEqual<int>(30, roue.Pression);
            const string expected = "Vous avez gonflé le pneu.";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                roue.GonflerPneu(35);

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
            
            Assert.AreEqual<int>(65, roue.Pression);

        }
    }
}
