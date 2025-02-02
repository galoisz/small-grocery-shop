import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Moment } from 'moment';
import { cashFlowEntry } from './models/cash-flow-entry';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'http://localhost:5000/api/CashFlow';

  constructor(private http: HttpClient) {}

  public getCashFlow(fromDate: Moment, toDate: Moment): Observable<cashFlowEntry[]> {
    const from = fromDate.format("YYYY-MM-DD");
    const to = toDate.format("YYYY-MM-DD");
    const url = `${this.apiUrl}?From=${from}&To=${to}`;
    return this.http.get<any>(url);
  }
}
