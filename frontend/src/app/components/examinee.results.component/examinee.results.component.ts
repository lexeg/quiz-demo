import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { CandidatesService } from '../../services/candidates.service';
import { CandidateResultResponse } from '../../contracts/CandidateResultResponse';

export class CandidateResultElement {
  id: string;
  testId: string;
  testName: string;
  email: string;
  position: number;
}

@Component({
  selector: 'examinee-results-component',
  standalone: true,
  imports: [
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    MatProgressSpinnerModule,
    NgIf,
  ],
  templateUrl: './examinee.results.component.html',
  styleUrl: './examinee.results.component.css',
  providers: [CandidatesService],
})
export class ExamineeResultsComponent implements OnInit {
  isLoaded: boolean;
  displayedColumns: string[] = [
    'position',
    'id',
    'test-id',
    'test-name',
    'email',
  ];
  candidateResults: CandidateResultElement[];

  constructor(private candidatesService: CandidatesService) {}
  ngOnInit(): void {
    this.loadCandidateResults();
  }

  private loadCandidateResults() {
    this.candidatesService
      .getResults()
      .subscribe((data: CandidateResultResponse[]) => {
        this.candidateResults = data.map<CandidateResultElement>(
          (r, index) => ({
            id: r.id,
            testId: r.testId,
            testName: r.testName,
            email: r.email,
            position: index + 1,
          })
        );
        this.isLoaded = true;
      });
  }
}
