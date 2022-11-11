import IResponseMessage from '../interfaces/models/IResponseMessage';

export const parseResponseMessage = <T>(response: string): IResponseMessage<T> => JSON.parse(response);