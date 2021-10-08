import * as React from "react";
import Typography from "@mui/material/Typography";
import moment from "moment";
import Title from "./title";
import { Link } from "react-router-dom";
import { useAppSelector } from "libs/redux";
import { UserDto } from "store/models/users";

export default function Deposits() {
  const Users = useAppSelector<UserDto>((state) => state.user);

  return (
    <React.Fragment>
      <Title>Total Users</Title>
      <Typography component="p" variant="h4">
        {Users.index?.length || 0}
      </Typography>
      <Typography color="text.secondary" sx={{ flex: 1 }}>
        as of <br /> {moment(new Date()).format("LL")}
      </Typography>
      <div>
        <Link color="primary" to="/dashboard/users">
          View Users
        </Link>
      </div>
    </React.Fragment>
  );
}
