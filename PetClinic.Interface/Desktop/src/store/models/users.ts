import { PetModel } from 'store/models/pets';

/**
 * User Model
 */
export type UserModel = {
	userId: number | null;
	userType: number;
	firstName: string;
	middleName: string;
	lastName: string;
	username: string;
	password: string;
	email: string;
	active?: boolean;
	pets?: PetModel[];
};

/**
 * List of all users, current user
 */
export type UserDto = {
	isLoading: boolean;
	current: UserModel | null;
	index: UserModel[] | null;
};

/**
 * For showing password.
 */
export interface UserFormDto extends UserModel {
	verify: string;
	showPassword: boolean;
	showVerify: boolean;
}

/**
 * For initial state of user form.
 */
export const UserFormInitialState: UserFormDto = {
	firstName: '',
	verify: '',
	showPassword: false,
	showVerify: false,
	userId: null,
	userType: 2,
	middleName: '',
	lastName: '',
	username: '',
	password: '',
	email: '',
	active: false
};
