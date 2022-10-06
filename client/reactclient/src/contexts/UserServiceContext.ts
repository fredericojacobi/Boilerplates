import {Contextualizer} from './Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';

export const UserServiceContext = Contextualizer.createContext(ProvidedServices.UserService);