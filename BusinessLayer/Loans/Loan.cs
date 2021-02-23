using System;
using BusinessLayer.Loans.Taux;

namespace BusinessLayer.Loans
{
    public class Loan
    {
        public int AnneeDeDepart { get; set; }
        public double MontantEmprunte { get; set; }
        public double MontantRestantARembourser { get; set; }
        public double Mensualite { get; set; }
        public TauxAnnuel TauxNominal { get; set; }
        public double Assurance { get; set; }
        public double PrixAssuranceMensuel { get; set; }
        public double Duree { get; set; }
        public double Cout { get; set; }

        protected static readonly int Mois = 12;
        public string tauxNominal;

        public void CalculerPrevisionPourMois()
        {
            try
            {
                CalculerMensualite(Duree);
                CalculerPrixAssuranceMensuel();
                CalculerCoutTotalDuCredit();
                CalculerMontantRestantARembourser();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        protected void CalculerMensualite(double duree)
        {
            double numerateur = MontantEmprunte * TauxNominal.Valeur / Mois * Math.Pow(1 + TauxNominal.Valeur / Mois, Mois * Duree);
            double denominateur = Math.Pow(1 + TauxNominal.Valeur / Mois, Mois * Duree) - 1;
            Mensualite = numerateur / denominateur;
            //double numerateur = MontantEmprunte * (TauxNominal.Valeur / Mois);
            //double denominateur = 1 - Math.Pow((1 + TauxNominal.Valeur / Mois), Duree * Mois);
            //Mensualite = Math.Abs(numerateur / denominateur);
        } 

        protected void CalculerMontantRestantARembourser()
        {
            MontantRestantARembourser -= MontantEmprunte / (Duree * Mois);
        }

        protected void CalculerPrixAssuranceMensuel()
        {
            PrixAssuranceMensuel = (MontantRestantARembourser * Assurance) / (Duree * Mois);
        }

        protected void CalculerCoutTotalDuCredit()
        {

            Cout += (Mois * Duree * Mensualite - MontantEmprunte) / (Duree * Mois) + PrixAssuranceMensuel;
        }

        public Loan DeepCopy()
        {
            Loan clone = (Loan) this.MemberwiseClone();
            clone.AnneeDeDepart = this.AnneeDeDepart;
            clone.MontantEmprunte = this.MontantEmprunte;
            clone.MontantRestantARembourser = this.MontantRestantARembourser;
            clone.Mensualite = this.Mensualite;
            clone.TauxNominal = this.TauxNominal;
            clone.Assurance = this.Assurance;
            clone.PrixAssuranceMensuel = this.PrixAssuranceMensuel;
            clone.Duree = this.Duree;
            clone.Cout = this.Cout;
            return clone;
        }
    }
}
