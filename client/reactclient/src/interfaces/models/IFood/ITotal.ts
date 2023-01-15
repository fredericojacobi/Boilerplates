import ICampaign from "./ICampaign";

export default interface ITotal {
  subTotal: number,
  deliveryFee: number,
  benefits: number,
  additionalFees: number,
  orderAmount: number,
  campaign: ICampaign,
}