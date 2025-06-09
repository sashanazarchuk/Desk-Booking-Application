import { createAction, props } from "@ngrx/store";
import { Coworking } from "../../core/models/coworking.model";

//Load All Coworkings
export const loadAllCoworkings = createAction('[Coworking] Load Coworkings');
export const loadAllCoworkingsSuccess = createAction('[Coworking] Load Coworkings Success', props<{ coworkings: Coworking[] }>());
export const loadAllCoworkingsFailure = createAction('[Coworking] Load Coworkings Failure', props<{ error: string }>());