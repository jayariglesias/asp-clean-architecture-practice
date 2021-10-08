import { lazy, Suspense } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import { ProtectedRoute } from 'libs/protected-route';
import NotFound from 'components/NotFound';
import Login from 'views/public/login';
import LazyLoad from 'components/animation/lazyLoad';

const Admin = lazy(() => import('views/private/admin'));
const User = lazy(() => import('views/private/user'));

const { REACT_APP_ROLE_ADMIN, REACT_APP_ROLE_USER } = process.env;

function App() {
	return (
		<Suspense fallback={<LazyLoad />}>
			<Router>
				<Switch>
					<Route exact path="/(|login)" component={Login} />
					<ProtectedRoute path={'/dashboard'} component={Admin} role={REACT_APP_ROLE_ADMIN} />
					<ProtectedRoute path={'/user'} component={User} role={REACT_APP_ROLE_USER} />
					<Route component={NotFound} />
				</Switch>
			</Router>
		</Suspense>
	);
}

export default App;
