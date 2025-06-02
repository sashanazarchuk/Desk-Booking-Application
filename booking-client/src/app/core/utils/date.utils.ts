import { DateTimePickerComponent } from "../../date-time-picker/date-time-picker.component";


export function combineDateTime(date: Date, time: Date): string {
    const combined = new Date(date);
    combined.setHours(time.getHours());
    combined.setMinutes(time.getMinutes());

    const year = combined.getFullYear();
    const month = String(combined.getMonth() + 1).padStart(2, '0');
    const day = String(combined.getDate()).padStart(2, '0');
    const hours = String(combined.getHours()).padStart(2, '0');
    const minutes = String(combined.getMinutes()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}`;
}



export function updateCalendar(calendar: DateTimePickerComponent, startDate: Date, endDate: Date): void {
    const start = new Date(startDate);
    const end = new Date(endDate);

    calendar.startDate = start;
    calendar.endDate = end;
    calendar.startTime = new Date(0, 0, 0, start.getHours(), start.getMinutes());
    calendar.endTime = new Date(0, 0, 0, end.getHours(), end.getMinutes());
}


export function toLocalISOString(date: Date): string {
    const pad = (n: number): string => n.toString().padStart(2, '0');

    const year = date.getFullYear();
    const month = pad(date.getMonth() + 1);
    const day = pad(date.getDate());
    const hours = pad(date.getHours());
    const minutes = pad(date.getMinutes());
    const seconds = pad(date.getSeconds());

    return `${year}-${month}-${day}T${hours}:${minutes}:${seconds}`;
}
