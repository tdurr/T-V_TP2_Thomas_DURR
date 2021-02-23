using System;

namespace BusinessLayer.Epargnes
{
    public class Epargne
    {
        public string Type { get; set; }
        public int AnneeDeDepart { get; set; }
        public double Montant { get; set; }
        public double TauxInteret { get; set; }
        public double Abondement { get; set; }
        public int AnneeEnCours { get; set; }

        protected static readonly int NB_CALCULS_INTERETS_PAR_AN = 24;

        public virtual void Abonder(double argentAajouter)
        {
            Montant += Abondement;
        }

        public virtual void Retirer(double argentAretirer)
        {
            if (Montant - argentAretirer <= 0)
            {
                Montant = 0;
            }
            else
            {
                Montant -= argentAretirer;
            }
        }

        public virtual void CalculerPrevisionPourAnnee()
        {
            try
            {
                CalculerInterets();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        protected void CalculerInterets()
        {
            // intérêt composé chaque quinzaines d'une année
            double corps = 1 + (TauxInteret / NB_CALCULS_INTERETS_PAR_AN);
            double exposant = NB_CALCULS_INTERETS_PAR_AN * 1;
            Montant *= Math.Pow(corps, exposant);
        } 

        public Epargne DeepCopy()
        {
            Epargne clone = (Epargne) this.MemberwiseClone();
            clone.Type = this.Type;
            clone.AnneeDeDepart = this.AnneeDeDepart;
            clone.Montant = this.Montant;
            clone.TauxInteret = this.TauxInteret;
            clone.Abondement = this.Abondement;
            clone.AnneeEnCours = this.AnneeEnCours;
            return clone;
        }
    }
}
