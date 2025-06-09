import { createSelector } from "@ngrx/store";
import { AppState } from "../types/appState";

export const selectFeature = (state: AppState) => state.workspaces


export const selectIsLoadingWorkspace = createSelector(
    selectFeature,
    (state) => state.isLoading
);

export const workspaceSelector = createSelector(
    selectFeature,
    (state) => state.workspaces
);

export const selectWorkspaceError = createSelector(
    selectFeature,
    (state) => state.error
);

export const selectWorkspacesByCoworkingId = (coworkingId: number) => createSelector(
    workspaceSelector,
    (workspaces) => workspaces.filter(ws => ws.coworkingId === coworkingId)
);