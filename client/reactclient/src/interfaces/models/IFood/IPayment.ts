import IMethod from "./IMethod";

export default interface IPayment {
  prepaid: number,
  pending: number,
  methods: Array<IMethod>
}