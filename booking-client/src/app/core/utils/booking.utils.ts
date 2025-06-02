import { toLocalISOString } from "./date.utils";

export function createPatchDoc(
    name: string,
    email: string,
    selectedRoomId: number,
    selectedSeats: number,
    start: Date | string,
    end: Date | string
): any[] {
    return [
        { op: 'replace', path: '/name', value: name },
        { op: 'replace', path: '/email', value: email },
        { op: 'replace', path: '/roomId', value: selectedRoomId },
        { op: 'replace', path: '/seatsBooked', value: selectedSeats },
        { op: 'replace', path: '/startDate', value: toLocalISOString(new Date(start)) },
        { op: 'replace', path: '/endDate', value: toLocalISOString(new Date(end)) }
    ];
}