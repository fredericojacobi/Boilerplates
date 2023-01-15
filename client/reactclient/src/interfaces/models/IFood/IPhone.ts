import IModelBase from "../IModelBase";

export default interface IPhone extends IModelBase {
  number: string,
  localizer: string,
  expiration: Date
}