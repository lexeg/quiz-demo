import { provideRouter, Routes } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { ApplicationConfig } from '@angular/core';

import { ExamineeResultsComponent } from './components/examinee.results.component/examinee.results.component';
import { QuizesComponent } from './components/quizes.component/quizes.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

const appRoutes: Routes = [
  { path: 'examinee-results', component: ExamineeResultsComponent },
  { path: 'quizes', component: QuizesComponent },
  { path: '**', component: NotFoundComponent },
];

export const appConfig: ApplicationConfig = {
  providers: [provideAnimations(), provideRouter(appRoutes)],
};
