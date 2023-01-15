import ICoordinate from "./ICoordinate";

export default interface IDeliveryAddress {
  streetName: string,
  streetNumber: string,
  neighborhood: string,
  complement: string,
  reference: string,
  postalCode: string,
  city: string,
  state: string,
  country: string,
  coordinates: ICoordinate
}