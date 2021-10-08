import { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import AddBox from "@mui/icons-material/AddBox";
import Drawer from "@mui/material/Drawer";
import Snackbar from "@mui/material/Snackbar";
import ClickHandler from "libs/double-click";
import DataGridFilter, { DataGridFilterProps } from "components/datagrid";
import PetForm from "components/admin/PetForm";
import Dashboard from "components/dashboard";
import { useAppDispatch, useAppSelector } from "libs/redux";
import { Validate } from "libs/validate";
import { Alert } from "libs/alert";
import { PetDto, PetFormState, PetModel } from "store/models/pets";
import { createPet, getPets, updatePet, deletePet} from "store/actions/petActions";
import { petCol } from "constants/fields";
import { SnackInitialState, SnackModel } from "store/models/global";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { UserDto } from "store/models/users";
import { getCurrentUser, getUsers } from "store/actions/userActions";

const Pets = () => {
  const dispatch = useAppDispatch();
  const Users = useAppSelector<UserDto>((state) => state.user);

  const [snack, setSnack] = useState<SnackModel>(SnackInitialState);
  const [FormData, setFormData] = useState<PetModel>(PetFormState);
  const [addModal, setAddModal] = useState(false);
  const [editModal, setEditModal] = useState(false);
  const [dialog, setDialog] = useState(false);

  const onEditPet = (e: any) => {
    setFormData({ ...PetFormState, ...e.data.row });
    setEditModal(true);
  };

  const submitForm = () => {
    setDialog(false);
    setSnack({ ...snack, open: false });

    const action = addModal ? createPet(FormData) : updatePet(FormData);
    dispatch(action).then((res) => {
      if (!res.payload.status) {
        setSnack({
          message: res.payload.errors[0],
          success: false,
          open: true,
        });
      } else {
        setSnack({
          message: res.payload.message || "Success!",
          success: true,
          open: true,
        });
        dispatch(getCurrentUser());
        setAddModal(false);
        setEditModal(false);
      }
    });
  };

  const deleteData = (e: React.FormEvent) => {
    dispatch(deletePet({ petId: FormData.petId }))
      .unwrap()
      .then((res) => {
        setSnack({
          message: res.errors || res.message,
          success: res.status,
          open: true,
        });
        if (!res.status) return;
        dispatch(getCurrentUser());
        setEditModal(false);
      })
      .catch((err) => {
        setSnack({
          message: err.message,
          success: false,
          open: true,
        });
      });
  };

  const verifyForm = (type: string) => (event: React.FormEvent) => {
    if (
      !Validate.number(FormData.userId) ||
      !Validate.string(FormData.petName) ||
      !Validate.string(FormData.birthdate) ||
      !Validate.string(FormData.breed) ||
      !Validate.number(FormData.petType)
    )
      return;
    event.preventDefault();

    setDialog(true);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const dataGridProps: DataGridFilterProps = {
    getRowId: (row: any) => row.petId,
    onCellClick: ClickHandler(false, onEditPet),
  };

  return (
    <>
      <Dashboard title={"Pets"}>
        <Grid container spacing={3}>
          {/* <Grid item xs={12} md={12} lg={12}>
            <Paper sx={{ p: 2 }}>
              <Button
                variant="outlined"
                size="medium"
                startIcon={<AddBox />}
                sx={{ my: 1 }}
                onClick={() => setAddModal(true)}
              >
                Edit Profile
              </Button>
            </Paper>
          </Grid> */}
          <Grid item xs={12} md={12} lg={12}>
            <Paper sx={{ p: 2 }}>
              <Button
                variant="outlined"
                size="medium"
                startIcon={<AddBox />}
                sx={{ my: 1 }}
                onClick={() => setAddModal(true)}
              >
                Create
              </Button>
              <DataGridFilter
                dataGridProps={dataGridProps}
                isLoading={Users.isLoading}
                height={500}
                rows={Users.current?.pets}
                columns={petCol}
              />
            </Paper>
          </Grid>
        </Grid>
      </Dashboard>
      <Drawer
        anchor={"right"}
        open={addModal}
        onClose={() => setAddModal(false)}
        sx={{ zIndex: 1201 }}
      >
        <PetForm
          onClick={verifyForm("create")}
          value={(e: any) => setFormData(e)}
        />
      </Drawer>
      <Drawer
        anchor={"right"}
        open={editModal}
        onClose={() => setEditModal(false)}
        sx={{ zIndex: 1201 }}
      >
        <PetForm
          update={FormData}
          value={(e: any) => setFormData(e)}
          onDelete={deleteData}
          onClick={verifyForm("update")}
        />
      </Drawer>
      <Snackbar
        anchorOrigin={{ vertical: "top", horizontal: "center" }}
        autoHideDuration={6000}
        open={snack.open}
        onClose={() => setSnack(SnackInitialState)}
        key={"topcenter"}
      >
        <Alert
          onClose={() => setSnack(SnackInitialState)}
          severity={snack.success ? "success" : "error"}
          sx={{ width: "100%" }}
        >
          {snack.message}
        </Alert>
      </Snackbar>
      <Dialog
        open={dialog}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{"Please confirm"}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to continue?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Cancel</Button>
          <Button onClick={() => submitForm()} autoFocus>
            Agree
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default Pets;
