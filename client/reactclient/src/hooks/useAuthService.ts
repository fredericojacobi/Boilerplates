import {Contextualizer} from '../contexts/Contextualizer';
import IAuthService from '../interfaces/services/IAuthService';
import {ProvidedServices} from '../enums/ProvidedServices';

export const useAuthService = () => Contextualizer.use<IAuthService>(ProvidedServices.AuthService);