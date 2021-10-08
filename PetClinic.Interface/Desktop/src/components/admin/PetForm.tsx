import { useEffect, useState } from "react";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import FormGroup from "@mui/material/FormGroup";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import { PetFormState, PetModel } from "store/models/pets";
import Autocomplete from "@mui/material/Autocomplete";
import { useAppSelector } from "libs/redux";
import { UserDto } from "store/models/users";
import PetTypes from "constants/pet-types.json";
import moment from "moment";

const { REACT_APP_ROLE_ADMIN } = process.env;
let mounted = false;
export default function AddForm(props: any) {
  const Users = useAppSelector<UserDto>((state) => state.user);
  const Auth = useAppSelector((state) => state.auth);

  const UserIndex = Users.index || [];

  const [values, setValues] = useState<PetModel>(props.update || PetFormState);

  useEffect(() => {
    if (mounted) return;
    setValues({ ...values, userId: Auth.currentUser?.userId! });
    mounted = true;
  }, [values, Auth.currentUser?.userId]);

  const handleInputChange =
    (prop: keyof PetModel) => (event: React.ChangeEvent<HTMLInputElement>) => {
      setValues({ ...values, [prop]: event.target.value });
    };

  const handleComboBoxChange =
    (prop: keyof PetModel) =>
    (event: React.SyntheticEvent<Element, Event>, value: any) => {
      let id: number = value.userId || value.petType;
      setValues({ ...values, [prop]: id });
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
        {props.update ? "Update" : "Add"} Pet
      </Typography>
      <FormGroup>
        {Auth.currentUser?.userType == REACT_APP_ROLE_ADMIN && (
          <Autocomplete
            value={
              props.update &&
              UserIndex[
                UserIndex.findIndex(
                  (item) => item.userId == props.update.userId
                )
              ]
            }
            options={UserIndex}
            getOptionLabel={(option) =>
              `${option.firstName} ${option.lastName}`
            }
            style={{ width: 300 }}
            renderInput={(params) => (
              <TextField
                {...params}
                label="Owner"
                variant="outlined"
                fullWidth
                required
              />
            )}
            onChange={handleComboBoxChange("userId")}
          />
        )}
        <TextField
          id="PetName"
          label="PetName"
          type="search"
          value={values.petName}
          onChange={handleInputChange("petName")}
          required
        />
        <TextField
          id="Breed"
          label="Breed"
          type="search"
          value={values.breed}
          onChange={handleInputChange("breed")}
        />
        <TextField
          id="Birthdate"
          label="Birthdate"
          type="date"
          value={moment(values.birthdate).format("YYYY-MM-DD")}
          onChange={handleInputChange("birthdate")}
          required
        />
        <Autocomplete
          value={
            props.update &&
            PetTypes[
              PetTypes.findIndex((item) => item.petType == props.update.petType)
            ]
          }
          options={PetTypes}
          getOptionLabel={(option) => option.petTypeAlias}
          style={{ width: 300 }}
          renderInput={(params) => (
            <TextField
              {...params}
              label="Pet Type"
              variant="outlined"
              fullWidth
              required
            />
          )}
          onChange={handleComboBoxChange("petType")}
        />
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
}
