import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatTimepickerModule } from '@angular/material/timepicker';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-date-time-picker',
  imports: [MatFormFieldModule, MatInputModule, MatTimepickerModule, MatDatepickerModule, FormsModule],
  providers: [provideNativeDateAdapter()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './date-time-picker.component.html',
  styleUrl: './date-time-picker.component.css'
})
export class DateTimePickerComponent {
  startDate: Date | null = null;
  endDate: Date | null = null;

  startTime: Date | null = null;
  endTime: Date | null = null;



  validateDateTimes(): string {
    if (!this.startDate || !this.endDate) {
      return 'Please select both a start and end date';
    }

    if (this.startDate < this.getTodayWithoutTime()) {
      return 'The start date cannot be in the past';
    }

    if (!this.startTime || !this.endTime) {
      return 'Please select both a start and end time';
    }

    const startDateTime = this.combineDateAndTime(this.startDate, this.startTime);
    const endDateTime = this.combineDateAndTime(this.endDate, this.endTime);

    if (endDateTime <= startDateTime) {
      return 'End date and time must be after start date';
    }

    return '';
  }


  private getTodayWithoutTime(): Date {
    const now = new Date();
    return new Date(now.getFullYear(), now.getMonth(), now.getDate());
  }


  private combineDateAndTime(date: Date, time: Date): Date {
    const combined = new Date(date);
    combined.setHours(time.getHours(), time.getMinutes(), 0, 0)
    return combined;
  }
}
