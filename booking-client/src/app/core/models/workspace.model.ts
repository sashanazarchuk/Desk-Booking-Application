import { Amenity } from "./amenity.model";
import { Room } from "./room.model";
import { WorkspacePhoto } from "./workspace-photo.model";

export interface Workspace {
  id: number;
  name: string;
  description: string;
  rooms: Room[];
  photos: WorkspacePhoto[];
  amenities: Amenity[];
}

export enum WorkspaceType {
  OpenSpace = 'OpenSpace',
  PrivateRoom = 'PrivateRoom',
  MeetingRoom = 'MeetingRoom'
}