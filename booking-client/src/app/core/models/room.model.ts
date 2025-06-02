import { WorkspaceType } from "./workspace.model";

export interface Room {
  id: number;
  workspaceType: WorkspaceType;
  capacity: number;
  roomsCount: number;
  workspaceId: number;
}