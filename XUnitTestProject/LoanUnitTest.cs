using System;
using Xunit;
using BusinessLayer.Loans;
using BusinessLayer.Loans.Taux;

namespace XUnitTestProject
{
    [Trait("Loan", "Calculator")]
    public class LoanUnitTest
    {
        Loan Loan { get; set; }
        public LoanUnitTest()
        {
            Loan = new Loan();
            TauxAnnuel taux = new BonTaux();
            taux.CalculerTaux(10);
            Loan.AnneeDeDepart = 2000;
            Loan.MontantEmprunte = 10000;
            Loan.MontantRestantARembourser = 10000;
            Loan.TauxNominal = taux;
            Loan.Assurance = 0.3;
            Loan.Duree = 10;
        }


        [Fact]
        public void TestTypeCorrectLoan()
        {
            Assert.IsType<Loan>(new Loan());
        }

        [Fact]
        public void TestCopieLoan()
        {
            Loan copie = Loan.DeepCopy();
            Assert.Equal(Loan.AnneeDeDepart, copie.AnneeDeDepart);
            Assert.Equal(Loan.MontantEmprunte, copie.MontantEmprunte);
            Assert.Equal(Loan.MontantRestantARembourser, copie.MontantRestantARembourser);
            Assert.Equal(Loan.TauxNominal, copie.TauxNominal);
            Assert.Equal(Loan.Assurance, copie.Assurance);
            Assert.Equal(Loan.Duree, copie.Duree);
        }

        [Theory]
        [InlineData(86.179424306254461, 25, 9916.6666666666661, 27.846090972921122)]
        public void TestCalculPrevisionPourLeMois(double mensualite, double prixAssurance, double montantRestantARembourser, double coutDuCredit)
        {
            Loan.CalculerPrevisionPourMois();
            Assert.Equal(Math.Round(Loan.Mensualite, 2), Math.Round(mensualite, 2));
            Assert.Equal(Math.Round(Loan.PrixAssuranceMensuel, 2), Math.Round(prixAssurance, 2));
            Assert.Equal(Math.Round(Loan.MontantRestantARembourser, 2), Math.Round(montantRestantARembourser, 2));
            Assert.Equal(Math.Round(Loan.Cout, 2), Math.Round(coutDuCredit, 2));
        }
    }
}
