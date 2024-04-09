import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { QuizService } from '../../services/quiz.service';
import { QuizResponse } from '../../contracts/QuizResponse';

export class QuizElement {
  id: string;
  name: string;
  position: number;
}

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
  displayedColumns: string[] = ['position', 'id', 'name'];
  quizes: QuizElement[];

  constructor(private quizService: QuizService) {}
  ngOnInit(): void {
    this.loadQuizes();
  }

  private loadQuizes() {
    this.quizService.getAll().subscribe((data: QuizResponse[]) => {
      this.quizes = data.map<QuizElement>((q, index) => ({
        id: q.id,
        name: q.name,
        position: index + 1,
      }));
      this.isLoaded = true;
    });
  }
}
