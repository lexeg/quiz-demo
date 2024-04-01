import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CandidateResultResponse } from '../models/CandidateResultResponse';
import { CreateCandidateResultRequest } from '../models/CreateCandidateResultRequest';
import { environment } from '../../environments/environment';

@Injectable()
export class CandidatesService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiEndPoint;
  }

  getResults(): Observable<CandidateResultResponse[]> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<CandidateResultResponse[]>(`${this.url}`, {
      headers: myHeaders,
    });
  }

  getResultsById(id: string): Observable<CandidateResultResponse> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<CandidateResultResponse>(`${this.url}/${id}`, {
      headers: myHeaders,
    });
  }

  saveCandidateResult(request: CreateCandidateResultRequest): Observable<any> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post(`${this.url}`, JSON.stringify(request), {
      headers: myHeaders,
    });
  }
}
