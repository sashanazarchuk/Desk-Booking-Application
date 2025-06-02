import { Room } from "./room.model";
import { Workspace } from "./workspace.model";

export interface Booking {
  id: number;
  name: string;
  email: string;
  roomId: number;
  rooms: Room;
  workspace: Workspace;
  startDate: string;   
  endDate: string;
  seatsBooked: number;
}

export interface BookingCreatePayload {
  name: string;
  email: string;
  roomId: number;
  seatsToBook?: number;
  room?: number;
  startDate: string;
  endDate: string;
}