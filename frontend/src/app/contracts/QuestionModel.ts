import { AnswerModel } from './AnswerModel';

export interface QuestionModel {
  testId: string;
  question: string;
  answers: AnswerModel[];
  answerId: number;
}
