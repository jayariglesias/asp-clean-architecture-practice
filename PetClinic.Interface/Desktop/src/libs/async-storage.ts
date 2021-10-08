export const asyncStorage = {
	setItem: async (key: string, value: any) => {
		return Promise.resolve().then(function() {
			return localStorage.setItem(key, value);
		});
	},
	getItem: async (key: string) => {
		return Promise.resolve().then(function() {
			let value: any = localStorage.getItem(key);
			return JSON.parse(value);
		});
	},
	removeItem: async (key: string) => {
		return Promise.resolve().then(function() {
			return localStorage.removeItem(key);
		});
	}
};
