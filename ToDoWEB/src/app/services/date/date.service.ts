import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateService {
  toInputDateString(date: Date, withTime: boolean = true): string {
    let dateString = `${date.getFullYear()}-${this.pad(date.getMonth() + 1, 2)}-${this.pad(date.getDate(), 2)}`;

    if (withTime) {
      dateString += `T${this.pad(date.getHours(), 2)}:${this.pad(date.getMinutes(), 2)}:${this.pad(date.getSeconds(), 2)}.${date.getMilliseconds()}`;
    }

    return dateString;
  }

  private pad(num: number, size: number): string {
    let s = num + '';
    while (s.length < size) s = '0' + s;
    return s;
  }

  constructor() { }
}
