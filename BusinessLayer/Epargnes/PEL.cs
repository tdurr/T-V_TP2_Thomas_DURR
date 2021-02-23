using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Epargnes
{
    public class PEL : EpargneFondsBloques
    {
        private static readonly int DUREE_DU_CUMUL_DES_INTERETS = 15;

        public override void Abonder(double argentAajouter)
        {
            if (AnneeDeDepart + 10 >= AnneeEnCours)
            {
                Montant += argentAajouter;
            }
            else
            {
                Abondement = 0;
                Console.WriteLine("Impossible d'abonder au dela des 10 ans d'ancienneté du plan");
            }
        }

        public override void CalculerPrevisionPourAnnee()
        {
            try
            {
                if ((AnneeEnCours - AnneeDeDepart) <= DUREE_DU_CUMUL_DES_INTERETS)
                {
                    CalculerInterets();
                }
                else
                {
                    TauxInteret = 0;
                    Console.WriteLine("Ne génère plus d'intérêts après 15 ans");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
