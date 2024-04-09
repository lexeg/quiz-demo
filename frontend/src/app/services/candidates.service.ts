import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CandidateResultResponse } from '../contracts/CandidateResultResponse';
import { CreateCandidateResultRequest } from '../contracts/CreateCandidateResultRequest';
import { environment } from '../../environments/environment';

@Injectable()
export class CandidatesService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiEndPoint;
  }

  getResults(): Observable<CandidateResultResponse[]> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<CandidateResultResponse[]>(`${this.url}/Candidates`, {
      headers: myHeaders,
    });
  }

  getResultsById(id: string): Observable<CandidateResultResponse> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<CandidateResultResponse>(
      `${this.url}/Candidates/${id}`,
      {
        headers: myHeaders,
      }
    );
  }

  saveCandidateResult(request: CreateCandidateResultRequest): Observable<any> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post(`${this.url}/Candidates`, JSON.stringify(request), {
      headers: myHeaders,
    });
  }
}
