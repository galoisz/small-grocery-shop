import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import moment, { Moment } from 'moment';

@Component({
  selector: 'app-header',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  dateForm: FormGroup;
  @Output() dateRangeChange = new EventEmitter<{
    fromDate: Moment;
    toDate: Moment;
  }>();
  @Input() isLoading: boolean = false;
  @Input() errorMessage: string = '';

  constructor(private fb: FormBuilder) {
    const from: string = '2021-06-01';
    const to: string = '2021-12-31';
    this.dateForm = this.fb.group(
      {
        fromDate: [from, Validators.required],
        toDate: [to, Validators.required],
      },
      { validators: this.dateRangeValidator.bind(this) }
    );
  }

  dateRangeValidator(group: FormGroup) {
    this.errorMessage = '';
    const fromDate = group.get('fromDate')?.value;
    const toDate = group.get('toDate')?.value;

    if (!fromDate || !toDate) {
      return null;
    }

    return moment(fromDate).isSameOrBefore(moment(toDate))
      ? null
      : { dateRangeInvalid: true };
  }

  applyFilter() {
    if (this.dateForm.valid) {
      this.dateRangeChange.emit({
        fromDate: moment(this.dateForm.value.fromDate),
        toDate: moment(this.dateForm.value.toDate),
      });
    }
  }
}
