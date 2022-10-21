export const getParam = (paramName: Array<string>) => {
	let result = Array<string>();
	paramName.map((param) => {
		result.push(new URL(location.href).searchParams.get(param) ?? '');
	});
	return result;
};