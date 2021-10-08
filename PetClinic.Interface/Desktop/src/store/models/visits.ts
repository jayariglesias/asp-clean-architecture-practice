import moment from 'moment';
import { PetModel } from 'store/models/pets';

export type VisitModel = {
	visitId: number | null;
	petId: number | null;
	visitType: number | null;
	visitDate: any;
	notes: string;
	pet: PetModel[] | undefined;
};

export type VisitDto = {
	isLoading: boolean;
	current: VisitModel | null;
	index: VisitModel[] | null;
};

export const VisitFormState: VisitModel = {
	visitId: null,
	petId: null,
	visitType: null,
	visitDate: moment().format('YYYY-MM-DD'),
	notes: '',
	pet: undefined
};
