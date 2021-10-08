import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import ListSubheader from '@mui/material/ListSubheader';
import PetIcon from '@mui/icons-material/Pets';
import PeopleIcon from '@mui/icons-material/People';
import VisitIcon from '@mui/icons-material/LibraryBooks';
import DashboardIcon from '@mui/icons-material/Dashboard';
import LogoutIcon from '@mui/icons-material/Logout';
import { Link } from 'react-router-dom';
import { useAppDispatch } from 'libs/redux';
import { authActions } from 'store/reducers/authSlice';

export const AdminMenu = (
	<div style={{ maxHeight: 600 }}>
		<ListSubheader>Menu</ListSubheader>
		<ListItem button component={Link} to="/dashboard">
			<ListItemIcon>
				<DashboardIcon />
			</ListItemIcon>
			<ListItemText primary="Dashboard" />
		</ListItem>

		<ListItem button component={Link} to="/dashboard/users">
			<ListItemIcon>
				<PeopleIcon />
			</ListItemIcon>
			<ListItemText primary="Users" />
		</ListItem>

		<ListItem button component={Link} to="/dashboard/pets">
			<ListItemIcon>
				<PetIcon />
			</ListItemIcon>
			<ListItemText primary="Pets" />
		</ListItem>

		<ListItem button component={Link} to="/dashboard/visits">
			<ListItemIcon>
				<VisitIcon />
			</ListItemIcon>
			<ListItemText primary="Visits" />
		</ListItem>
	</div>
);

export const UserMenu = (
	<div style={{ maxHeight: 600 }}>
		<ListSubheader>Menu</ListSubheader>
		<ListItem button component={Link} to="/user">
			<ListItemIcon>
				<DashboardIcon />
			</ListItemIcon>
			<ListItemText primary="Pets" />
		</ListItem>

		<ListItem button component={Link} to="/user/visits">
			<ListItemIcon>
				<PeopleIcon />
			</ListItemIcon>
			<ListItemText primary="Visits" />
		</ListItem>
	</div>
);
