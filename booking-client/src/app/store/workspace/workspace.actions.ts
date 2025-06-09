import { createAction, props } from "@ngrx/store";
import { Workspace } from "../../core/models/workspace.model";

//Load Workspaces by Coworking Id
export const loadWorkspaceByCoworkingId = createAction('[Workspace] Load Workspaces by Coworking Id', props<{ workspaceId: number }>());
export const loadWorkspaceByCoworkingIdSuccess = createAction('[Workspace] Load Workspaces by Coworking Id Success', props<{ workspaces: Workspace[] }>());
export const loadWorkspaceByCoworkingIdFailure = createAction('[Workspace] Load Workspaces by Coworking Id Failure', props<{ error: string }>());
