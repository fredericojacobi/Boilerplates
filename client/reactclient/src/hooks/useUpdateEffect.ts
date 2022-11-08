import {
	DependencyList,
	EffectCallback,
	useEffect,
	useRef
} from 'react';
import {log} from '../functions/util';

export default function useUpdateEffect(effect: EffectCallback, dependencyArray: DependencyList = []) {
	const isInitialMount = useRef<boolean>(true);

	useEffect(() => {
		if (isInitialMount.current) {
			isInitialMount.current = false;
		} else {
			return effect();
		}
	}, dependencyArray);
}