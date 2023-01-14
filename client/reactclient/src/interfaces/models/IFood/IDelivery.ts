import { DeliveredBy } from "../../../enums/IFood/DeliveredBy";
import { DeliveryMode } from "../../../enums/IFood/DeliveryMode";
import IDeliveryAddress from "./IDeliveryAddress";

export default interface IDelivery {
  mode: DeliveryMode,
  deliveredBy: DeliveredBy,
  deliveryDateTime: Date,
  observations: string,
  deliveryAddress: IDeliveryAddress
}