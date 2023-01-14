import IModelBase from "../IModelBase";

export default interface IItemOption extends IModelBase  {
  index: number,
  name: string,
  externalCode?: string,
  quantity: number,
  unit: string,
  unitPrice: number,
  addition: number,
  price: number
}