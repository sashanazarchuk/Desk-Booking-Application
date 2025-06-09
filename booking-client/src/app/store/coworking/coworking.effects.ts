import { inject, Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { CoworkingService } from "../../core/services/coworking.service";
import * as CoworkingActions from './coworking.actions'
import { catchError, map, mergeMap, of } from "rxjs";

@Injectable()
export class CoworkingEffects {

    private actions$ = inject(Actions);
    private coworkingService = inject(CoworkingService);

    loadAllCoworkings$ = createEffect(() =>
        this.actions$.pipe(
            ofType(CoworkingActions.loadAllCoworkings),
            mergeMap(() =>
                this.coworkingService.getAllCoworkings().pipe(
                    map(coworkings => CoworkingActions.loadAllCoworkingsSuccess({ coworkings })),
                    catchError(error => of(CoworkingActions.loadAllCoworkingsFailure({ error: error.message })))
                )
            )
        )
    );

}