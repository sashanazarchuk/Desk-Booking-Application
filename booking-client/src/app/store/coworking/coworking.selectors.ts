import { createSelector } from "@ngrx/store";
import { AppState } from "../types/appState";

export const selectFeature = (state: AppState) => state.coworkings

export const isLoadingSelector = createSelector(
    selectFeature,
    (state) => state.isLoading
);

export const coworkingSelector = createSelector(
    selectFeature,
    (state) => state.coworkings
);

export const errorSelector = createSelector(
    selectFeature,
    (state) => state.error
);