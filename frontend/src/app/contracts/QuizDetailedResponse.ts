import { QuestionDetailedModel } from './QuestionDetailedModel';

export class QuizDetailedResponse {
  id: string;
  name: string;
  description: string;
  questions: QuestionDetailedModel[];
}
