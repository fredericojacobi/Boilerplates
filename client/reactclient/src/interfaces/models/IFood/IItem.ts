import IModelBase from "../IModelBase";
import IItemOption from "./IItemOption";
import IScalePrice from "./IScalePrice";

export default interface IItem extends IModelBase {
  index: number,
  itemId: string,
  imageUrl: string,
  externalCode?: string,
  ean: string,
  quantity: number,
  unit: string,
  unitPrice: number,
  addition: number,
  price: number,
  scalePrices: Array<IScalePrice>,
  optionsPrice: number,
  totalPrice: number,
  observations: string,
  options: Array<IItemOption>
}