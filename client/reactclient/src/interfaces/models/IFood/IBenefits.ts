import { Target } from "../../../enums/IFood/Target";
import ISponsorship from "./ISponsorship";

export default interface IBenefits {
  value: number,
  target: Target,
  targetId: string,
  sponsorshipValues: Array<ISponsorship>
}