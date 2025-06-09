import { createReducer, on } from "@ngrx/store";
import { CoworkingState } from "./coworking.state";
import * as CoworkingActions from './coworking.actions'

export const initialState: CoworkingState = {
    isLoading: false,
    coworkings: [],
    error: null
}


export const coworkingReducer = createReducer(
    initialState,

    on(CoworkingActions.loadAllCoworkings, (state) => ({
        ...state,
        isLoading: true,
        error: null
    })),

    on(CoworkingActions.loadAllCoworkingsSuccess, (state, action) => ({
        ...state,
        isLoading: false,
        coworkings: action.coworkings
    })),
    on(CoworkingActions.loadAllCoworkingsFailure, (state, action) => ({
        ...state,
        isLoading: false,
        error: action.error
    }))
);