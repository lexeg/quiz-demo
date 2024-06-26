import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatDialog } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { switchMap } from 'rxjs/operators';
import { QuizService } from '../../services/quiz.service';
import { QuizResultDialog } from '../quiz-results.component/quiz-results.component';
import { QuizDetailedResponse } from '../../contracts/QuizDetailedResponse';
import { QuestionDetailedModel } from '../../contracts/QuestionDetailedModel';

@Component({
  selector: 'quiz-details-component',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatRadioModule,
    MatProgressSpinnerModule,
    NgIf,
  ],
  templateUrl: './quiz.details.component.html',
  styleUrl: './quiz.details.component.css',
  providers: [QuizService],
})
export class QuizDetailsComponent implements OnInit {
  isLoaded: boolean;
  questions: Array<QuestionDetailedModel>;
  currentQuestionNumber: number;
  currentQuestion: QuestionDetailedModel;
  showSelectedAnswers: string;

  constructor(
    private activateRoute: ActivatedRoute,
    private quizService: QuizService,
    public dialog: MatDialog
  ) {
    this.questions = new Array<QuestionDetailedModel>();
  }

  ngOnInit(): void {
    this.activateRoute.paramMap
      .pipe(switchMap(p => p.getAll('id')))
      .subscribe(data => {
        const id = data;
        this.loadQuestions(id);
      });
  }

  private loadQuestions(id: string) {
    this.quizService.getById(id).subscribe((data: QuizDetailedResponse) => {
      this.questions = data.questions;
      this.isLoaded = true;
      this.currentQuestionNumber = 0;
      this.currentQuestion = this.questions[0];
    });
  }

  previous() {
    if (this.currentQuestionNumber > 0) {
      this.currentQuestionNumber--;
      this.currentQuestion = this.questions[this.currentQuestionNumber];
    }
  }

  next() {
    if (this.currentQuestionNumber < this.questions.length - 1) {
      this.currentQuestionNumber++;
      this.currentQuestion = this.questions[this.currentQuestionNumber];
      return;
    }

    this.openDialog();
  }

  openDialog() {
    this.dialog.open(QuizResultDialog, {
      data: this.questions.map(
        x => `Вопрос ${x.question}, выбранный ответ ${x.selectedAnswerId};`
      ),
    });
  }
}
