import {Contextualizer} from '../contexts/Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';
import IUserService from '../interfaces/services/IUserService';

export const useUserService = () => Contextualizer.use<IUserService>(ProvidedServices.UserService);