using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Epargnes
{
    public class EpargnePlafonnee : Epargne
    {
        public double Plafond { get; set; }

        public override void Abonder(double argentAajouter)
        {
            if (Montant + argentAajouter >= Plafond)
            {
                if (Plafond - Montant >= 0)
                {
                    argentAajouter = Plafond - Montant;
                }
                else
                {
                    argentAajouter = 0;
                }
                Montant += argentAajouter;
                Abondement = argentAajouter;
            }
            else
            {
                Montant += argentAajouter;
            }
        }
    }
}
