import {Contextualizer} from './Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';

export const AuthServiceContext = Contextualizer.createContext(ProvidedServices.AuthService);