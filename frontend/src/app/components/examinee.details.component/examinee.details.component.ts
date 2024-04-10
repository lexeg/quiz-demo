import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CandidatesService } from '../../services/candidates.service';
import { CandidateResultResponse } from '../../contracts/CandidateResultResponse';

@Component({
  selector: 'examinee-details-component',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    MatProgressSpinnerModule,
    NgIf,
  ],
  templateUrl: './examinee.details.component.html',
  styleUrl: './examinee.details.component.css',
  providers: [CandidatesService],
})
export class ExamineeDetailsComponent implements OnInit {
  isLoaded: boolean;
  displayedColumns: string[] = [
    'position',
    'question',
    'candidate-answer',
    'answer',
  ];
  candidateResult: CandidateResultResponse;

  constructor(private candidatesService: CandidatesService) {}

  ngOnInit(): void {
    this.loadQuestions();
  }

  private loadQuestions() {
    this.candidatesService
      .getResultsById('<fake-id>')
      .subscribe((data: CandidateResultResponse) => {
        this.candidateResult = data;
        this.isLoaded = true;
      });
  }
}
