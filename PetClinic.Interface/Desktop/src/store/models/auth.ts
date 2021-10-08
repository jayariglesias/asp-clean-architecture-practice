import { UserModel } from 'store/models/users';

export type LoginModel = {
	username: string;
	password: string;
};

export type AuthModel = {
	isLoggedIn?: boolean;
	isLoading?: boolean;
	token?: string | null;
	currentUser: UserModel | null;
};
