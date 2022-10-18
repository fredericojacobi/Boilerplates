import Axios, {AxiosInstance, AxiosResponse} from 'axios';
import IResponseMessage from '../interfaces/models/IResponseMessage';

const api: AxiosInstance = Axios.create({
	baseURL: 'https://localhost:7048/api/',
	headers: {
		'Content-Type': 'application/json',
		// 'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImNkZGE3NjVlLTU4NDEtNDI3ZC1mZTQxLTA4ZGE4YThmNTBkZiIsIm5iZiI6MTY2NTA4MzAwMSwiZXhwIjoxNjY1MTY5NDAxLCJpYXQiOjE2NjUwODMwMDF9.luYo0qy1dCcX-o-Qk3DP7_PxpaTKu0ipOpYnZIyeTaw',
	},
});

function Get<T>(url: string): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.get(url);
}

function Post<T>(url: string, data: T): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.post(url, data);
}

function Put<T>(url: string, data: T): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.put(url, data);
}

function Delete<T>(url: string): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.delete(url);
}

export default {
	Get,
	Post,
	Put,
	Delete,
};