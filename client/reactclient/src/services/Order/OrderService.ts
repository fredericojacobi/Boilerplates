import api from '../../config/Api';
import { AxiosResponse } from 'axios';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import {
  setErrorResponseObject,
  setErrorResponsePaginationObject
} from '../../functions/Request';
import IPagination from '../../interfaces/models/IPagination';
import { log } from '../../functions/util';
import IOrderService from '../../interfaces/services/IOrderService';
import IOrder from '../../interfaces/models/IFood/IOrder';

export const OrderService: IOrderService = {

  //region GET
  getOrders: async (page?: number, limit?: number): Promise<IResponseMessage<IPagination<IOrder>>> => {
    return await api.Get<IPagination<IOrder>>(`order?page=${page ?? 1}&limit=${limit ?? 10}`)
      .then((response: AxiosResponse<IResponseMessage<IPagination<IOrder>>>) => {
        return response.data;
      })
      .catch((err: IResponseMessage<IPagination<IOrder>>) => {
        return setErrorResponsePaginationObject<IOrder>(err);
      });
  },
  getOrder: async (id: string): Promise<IResponseMessage<IOrder>> => {
    return await api.Get<IOrder>(`order/${id}`)
      .then((response: AxiosResponse<IResponseMessage<IOrder>>) => {
        return response.data;
      })
      .catch((err: IResponseMessage<IOrder>) => {
        return setErrorResponseObject<IOrder>(err);
      });
  },
  //endregion

  //region DELETE
  deleteOrder: async (id?: string): Promise<IResponseMessage<boolean>> => {
    return await api.Delete<boolean>(`order/${id}`)
      .then((response: AxiosResponse<IResponseMessage<boolean>>) => {
        return response.data;
      })
      .catch((err: IResponseMessage<boolean>) => {
        return err;
      });
  }
  //endregion
};