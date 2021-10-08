/* eslint-disable */
export const Validate = {
	string: (x: string | null) => {
		return !(x == undefined || x == null || x.trim().length == 0) ? x : false;
	},
	number: (x: number | null) => {
		return typeof x == 'number' ? x : false;
	},
	email: (x: string) => {
		return Validate.string(x) && /\S+@\S+\.\S+/.test(x) ? x : false;
	},
	array: (x: any) => {
		return !x.some((e: any | undefined) => {
			if (!e) {
				return true;
			}
		});
	},
	equal: (x: any) => {
		return !x.some((e: any) => {
			if (e != x[0]) {
				return true;
			}
		});
	},
	password: (x: string) => {
		return Validate.string(x) && x.length > 7 && !x.includes(' ') ? x : false;
	}
};
/* eslint-enable */
