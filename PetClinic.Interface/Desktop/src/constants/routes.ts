import { AddCustomLazyDelay } from 'libs/lazy-delay';

const Dashboard = AddCustomLazyDelay(import('views/private/admin/dashboard'), 1000);
const Users = AddCustomLazyDelay(import('views/private/admin/users'), 1000);
const Pets = AddCustomLazyDelay(import('views/private/admin/pets'), 1000);
const Visits = AddCustomLazyDelay(import('views/private/admin/visits'), 1000);
const UserPets = AddCustomLazyDelay(import('views/private/user/pets'), 1000);
const UserProfile = AddCustomLazyDelay(import('views/private/user/profile'), 1000);
const UserVisits = AddCustomLazyDelay(import('views/private/user/visits'), 1000);

const { REACT_APP_ROLE_ADMIN, REACT_APP_ROLE_USER } = process.env;

export const AdminRoutes = [
	{
		exact: true,
		path: '/dashboard',
		component: Dashboard,
		role: REACT_APP_ROLE_ADMIN
	},
	{
		exact: true,
		path: '/dashboard/users',
		component: Users,
		role: REACT_APP_ROLE_ADMIN
	},
	{
		exact: true,
		path: '/dashboard/pets',
		component: Pets,
		role: REACT_APP_ROLE_ADMIN
	},
	{
		exact: true,
		path: '/dashboard/visits',
		component: Visits,
		role: REACT_APP_ROLE_ADMIN
	}
];

export const UserRoutes = [
	{
		exact: true,
		path: '/user',
		component: UserPets,
		role: REACT_APP_ROLE_USER
	},
	{
		exact: true,
		path: '/user/visits',
		component: UserVisits,
		role: REACT_APP_ROLE_USER
	},
	{
		exact: true,
		path: '/user/profile',
		component: UserProfile,
		role: REACT_APP_ROLE_USER
	}
];
