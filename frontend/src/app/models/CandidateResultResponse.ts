import { QuestionResultModel } from './QuestionResultModel';

export interface CandidateResultResponse {
  id: string;
  testId: string;
  testName: string;
  email: string;
  questions: QuestionResultModel[];
}
