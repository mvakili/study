import { ResultStatus } from './';

export interface ApiResult {
    ResultStatus : ResultStatus;
    Errors: string[];
}

export interface GenericApiResult<T> extends ApiResult {
    Data : T;
}