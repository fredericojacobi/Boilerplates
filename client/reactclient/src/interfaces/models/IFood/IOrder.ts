import { OrderTiming, OrderType } from '../../../enums/IFood/Order';
import { SalesChannel } from '../../../enums/IFood/SalesChannel';
import IModelBase from '../IModelBase';
import IAdditionalFee from './IAdditionalFee';
import IBenefits from './IBenefits';
import ICustomer from './ICustomer';
import IDelivery from './IDelivery';
import IItem from './IItem';
import IMerchant from './IMerchant';
import IPayment from './IPayment';
import IPicking from './IPicking';
import IScheduled from './IScheduled';
import ITakeout from './ITakeout';
import ITotal from './ITotal';

export default interface IOrder extends IModelBase {
  orderType: OrderType,
  orderTiming: OrderTiming,
  salesChannel: SalesChannel,
  delivery: IDelivery,
  schedule?: IScheduled,
  takeout?: ITakeout,
  preparationStartDateTime: Date,
  isTest: boolean,
  extraInfo: string,
  merchant: IMerchant,
  customer: ICustomer,
  items: Array<IItem>,
  benefits: Array<IBenefits>,
  additionalFees: Array<IAdditionalFee>,
  total: ITotal,
  payments: IPayment,
  picking: IPicking,
  test: boolean,
  additionalInfo: Object
}