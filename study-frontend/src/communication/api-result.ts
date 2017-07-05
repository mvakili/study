import { ResultStatus } from './';

export interface ApiResult {
    ResultStatus : ResultStatus;
    Messages: string[];
}

export interface GenericApiResult<T> extends ApiResult {
    Data : T;
}