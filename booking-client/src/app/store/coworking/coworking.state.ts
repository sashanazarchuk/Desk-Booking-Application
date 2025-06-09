import { Coworking } from "../../core/models/coworking.model";

export interface CoworkingState {
    isLoading: boolean;
    coworkings: Coworking[];
    error: string | null;
}