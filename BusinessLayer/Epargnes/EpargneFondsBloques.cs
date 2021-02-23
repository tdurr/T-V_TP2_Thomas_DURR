using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Epargnes
{
    public class EpargneFondsBloques : EpargnePlafonnee
    {
        public int DureeDeBlocage { get; set; }

        public override void Retirer(double argentAretirer)
        {
            if (AnneeDeDepart + DureeDeBlocage > AnneeEnCours)
            {
                Console.WriteLine("retrait avant {0} an(s), cloture de l'épargne", DureeDeBlocage);
                Montant = 0;
            }
            else
            {
                Montant -= argentAretirer;
            }
        }
    }
}
