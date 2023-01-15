import IResponseMessage from '../models/IResponseMessage';
import IPagination from '../models/IPagination';
import IOrder from '../models/IFood/IOrder';

export default interface IOrderService {
	getOrders(page?: number, limit?: number): Promise<IResponseMessage<IPagination<IOrder>>>,
	getOrder(id: string): Promise<IResponseMessage<IOrder>>,
	deleteOrder(id?: string): Promise<IResponseMessage<boolean>>
}