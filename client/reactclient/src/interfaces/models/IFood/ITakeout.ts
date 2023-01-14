import { TakeoutMode } from "../../../enums/IFood/TakeoutMode";

export default interface ITakeout {
  mode: TakeoutMode,
  takeoutDateTime: Date,
  observations: string
}