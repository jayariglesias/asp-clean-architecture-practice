import axios from 'axios';
import { store } from 'store';

let API = axios.create({
	baseURL: process.env.REACT_APP_API_URL
});

API.interceptors.request.use(
	(config) => {
		const state = store.getState();
		const token = state.auth.token || null;
		if (token) {
			config.headers.Authorization = `Bearer ${token}`;
		}
		return config;
	},
	(error) => {
		return Promise.reject(error);
	}
);

export default API;
