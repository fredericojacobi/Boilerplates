export default interface IResponseMessage<T> {
	error: boolean,
	message: string,
	records: T[],
	count: number,
	status: number
}