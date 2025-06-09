import { Workspace } from "../../core/models/workspace.model";

export interface WorkspaceState {
    isLoading: boolean;
    workspaces: Workspace[];
    error: string | null;
}