import { WorkspaceState } from "./workspace.state";
import { createReducer, on } from "@ngrx/store";
import * as WorkspaceActions from './workspace.actions'

export const initialState: WorkspaceState = {
    isLoading: false,
    workspaces: [],
    error: null
}

export const workspaceReducer = createReducer(
    initialState,

    on(WorkspaceActions.loadWorkspaceByCoworkingId, (state) => ({
        ...state,
        isLoading: true
    })),

    on(WorkspaceActions.loadWorkspaceByCoworkingIdSuccess, (state, { workspaces }) => ({
        ...state,
        workspaces: workspaces,
        isLoading: false
    })),
    
    on(WorkspaceActions.loadWorkspaceByCoworkingIdFailure, (state, { error }) => ({
        ...state,
        isLoading: false,
        error
    }))
);