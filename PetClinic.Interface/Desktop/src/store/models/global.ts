export type SnackModel = {
	message: string;
	success: boolean;
	open: boolean;
};

export const SnackInitialState: SnackModel = {
	message: '',
	success: false,
	open: false
};
