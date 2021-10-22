import React, { useEffect, useState } from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import FormGroup from "@mui/material/FormGroup";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import Grid from "@mui/material/Grid";
import OutlinedInput from "@mui/material/OutlinedInput";
import InputLabel from "@mui/material/InputLabel";
import InputAdornment from "@mui/material/InputAdornment";
import FormControl from "@mui/material/FormControl";
import Visibility from "@mui/icons-material/Visibility";
import VisibilityOff from "@mui/icons-material/VisibilityOff";
import { UserFormDto, UserFormInitialState } from "store/models/users";
import Divider from "@mui/material/Divider";
import Switch from "@mui/material/Switch";

const AddForm = (props: any) => {
  const [values, setValues] = useState<UserFormDto>(
    props.update || UserFormInitialState
  );

  const handleInputChange =
    (prop: keyof UserFormDto) =>
    (event: React.ChangeEvent<HTMLInputElement>) => {
      setValues({ ...values, [prop]: event.target.value });
    };

  const handleClickShowPassword = (verify?: boolean) => {
    if (verify) {
      setValues({ ...values, showVerify: !values.showVerify });
    } else {
      setValues({ ...values, showPassword: !values.showPassword });
    }
  };

  const handleActiveSwitch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, active: event.target.checked });
  };

  useEffect(() => {
    props.value(values);
  }, [values, props]);

  return (
    <Box
      component="form"
      sx={{
        "& .MuiTextField-root": { mx: 5, my: 1, width: "300px" },
      }}
      autoComplete="off"
    >
      <Typography variant="h5" sx={{ m: 3, fontWeight: "bold" }}>
        {props.update ? "Update" : "Add"} User
      </Typography>
      <FormGroup>
        <TextField
          id="FirstName"
          label="FirstName"
          type="search"
          value={values.firstName}
          onChange={handleInputChange("firstName")}
          required
        />
        <TextField
          id="MiddleName"
          label="MiddleName"
          type="search"
          value={values.middleName}
          onChange={handleInputChange("middleName")}
        />
        <TextField
          id="LastName"
          label="LastName"
          type="search"
          value={values.lastName}
          onChange={handleInputChange("lastName")}
          required
        />
      </FormGroup>
      <Divider sx={{ my: 2 }} />
      <Switch
        sx={{ ml: 4, mb: 2 }}
        checked={values.active}
        inputProps={{ "aria-label": "Switch A" }}
        onChange={handleActiveSwitch}
      />
      Active
      <FormGroup>
        <TextField
        helperText="asddas"
          id="Email"
          label="Email"
          type="Email"
          value={values.email}
          onChange={handleInputChange("email")}
          required
        />
        <TextField
          id="Username"
          label="Username"
          type="search"
          value={values.username}
          onChange={handleInputChange("username")}
          required
        />
        <FormControl sx={{ mx: 5, my: 1 }} variant="outlined">
          <InputLabel htmlFor="outlined-adornment-password">
            Password
          </InputLabel>
          <OutlinedInput
            id="Password"
            type={values.showPassword ? "text" : "password"}
            value={values.password}
            onChange={handleInputChange("password")}
            endAdornment={
              <InputAdornment position="end">
                <IconButton
                  aria-label="toggle password visibility"
                  onClick={() => handleClickShowPassword()}
                  edge="end"
                >
                  {values.showPassword ? <VisibilityOff /> : <Visibility />}
                </IconButton>
              </InputAdornment>
            }
            label="Password"
            required
          />
        </FormControl>
        <FormControl sx={{ mx: 5, my: 1 }} variant="outlined">
          <InputLabel htmlFor="outlined-adornment-password">
            Verify Password
          </InputLabel>
          <OutlinedInput
            id="VerifyPassword"
            type={values.showVerify ? "text" : "password"}
            value={values.verify}
            onChange={handleInputChange("verify")}
            endAdornment={
              <InputAdornment position="end">
                <IconButton
                  aria-label="toggle password visibility"
                  onClick={() => handleClickShowPassword(true)}
                  edge="end"
                >
                  {values.showVerify ? <VisibilityOff /> : <Visibility />}
                </IconButton>
              </InputAdornment>
            }
            label="VerifyPassword"
            required
          />
        </FormControl>
      </FormGroup>
      <Grid sx={{ mx: 5, my: 1, textAlign: "right" }}>
        {props.update && (
          <Button
            variant="contained"
            type="button"
            color="tertiary"
            sx={{ mx: 1 }}
            onClick={props.onDelete}
          >
            Delete
          </Button>
        )}
        <Button variant="contained" type="submit" onClick={props.onClick}>
          {props.update ? "Update" : "Submit"}
        </Button>
      </Grid>
    </Box>
  );
};

export default AddForm;
