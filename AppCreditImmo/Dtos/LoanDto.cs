namespace AppCreditImmo.Dtos
{
    public record LoanDto
    {
        public int AnneeDepart { get; set; }
        public double MontantEmprunte { get; set; }
        public double MontantRestantARembourser { get; set; }
        public double Mensualite { get; set; }
        public string TauxNominal { get; set; }
        public double Assurance { get; set; }
        public double PrixAssuranceMensuel { get; set; }
        public int Duree { get; set; }
    }
}
