import { Route, RouteComponentProps, useHistory } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "libs/redux";
import { useEffect } from "react";
import { authHandler } from "store/actions/authActions";
import NotFound from "components/NotFound";

export const ProtectedRoute = ({
  component: Component,
  path,
  exact = false,
  role
}: {
  component: React.ElementType;
  path?: string;
  exact?: boolean;
  role?: any;
}) => {
  const history = useHistory();
  const dispatch = useAppDispatch();
  const { isLoggedIn, isLoading, currentUser, token } = useAppSelector((state) => state.auth);

  useEffect(() => {
    if (token) return;
    const GetAsyncedData = async () => {
      const { payload } = await dispatch(authHandler());
      return !payload && history.push("/login");
    };
    GetAsyncedData();
  }, [isLoggedIn, token, history, dispatch]);

  return (
    <>
      {isLoggedIn && (
        <Route
          exact={exact}
          path={path}
          render={(routeProps: RouteComponentProps) => {
            if (isLoading) return <div>Loading...</div>;
            if (currentUser?.userType != role) return <NotFound />;
            return <Component {...routeProps} />;
          }}
        />
      )}
    </>
  );
};
