export class Epargne {

  type: string;
  anneeDepart: number;
  montant: number;
  tauxInteret: number;
  abondement: number;
  duree: number;
  anneeEnCours: number;

  constructor(type: string, anneeDepart: number, montant: number, tauxInteret: number, abondement: number, duree: number, anneeEnCours: number) {
    this.type = type;
    this.anneeDepart = anneeDepart;
    this.montant = montant;
    this.tauxInteret = tauxInteret;
    this.abondement = abondement;
    this.duree = duree;
    this.anneeEnCours = anneeEnCours;
  }
} 
