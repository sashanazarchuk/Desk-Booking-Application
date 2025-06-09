import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { coworkingReducer } from './store/coworking/coworking.reducer';
import { CoworkingEffects } from './store/coworking/coworking.effects';
import { workspaceReducer } from './store/workspace/workspace.reducer';
import { WorkspaceEffects } from './store/workspace/workspace.effects';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), provideHttpClient(withFetch()), provideStore({ coworkings: coworkingReducer, workspaces: workspaceReducer }), provideEffects([CoworkingEffects, WorkspaceEffects]), provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() })]
};
