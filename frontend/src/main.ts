import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { QuizesComponent } from './app/components/quizes.component/quizes.component';

bootstrapApplication(QuizesComponent, {
  providers: [provideAnimations()],
}).catch(err => console.error(err));
