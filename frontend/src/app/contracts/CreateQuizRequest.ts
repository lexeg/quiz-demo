import { QuestionModel } from './QuestionModel';

export interface CreateQuizRequest {
  name: string;
  description: string;
  questions: QuestionModel[];
}
