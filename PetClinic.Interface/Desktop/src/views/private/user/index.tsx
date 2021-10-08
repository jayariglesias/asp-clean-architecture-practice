import { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from 'libs/redux';
import { UserRoutes } from 'constants/routes';
import { Switch } from 'react-router';
import { ProtectedRoute } from 'libs/protected-route';
import { getCurrentUser, getUsers } from 'store/actions/userActions';
import { getPets } from 'store/actions/petActions';
import { getVisits } from 'store/actions/visitActions';
import { UserDto } from 'store/models/users';
import { PetDto } from 'store/models/pets';
import { VisitDto } from 'store/models/visits';

let mtUser = false;
let mtVisit = false;

const Index = () => {
	const dispatch = useAppDispatch();
	const Users = useAppSelector<UserDto>((state) => state.user);
	const Visits = useAppSelector<VisitDto>((state) => state.visit);

	useEffect(
		() => {
			if (mtUser) return;
			dispatch(getCurrentUser());
			dispatch(getUsers());
			mtUser = true;
		},
		[ Users.index, dispatch ]
	);

	useEffect(
		() => {
			if (mtVisit) return;
			dispatch(getVisits());
			mtVisit = true;
		},
		[ Visits.index, dispatch ]
	);

	return <Switch>{UserRoutes.map((routeProps, index) => <ProtectedRoute key={index} {...routeProps} />)}</Switch>;
};

export default Index;
