import {
  Component,
  AfterViewInit,
  ElementRef,
  ViewChild,
  Inject,
  PLATFORM_ID,
  Input,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import Chart from 'chart.js/auto';
import { cashFlowEntry } from '../models/cash-flow-entry';


@Component({
  selector: 'app-content',
  imports: [],
  templateUrl: './content.component.html',
  styleUrl: './content.component.scss'
})
export class ContentComponent implements AfterViewInit, OnChanges {
  @ViewChild('lineCanvas', { static: false }) lineCanvas!: ElementRef;
  @Input() data: Array<cashFlowEntry> = []; // Input property for parent data
  private chart!: Chart;

  constructor(@Inject(PLATFORM_ID) private platformId: object) {}

  ngAfterViewInit() {
    if (isPlatformBrowser(this.platformId)) {
      setTimeout(() => {
        this.createChart();
      }, 100);
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['data'] && !changes['data'].firstChange) {
      this.updateChart();
    }
  }

  createChart() {
    if (!this.lineCanvas) return;

    const labels = this.data.map((d) => new Date(d.date).toLocaleDateString());
    const incomeData = this.data.map((d) => d.income);
    const outcomeData = this.data.map((d) => d.outcome);
    const revenueData = this.data.map((d) => d.revenue);

    this.chart = new Chart(this.lineCanvas.nativeElement, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Income',
            data: incomeData,
            borderColor: 'red',
            fill: true,
          },
          {
            label: 'Outcome',
            data: outcomeData,
            borderColor: 'blue',
            fill: true,
          },
          {
            label: 'Revenue',
            data: revenueData,
            borderColor: 'green',
            fill: true,
          },
        ],
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        scales: {
          x: {
            grid: { display: false },
          },
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  updateChart() {
    if (this.chart) {
      this.chart.data.labels = this.data.map((d) =>
        new Date(d.date).toLocaleDateString()
      );
      this.chart.data.datasets[0].data = this.data.map((d) => d.income);
      this.chart.data.datasets[1].data = this.data.map((d) => d.outcome);
      this.chart.data.datasets[2].data = this.data.map((d) => d.revenue);
      this.chart.update();
    }
  }
}

