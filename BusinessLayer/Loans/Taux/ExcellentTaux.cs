using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Loans.Taux
{
    public class ExcellentTaux : TauxAnnuel
    {
        public ExcellentTaux()
        {
            Valeur = 0;
        }

        public override void CalculerTaux(double dureeEmprunt)
        {
            if (dureeEmprunt <= 7)
            {
                Valeur = 0.0035;
            }
            else if (dureeEmprunt > 7 && dureeEmprunt <= 10)
            {
                Valeur = 0.0045;
            }
            else if (dureeEmprunt > 10 && dureeEmprunt <= 15)
            {
                Valeur = 0.0058;
            }
            else if (dureeEmprunt > 15 && dureeEmprunt <= 20)
            {
                Valeur = 0.0073;
            }
            else if (dureeEmprunt > 20 && dureeEmprunt <= 25)
            {
                Valeur = 0.0089;
            }
        }
    }
}
