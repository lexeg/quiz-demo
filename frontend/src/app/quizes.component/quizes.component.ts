import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { QuizService } from '../services/quiz.service';
import { QuizResponse } from '../contracts/QuizResponse';

@Component({
  selector: 'quizes-component',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    MatProgressSpinnerModule,
    NgIf,
  ],
  templateUrl: './quizes.component.html',
  styleUrl: './quizes.component.css',
  providers: [QuizService],
})
export class QuizesComponent implements OnInit {
  isLoaded: boolean;
  displayedColumns: string[] = ['id', 'name'];
  quizes: QuizResponse[];

  constructor(private quizService: QuizService) {}
  ngOnInit(): void {
    this.loadQuizes();
  }

  private loadQuizes() {
    this.quizService.getAll().subscribe((data: QuizResponse[]) => {
      this.quizes = data;
      this.isLoaded = true;
    });
  }
}
