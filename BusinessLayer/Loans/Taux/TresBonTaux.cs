using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Loans.Taux
{
    public class TresBonTaux : TauxAnnuel
    {
        public TresBonTaux()
        {
            Valeur = 0;
        }

        public override void CalculerTaux(double dureeEmprunt)
        {
            if (dureeEmprunt <= 7)
            {
                Valeur = 0.0043;
            }
            else if (dureeEmprunt > 7 && dureeEmprunt <= 10)
            {
                Valeur = 0.0055;
            }
            else if (dureeEmprunt > 10 && dureeEmprunt <= 15)
            {
                Valeur = 0.0073;
            }
            else if (dureeEmprunt > 15 && dureeEmprunt <= 20)
            {
                Valeur = 0.0091;
            }
            else if (dureeEmprunt > 20 && dureeEmprunt <= 25)
            {
                Valeur = 0.015;
            }
        }
    }
}
