using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Loans;
using BusinessLayer.Loans.Taux;
using AppCreditImmo.Dtos;

namespace AppCreditImmo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanCalculatorController : ControllerBase
    {
        private readonly ILogger<LoanCalculatorController> _logger;

        public LoanCalculatorController(ILogger<LoanCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult Previsions(LoanDto loanDto)
        {
            try
            {
                const int NB_MOIS = 12;

                TauxAnnuel tauxAnnuel;
                switch (loanDto.TauxNominal)
                {
                    case "Très bon taux":
                        tauxAnnuel = new TresBonTaux();
                        tauxAnnuel.CalculerTaux(loanDto.Duree);
                        break;
                    case "Excellent taux":
                        tauxAnnuel = new ExcellentTaux();
                        tauxAnnuel.CalculerTaux(loanDto.Duree);
                        break;
                    default:
                        tauxAnnuel = new BonTaux();
                        tauxAnnuel.CalculerTaux(loanDto.Duree);
                        break;
                }

                Loan loan = new Loan
                {
                    AnneeDeDepart = loanDto.AnneeDepart,
                    MontantEmprunte = loanDto.MontantEmprunte,
                    MontantRestantARembourser = loanDto.MontantEmprunte,
                    TauxNominal = tauxAnnuel,
                    Assurance = loanDto.Assurance,
                    Duree = loanDto.Duree,
                };

                List<Loan> previsions = new List<Loan>();
                for (int i = 0; i < loanDto.Duree * NB_MOIS; i++)
                {
                    loan.CalculerPrevisionPourMois();
                    Loan prevision = loan.DeepCopy();
                    previsions.Add(prevision);
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