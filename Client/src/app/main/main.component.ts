import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { ContentComponent } from '../content/content.component';
import { FooterComponent } from '../footer/footer.component';
import { Moment } from 'moment';
import { DataService } from '../data.service';
import { cashFlowEntry } from '../models/cash-flow-entry';


@Component({
  selector: 'app-main',
  imports: [HeaderComponent, ContentComponent, FooterComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss',
})
export class MainComponent {
  cashEntryData: Array<cashFlowEntry>;
  isLoading: boolean = false;
  errorMessage: string = '';


  constructor(private dataService: DataService) {
    this.cashEntryData = [];
  }
  updateDateRange(range: { fromDate: Moment; toDate: Moment }) {
    console.log(range.fromDate, range.toDate);
    this.cashEntryData = [];
    this.isLoading = true;
    this.errorMessage = '';
    this.dataService.getCashFlow(range.fromDate, range.toDate).subscribe(
      (data: cashFlowEntry[]) => {
        this.cashEntryData = data;
        this.isLoading = false;
        console.log('Cash flow data:', data);
      },
      (error: any) => {
        this.cashEntryData = [];
        this.isLoading = false;
        this.errorMessage = 'Error on fetching data from server';
        console.error('Error fetching data', error);
      }
    );
  }
}
