import ILiabilitie from "./ILiabilitie";

export default interface IAdditionalFee {
  type: string,
  description: string,
  fullDescription: string,
  value: number,
  liabilities: Array<ILiabilitie>
}