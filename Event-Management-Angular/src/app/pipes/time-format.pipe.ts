import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeFormat'
})
export class TimeFormatPipe implements PipeTransform {
  transform(value: string): string {
    value = value.split('T')[1];
    const [hours, minutes, seconds] = value.split(':').map(Number);
    const period = hours >= 12 ? 'PM' : 'AM';
    const adjustedHours = hours % 12 || 12; // Convert 24-hour to 12-hour format
    return `${this.pad(adjustedHours)}:${this.pad(minutes)} ${period}`;
  }

  private pad(num: number): string {
    return num < 10 ? '0' + num : num.toString();
  }
}