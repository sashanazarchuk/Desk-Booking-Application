import { CoworkingState } from "../coworking/coworking.state";
import { WorkspaceState } from "../workspace/workspace.state";

export interface AppState {
    coworkings: CoworkingState,
    workspaces: WorkspaceState
}