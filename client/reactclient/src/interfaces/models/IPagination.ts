export default interface IPagination<T> {
	records: Array<T>,
	pageSize: number,
	currentPage: number,
	nextPage: number,
	previousPage: number,
	lastPage: number,
	totalRecords: number,
	totalPages: number,
	hasNextPage: boolean,
	hasPreviousPage: boolean,
}