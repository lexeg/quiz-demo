import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { QuizModel } from '../contracts/QuizModel';
import { QuizDetailedResponse } from '../contracts/QuizDetailedResponse';
import { CreateQuizRequest } from '../contracts/CreateQuizRequest';
import { environment } from '../../environments/environment';

@Injectable()
export class QuizService {
  private url: string;

  constructor(private http: HttpClient) {
    this.url = environment.apiEndPoint;
  }

  getAll(): Observable<QuizModel[]> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<QuizModel[]>(`${this.url}`, {
      headers: myHeaders,
    });
  }

  getById(id: string): Observable<QuizDetailedResponse> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.get<QuizDetailedResponse>(`${this.url}/${id}`, {
      headers: myHeaders,
    });
  }

  create(request: CreateQuizRequest): Observable<any> {
    const myHeaders = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post(`${this.url}`, JSON.stringify(request), {
      headers: myHeaders,
    });
  }
}
