using ConsoleApp2;

namespace VehiculeTest
{
    [TestClass]
    public class SpyderTest
    {
        private Moteur moteur;
        private Roue roue;
        private Spyder spyder;

        [TestInitialize]
        public void Initialize()
        {
            moteur = new Moteur(100, 6, 200, 1);
            roue = new Roue(200, 45, 16, 90, 'V', 30, "Été");
            spyder = new Spyder(100, 30, moteur, roue, "Yellow", "Can-Am", "F3 SE6");
        }
        [TestMethod]
        public void Spyder_Style_StyleSpyder()
        {
            Assert.AreEqual<string>("Spyder", spyder.Style);
        }

        [TestMethod]
        public void TournerSerrer_PhraseSortie_BonnePhrase()
        {
            const string expected = "Pour faire le tournant serré, vous avez simplement tourné la direction de la Spyder.";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                spyder.TournerSerrer();

                var result = sw.ToString().Trim();
                Assert.AreEqual<string>(expected, result);
            }
        }
    }

    
}
