import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { switchMap } from "rxjs/operators";
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

  constructor(
    private activateRoute: ActivatedRoute,
    private candidatesService: CandidatesService
  ) {}

  ngOnInit(): void {
    this.activateRoute.paramMap.pipe(switchMap(p => p.getAll('id'))).subscribe(data=>{
      const id = this.activateRoute.snapshot.params['id'];
      this.loadQuestions(id);
    })
  }

  private loadQuestions(id: string) {
    this.candidatesService
      .getResultsById(id)
      .subscribe((data: CandidateResultResponse) => {
        this.candidateResult = data;
        this.isLoaded = true;
      });
  }
}
