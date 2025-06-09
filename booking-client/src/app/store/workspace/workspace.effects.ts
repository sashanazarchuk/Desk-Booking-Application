import { inject, Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import * as WorkspaceActions from './workspace.actions'
import { catchError, map, mergeMap, of } from "rxjs";
import { CoworkingService } from "../../core/services/coworking.service";
import { Workspace } from "../../core/models/workspace.model";


@Injectable()
export class WorkspaceEffects {

    private actions$ = inject(Actions);
    private coworkingService = inject(CoworkingService);

    loadWorkspaceByCoworkingId$ = createEffect(() =>
        this.actions$.pipe(
            ofType(WorkspaceActions.loadWorkspaceByCoworkingId),
            mergeMap(({ workspaceId }) =>
                this.coworkingService.getWorkspaceByCoworkingId(workspaceId).pipe(
                    map((workspaces: Workspace[]) => WorkspaceActions.loadWorkspaceByCoworkingIdSuccess({ workspaces })),
                    catchError((error) => of(WorkspaceActions.loadWorkspaceByCoworkingIdFailure({ error: error.message })))
                )
            )
        )
    );
}