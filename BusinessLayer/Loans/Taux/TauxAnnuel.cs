using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Loans.Taux
{
    public abstract class TauxAnnuel
    {
        public double Valeur { get; set; }

        public virtual void CalculerTaux(double dureeEmprunt)
        {

        }
    }
}
