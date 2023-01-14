import IModelBase from "../IModelBase";
import IPhone from "./IPhone";

export default interface ICustomer extends IModelBase {
  name: string,
  documentNumber?: string,
  ordersCountOnMerchant?: number | null,
  phone?: IPhone,
  segmentation?: string
}