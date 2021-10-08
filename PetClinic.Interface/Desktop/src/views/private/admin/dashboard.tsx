import { useEffect } from "react";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Dashboard from "components/dashboard";
import Chart from "components/dashboard/chart";
import TotalUsers from "components/dashboard/usersData";
import Visits from "components/dashboard/visitsData";
import { useAppDispatch, useAppSelector } from "libs/redux";
import { getUsers } from "store/actions/userActions";
import { UserDto } from "store/models/users";

let mounted = false;
const Index = () => {
  const Users = useAppSelector<UserDto>((state) => state.user);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (mounted) return;
    dispatch(getUsers());

    mounted = true;
  }, [Users.index, dispatch]);

  return (
    <>
      <Dashboard>
        <Grid container spacing={3}>
          <Grid item xs={12} md={8} lg={9}>
            <Paper
              sx={{
                p: 2,
                display: "flex",
                flexDirection: "column",
                height: 240,
              }}
            >
              <Chart />
            </Paper>
          </Grid>

          <Grid item xs={12} md={4} lg={3}>
            <Paper
              sx={{
                p: 2,
                display: "flex",
                flexDirection: "column",
                height: 240,
              }}
            >
              <TotalUsers />
            </Paper>
          </Grid>

          <Grid item xs={12}>
            <Paper sx={{ p: 2, display: "flex", flexDirection: "column" }}>
              <Visits />
            </Paper>
          </Grid>
        </Grid>
      </Dashboard>
    </>
  );
};

export default Index;
