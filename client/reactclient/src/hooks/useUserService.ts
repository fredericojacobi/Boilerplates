import {Contextualizer} from '../contexts/Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';
import IUserContextService from '../interfaces/services/IUserContextService';

export const useUserService = () => Contextualizer.use<IUserContextService>(ProvidedServices.UserService);