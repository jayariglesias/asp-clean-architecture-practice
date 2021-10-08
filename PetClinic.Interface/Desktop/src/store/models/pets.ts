import moment from 'moment';
import { UserModel } from 'store/models/users';

export type PetModel = {
	petId: number | null;
	userId: number | null;
	petType: number | null;
	petName: string;
	breed: string;
	birthdate: any;
	owner: UserModel | undefined;
};

export type PetDto = {
	isLoading: boolean;
	current: PetModel | null;
	index: PetModel[] | null;
};

/**
 * For initial state of user form.
 */

export const PetFormState: PetModel = {
	petId: null,
	userId: null,
	petType: null,
	petName: '',
	breed: '',
	birthdate: moment().format('YYYY-MM-DD'),
	owner: undefined
};
