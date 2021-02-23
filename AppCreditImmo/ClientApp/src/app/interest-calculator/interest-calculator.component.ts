import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { DataService } from '../services/data.service';
import { Epargne } from '../models/Epargne';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-interest-calculator',
  templateUrl: './interest-calculator.component.html',
  styleUrls: ['./interest-calculator.component.css']
})
export class InterestCalculatorComponent implements OnInit {

  public responseObs: Observable<Epargne[]>;
  private subscription: Subscription = null;

  calculatorForm = new FormGroup({
    placement: new FormControl('', [Validators.required, placementValidator]),
    anneeDepart: new FormControl('', [Validators.required, anneeDepartValidator]),
    montantBase: new FormControl('', [Validators.required, montantBaseValidator]),
    abondement: new FormControl('', [Validators.required, abondementValidator]),
    dureeInvestissement: new FormControl('', [Validators.required, dureeInvestissementValidator]),
  });

  get placement(): AbstractControl {
    return this.calculatorForm.get('placement');
  }

  get anneeDepart(): AbstractControl {
    return this.calculatorForm.get('anneeDepart');
  }

  get montantBase(): AbstractControl {
    return this.calculatorForm.get('montantBase');
  }

  get abondement(): AbstractControl {
    return this.calculatorForm.get('abondement');
  }

  get dureeInvestissement(): AbstractControl {
    return this.calculatorForm.get('dureeInvestissement');
  }

  constructor(private dataService: DataService) {
  }

  ngOnInit(): void {

  }

  onSubmit(): void {

    if (!this.calculatorForm.valid) {
      return;
    }

    const newEpargne: Epargne = new Epargne(
      this.calculatorForm.value.placement,
      this.calculatorForm.value.anneeDepart,
      this.calculatorForm.value.montantBase,
      null,
      this.calculatorForm.value.abondement,
      this.calculatorForm.value.dureeInvestissement,
      this.calculatorForm.value.anneeDepart,
    )

    this.responseObs = this.dataService.calculerEpargne(newEpargne);
    this.goTab();
  }

  fillInputs(): void {
    this.calculatorForm.controls.placement.setValue('LDD');
    this.calculatorForm.controls.anneeDepart.setValue('2021');
    this.calculatorForm.controls.montantBase.setValue('1000');
    this.calculatorForm.controls.abondement.setValue('0');
    this.calculatorForm.controls.dureeInvestissement.setValue('10');
  }

  goTab(): void {
    let el = document.getElementById('bottom');
    el.scrollIntoView();
  }
}

export function placementValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /(?:^|(?<= ))(Livret A|LDD|PEL|Houdini)(?:(?= )|$)/;
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

export function abondementValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /^\d*\.?\d*$/;
  return regex.test(control.value) ? null : { test: true };
}

export function dureeInvestissementValidator(control: AbstractControl): { [key: string]: boolean } | null {
  const regex: RegExp = /^\d*\.?\d*$/;
  return regex.test(control.value) ? null : { test: true };
}
