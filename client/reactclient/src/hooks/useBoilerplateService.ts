import {Contextualizer} from '../contexts/Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';
import IBoilerplateService from '../interfaces/services/IBoilerplateService';

export const useBoilerplateService = () => Contextualizer.use<IBoilerplateService>(ProvidedServices.BoilerplateService);