import { useEffect } from 'react';
import { Switch } from 'react-router';
import { AdminRoutes } from 'constants/routes';
import { useAppDispatch, useAppSelector } from 'libs/redux';
import { ProtectedRoute } from 'libs/protected-route';
import { getUsers } from 'store/actions/userActions';
import { getPets } from 'store/actions/petActions';
import { getVisits } from 'store/actions/visitActions';
import { UserDto } from 'store/models/users';
import { PetDto } from 'store/models/pets';
import { VisitDto } from 'store/models/visits';

let mtUser = false;
let mtPet = false;
let mtVisit = false;

const Index = () => {
	const dispatch = useAppDispatch();
	const Users = useAppSelector<UserDto>((state) => state.user);
	const Pets = useAppSelector<PetDto>((state) => state.pet);
	const Visits = useAppSelector<VisitDto>((state) => state.visit);

	useEffect(
		() => {
			if (mtUser) return;
			dispatch(getUsers());
			mtUser = true;
		},
		[ Users.index, dispatch ]
	);

	useEffect(
		() => {
			if (mtPet) return;
			dispatch(getPets());
			mtPet = true;
		},
		[ Pets.index, dispatch ]
	);

	useEffect(
		() => {
			if (mtVisit) return;
			dispatch(getVisits());
			mtVisit = true;
		},
		[ Visits.index, dispatch ]
	);

	return <Switch>{AdminRoutes.map((routeProps, index) => <ProtectedRoute key={index} {...routeProps} />)}</Switch>;
};

export default Index;
