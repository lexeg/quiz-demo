import { CandidateAnswerModel } from './CandidateAnswerModel';

export interface CreateCandidateResultRequest {
  testId: string;
  email: string;
  answers: CandidateAnswerModel[];
}
