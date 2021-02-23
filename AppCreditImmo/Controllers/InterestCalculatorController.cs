using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Epargnes;

namespace AppCreditImmo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestCalculatorController : ControllerBase
    {
        private readonly ILogger<InterestCalculatorController> _logger;

        public InterestCalculatorController(ILogger<InterestCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]/{type}/{anneeDepart}/{montant}/{abondement}/{duree}")]
        public IActionResult Previsions(string type, string anneeDepart, string montant, string abondement, string duree)
        {
            try
            {
                Epargne epargne;
                switch (type)
                {
                    case "Livret A":
                        epargne = new EpargnePlafonnee
                        {
                            Plafond = 22950,
                            Type = type,
                            AnneeDeDepart = Int32.Parse(anneeDepart),
                            Montant = Double.Parse(montant),
                            TauxInteret = 0.0075,
                            Abondement = Double.Parse(abondement),
                            AnneeEnCours = Int32.Parse(anneeDepart)
                        };
                        break;
                    case "LDD":
                        epargne = new EpargnePlafonnee
                        {
                            Plafond = 12000,
                            Type = type,
                            AnneeDeDepart = Int32.Parse(anneeDepart),
                            Montant = Double.Parse(montant),
                            TauxInteret = 0.005,
                            Abondement = Double.Parse(abondement),
                            AnneeEnCours = Int32.Parse(anneeDepart)
                        };
                        break;
                    case "PEL":
                        epargne = new PEL
                        {
                            DureeDeBlocage = 4,
                            Plafond = 61200,
                            Type = type,
                            AnneeDeDepart = Int32.Parse(anneeDepart),
                            Montant = Double.Parse(montant),
                            TauxInteret = 0.01,
                            Abondement = Double.Parse(abondement),
                            AnneeEnCours = Int32.Parse(anneeDepart)
                        };
                        break;
                    default:
                        epargne = new Epargne
                        {
                            Type = type,
                            AnneeDeDepart = Int32.Parse(anneeDepart),
                            Montant = Double.Parse(montant),
                            TauxInteret = 0.08,
                            Abondement = Double.Parse(abondement),
                            AnneeEnCours = Int32.Parse(anneeDepart)
                        };
                        break;
                }

                List<Epargne> previsions = new List<Epargne>();
                for (int i = 0; i < Double.Parse(duree); i++)
                {
                    epargne.Abonder(epargne.Abondement);
                    epargne.CalculerPrevisionPourAnnee();
                    Epargne prevision = epargne.DeepCopy();
                    previsions.Add(prevision);
                    epargne.AnneeEnCours += 1;
                }
                return Ok(previsions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex);
            }
        }
    }
}