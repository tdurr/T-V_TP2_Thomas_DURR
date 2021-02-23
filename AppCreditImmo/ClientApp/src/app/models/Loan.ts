export class Loan {
  anneeDepart: number;
  montantEmprunte: number;
  montantRestantARembourser: number;
  mensualite: number;
  tauxNominal: string;
  assurance: number;
  prixAssuranceMensuel: number;
  duree: number;
  cout: number


  constructor(anneeDepart: number, montantEmprunte: number, montantRestantARembourser: number, mensualite: number, tauxNominal: string, assurance: number, prixAssuranceMensuel: number, duree: number, cout: number) {
    this.anneeDepart = anneeDepart;
    this.montantEmprunte = montantEmprunte;
    this.montantRestantARembourser = montantRestantARembourser;
    this.mensualite = mensualite;
    this.tauxNominal = tauxNominal;
    this.assurance = assurance;
    this.prixAssuranceMensuel = prixAssuranceMensuel;
    this.duree = duree;
    this.cout = cout;
  }
} 
