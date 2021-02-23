import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { DataService } from '../services/data.service';
import { Loan } from '../models/Loan';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-loan-calculator',
  templateUrl: './loan-calculator.component.html',
  styleUrls: ['./loan-calculator.component.css']
})
export class LoanCalculatorComponent implements OnInit {

  public responseObs: Observable<Loan[]>;
  private subscription: Subscription = null;

  calculatorForm = new FormGroup({
    anneeDepart: new FormControl('', [Validators.required, anneeDepartValidator]),
    montantBase: new FormControl('', [Validators.required, montantBaseValidator]),
    tauxNominal: new FormControl('', [Validators.required, tauxNominalValidator]),
    dureeEmprunt: new FormControl('', [Validators.required, dureeEmpruntValidator]),
    sportif: new FormControl(''),
    fumeur: new FormControl(''),
    cardiaque: new FormControl(''),
    ingeInfo: new FormControl(''),
    pilote: new FormControl(''),
  });

  get anneeDepart(): AbstractControl {
    return this.calculatorForm.get('anneeDepart');
  }

  get montantBase(): AbstractControl {
    return this.calculatorForm.get('montantBase');
  }

  get tauxNominal(): AbstractControl {
    return this.calculatorForm.get('tauxNominal');
  }

  get dureeEmprunt(): AbstractControl {
    return this.calculatorForm.get('dureeEmprunt');
  }

  get sportif(): AbstractControl {
    return this.calculatorForm.get('sportif');
  }

  get fumeur(): AbstractControl {
    return this.calculatorForm.get('fumeur');
  }

  get cardiaque(): AbstractControl {
    return this.calculatorForm.get('cardiaque');
  }

  get ingeInfo(): AbstractControl {
    return this.calculatorForm.get('ingeInfo');
  }

  get pilote(): AbstractControl {
    return this.calculatorForm.get('pilote');
  }

  constructor(private dataService: DataService) {
  }

  ngOnInit(): void {

  }

  onSubmit(): void {

    if (!this.calculatorForm.valid) {
      return;
    }

    let assurance: number = 0.30;
    if (this.calculatorForm.value.sportif != '') {
      assurance -= 0.05;
    }

    if (this.calculatorForm.value.fumeur != '') {
      assurance += 0.15;
    }

    if (this.calculatorForm.value.cardiaque != '') {
      assurance += 0.30;
    }

    if (this.calculatorForm.value.ingeInfo != '') {
      assurance -= 0.05;
    }

    if (this.calculatorForm.value.pilote != '') {
      assurance += 0.15;
    }
    console.log(assurance);

    const newLoan: Loan = new Loan(
      this.calculatorForm.value.anneeDepart,
      this.calculatorForm.value.montantBase,
      0,
      0,
      this.calculatorForm.value.tauxNominal,
      assurance,
      0,
      this.calculatorForm.value.dureeEmprunt,
      0,
    )

    this.responseObs = this.dataService.calculerLoan(newLoan);
    this.goTab();
  }

  fillInputs(): void {
    this.calculatorForm.controls.anneeDepart.setValue('2021');
    this.calculatorForm.controls.montantBase.setValue('30000');
    this.calculatorForm.controls.tauxNominal.setValue('Bon taux');
    this.calculatorForm.controls.dureeEmprunt.setValue('15');
  }

  goTab(): void {
    let el = document.getElementById('bottom');
    el.scrollIntoView();
  }
}

export function tauxNominalValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /(?:^|(?<= ))(Bon taux|Très bon taux|Excellent taux)(?:(?= )|$)/;
  return regex.test(control.value) ? null : { test: true };
}

export function anneeDepartValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /^\d{4}$/;
  return regex.test(control.value) ? null : { test: true };
}

export function montantBaseValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /^\d*\.?\d*$/;
  return regex.test(control.value) ? null : { test: true };
}

export function dureeEmpruntValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /^\d*\.?\d*$/;
  return regex.test(control.value) ? null : { test: true };
}
