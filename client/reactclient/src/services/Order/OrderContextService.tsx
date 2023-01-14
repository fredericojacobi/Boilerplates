import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IPagination from '../../interfaces/models/IPagination';
import IOrderService from '../../interfaces/services/IOrderService';
import IOrder from '../../interfaces/models/IFood/IOrder';
import { OrderService } from './OrderService';
import { OrderServiceContext } from '../../contexts/OrderServiceContext';

export default function OrderContextService({ children }: any): JSX.Element {
  const orderService: IOrderService = {
    //region GET
    async getOrder(id: string): Promise<IResponseMessage<IOrder>> {
      return await OrderService.getOrder(id);
    },
    async getOrders(page?: number, limit?: number): Promise<IResponseMessage<IPagination<IOrder>>> {
      return await OrderService.getOrders(page, limit);
    },
    //endregion

    //region POST

    //endregion

    //region PUT

    //endregion

    //region DELETE
    async deleteOrder(id?: string): Promise<IResponseMessage<boolean>> {
      return await OrderService.deleteOrder(id);
    }

    //endregion
  };
  return (
    <OrderServiceContext.Provider value={orderService}>
      {children}
    </OrderServiceContext.Provider>
  );
}