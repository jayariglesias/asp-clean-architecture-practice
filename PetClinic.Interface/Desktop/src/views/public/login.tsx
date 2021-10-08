import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Snackbar from "@mui/material/Snackbar";
import { useAppDispatch, useAppHistory } from "libs/redux";
import { Validate } from "libs/validate";
import { Alert } from "libs/alert";
import { LoginModel } from "store/models/auth";
import { loginHandler } from "store/actions/authActions";
import { SnackModel, SnackInitialState } from "store/models/global";
import { Container, Main, Section, FormBox } from "views/public/loginStyle";
import VetGIF from "assets/vet.gif";

const { REACT_APP_ROLE_ADMIN } = process.env;

const LoginInitialState: LoginModel = {
  username: "",
  password: "",
};

const Login = () => {
  const dispatch = useAppDispatch();
  const history = useAppHistory();

  const [data, setData] = useState<LoginModel>(LoginInitialState);
  const [snack, setSnack] = useState<SnackModel>(SnackInitialState);

  const handleInputChange =
    (prop: keyof LoginModel) =>
    (event: React.ChangeEvent<HTMLInputElement>) => {
      setData({ ...data, [prop]: event.target.value });
    };

  const submit = (event: React.FormEvent) => {
    if (!Validate.string(data.username) || !Validate.string(data.password)) return;
    event.preventDefault();

    dispatch(loginHandler(data))
      .unwrap()
      .then((res) => {
        setSnack({
          message: res.message,
          success: res.status,
          open: true,
        });
        if (!res.status) return;
        return res.result.currentUser.userType == REACT_APP_ROLE_ADMIN
          ? history.push("/dashboard")
          : history.push("/user");
      })
      .catch((err) => {
        setSnack({
          message: err.message,
          success: false,
          open: true,
        });
      });
  };

  return (
    <>
      <Snackbar
        anchorOrigin={{ vertical: "top", horizontal: "center" }}
        autoHideDuration={6000}
        open={snack.open}
        onClose={() => setSnack({...snack, open: false})}
        key={"topcenter"}
      >
        <Alert
          onClose={() => setSnack({...snack, open: false})}
          severity={snack.success ? "success" : "error"}
          sx={{ width: "100%" }}
        >
          {snack.message}
        </Alert>
      </Snackbar>
      <Container container>
        <Main elevation={5}>
          <Grid container sx={{ height: "100%", my: 5 }}>
            <Section item xs={12} md={12} lg={6}>
              <img src={VetGIF} alt="Veterinary" height="80%" width="80%" />
            </Section>
            <Section item xs={12} md={12} lg={6}>
              <FormBox autoComplete="off">
                <Typography
                  variant="h4"
                  color="primary"
                  sx={{ alignSelf: "center", mt: -5, mb: 5 }}
                >
                  SIGN IN
                </Typography>
                <TextField
                  id="Username"
                  label="Username"
                  type="search"
                  onChange={handleInputChange("username")}
                  sx={{ pb: 1 }}
                  required
                />
                <TextField
                  id="Password"
                  label="Password"
                  type="password"
                  onChange={handleInputChange("password")}
                  sx={{ pb: 1 }}
                  required
                />
                <Button variant="contained" type="submit" onClick={submit}>
                  Let me in.
                </Button>
              </FormBox>
            </Section>
          </Grid>
        </Main>
      </Container>
    </>
  );
};

export default Login;
