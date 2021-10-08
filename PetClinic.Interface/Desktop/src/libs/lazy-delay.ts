import { lazy } from 'react';

export const AddCustomLazyDelay = (path: any, delay: number) => {
	return lazy(async () => {
		const [ moduleExports ] = await Promise.all([
			path,
			new Promise((resolve) => setTimeout(resolve, delay || 300))
		]);
		return moduleExports;
	});
};
