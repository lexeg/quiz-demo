import { AnswerModel } from './AnswerModel';

export class QuestionDetailedModel {
  id: string;
  testId: string;
  question: string;
  answers: AnswerModel[];
  selectedAnswerId?: number;
}
