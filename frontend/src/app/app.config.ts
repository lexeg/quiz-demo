import { provideRouter, Routes } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { ApplicationConfig } from '@angular/core';

import { ExamineeResultsComponent } from './components/examinee.results.component/examinee.results.component';
import { ExamineeDetailsComponent } from './components/examinee.details.component/examinee.details.component';
import { QuizesComponent } from './components/quizes.component/quizes.component';
import { QuizDetailsComponent } from './components/quiz.details.component/quiz.details.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

const appRoutes: Routes = [
  { path: 'examinee-results', component: ExamineeResultsComponent },
  { path: 'examinee-details/:id', component: ExamineeDetailsComponent },
  { path: 'quizes', component: QuizesComponent },
  { path: 'quiz-details/:id', component: QuizDetailsComponent },
  { path: '**', component: NotFoundComponent },
];

export const appConfig: ApplicationConfig = {
  providers: [provideAnimations(), provideRouter(appRoutes)],
};
