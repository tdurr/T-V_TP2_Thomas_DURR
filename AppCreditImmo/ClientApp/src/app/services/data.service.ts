import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Epargne } from '../models/Epargne';
import { Loan } from '../models/Loan';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  calculerEpargne(e: Epargne): Observable<Epargne[]> {
    return this.http.get<Epargne[]>(environment.baseUrl + 'api/InterestCalculator/Previsions/' + e.type + '/' + e.anneeDepart + '/' + e.montant + '/' + e.abondement + '/' + e.duree);
  }

  calculerLoan(loan: Loan): Observable<Loan[]> {
    return this.http.post<Loan[]>(environment.baseUrl + 'api/LoanCalculator/Previsions', loan);
  }
}
