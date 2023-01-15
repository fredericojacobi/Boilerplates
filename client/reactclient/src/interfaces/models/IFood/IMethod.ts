import { PaymentMethod } from "../../../enums/IFood/PaymentMethod";
import { PaymentMethodType } from "../../../enums/IFood/PaymentMethodType";
import ICard from "./ICard";
import ICash from "./ICash";
import IWallet from "./IWallet";

export default interface IMethod {
  value: number,
  currency: string,
  type: PaymentMethodType,
  method: PaymentMethod,
  card?: ICard,
  wallet?: IWallet,
  cash?: ICash,
}