export {}


declare global {

    interface Date {
        toInputDateString(withTime?: boolean): string;
        toLocaleDisplayString(locale: string): string;

    }
}

 Date.prototype.toInputDateString = function (withTime: boolean = true): string {
    let dateString = `${this.getFullYear()}-${pad((this.getMonth() + 1), 2)}-${pad(this.getDate(), 2)}`;

    if(withTime) {
        dateString += `T${pad(this.getHours(), 2)}:${pad(this.getMinutes(), 2)}:${pad(this.getSeconds(), 2)}.${this.getMilliseconds()}`;
    }
    return dateString;
}

Date.prototype.toLocaleDisplayString = function (locale: string): string {
    return this.toLocaleString(locale, { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', hour12: true });
}

function pad(num: number, size: number): string {
    let s = num + '';
    while (s.length < size) s = '0' + s;
    return s;
}
 