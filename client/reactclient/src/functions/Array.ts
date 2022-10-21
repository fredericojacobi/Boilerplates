export const last = <T>(array: Array<T>): T => array.slice(-1)[0];

export const uniqueAlphaNumericId = (length: number): string => {
	const heyStack: string = '0123456789abcdefghijklmnopqrstuvwxyz';
	const randomInt = (): number => Math.floor(Math.random() * Math.floor(heyStack.length));

	return Array.from({length}, () => heyStack[randomInt()]).join('');
};

export const merge = <T>(array1: Array<T>, array2: Array<T>): Array<T> => array1.concat(array2);

export const distinct = <T>(array: Array<T>): Array<T> => {
	let data = new Array<T>();

	const set = new Set<T>([...array]);
	set.forEach((item: T) => {
		data.push(item);
	});

	return data;
};