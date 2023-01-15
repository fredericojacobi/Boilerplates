import {Contextualizer} from '../contexts/Contextualizer';
import {ProvidedServices} from '../enums/ProvidedServices';
import IOrderService from '../interfaces/services/IOrderService';

export const useOrderService = () => Contextualizer.use<IOrderService>(ProvidedServices.OrderService);