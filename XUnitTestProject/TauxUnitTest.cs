using System;
using Xunit;
using BusinessLayer.Loans.Taux;

namespace XUnitTestProject
{
    [Trait ("Taux", "Niveaux")]
    public class TauxUnitTest
    {
        [Fact]
        public void TestTypeCorrectBonTaux()
        {
            Assert.IsType<BonTaux>(new BonTaux());
        }

        [Fact]
        public void TestTypeCorrectTresBonTaux()
        {
            Assert.IsType<TresBonTaux>(new TresBonTaux());
        }

        [Fact]
        public void TestTypeCorrectExcellentTaux()
        {
            Assert.IsType<ExcellentTaux>(new ExcellentTaux());
        }

        [Theory]
        [InlineData(6, 0.0062)]
        [InlineData(8, 0.0067)]
        [InlineData(12, 0.0085)]
        [InlineData(16, 0.014)]
        [InlineData(21, 0.0127)]
        public void TestBonTaux(double duree, double resultat)
        {
            BonTaux taux = new BonTaux();
            taux.CalculerTaux(duree);
            Assert.Equal(resultat, taux.Valeur);
        }

        [Theory]
        [InlineData(6, 0.0035)]
        [InlineData(8, 0.0045)]
        [InlineData(12, 0.0058)]
        [InlineData(16, 0.0073)]
        [InlineData(21, 0.0089)]
        public void TestExcellentTaux(double duree, double resultat)
        {
            ExcellentTaux taux = new ExcellentTaux();
            taux.CalculerTaux(duree);
            Assert.Equal(resultat, taux.Valeur);
        }

        [Theory]
        [InlineData(6, 0.0043)]
        [InlineData(8, 0.0055)]
        [InlineData(12, 0.0073)]
        [InlineData(16, 0.0091)]
        [InlineData(21, 0.015)]
        public void TestTresBonTaux(double duree, double resultat)
        {
            TresBonTaux taux = new TresBonTaux();
            taux.CalculerTaux(duree);
            Assert.Equal(resultat, taux.Valeur);
        }
    }
}
