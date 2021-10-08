import { useState } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import AddBox from "@mui/icons-material/AddBox";
import Drawer from "@mui/material/Drawer";
import Snackbar from "@mui/material/Snackbar";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import { userCol } from "constants/fields";
import DataGridFilter, { DataGridFilterProps } from "components/datagrid";
import UserForm from "components/admin/UserForm";
import Dashboard from "components/dashboard";
import ClickHandler from "libs/double-click";
import { useAppDispatch, useAppSelector } from "libs/redux";
import { Validate } from "libs/validate";
import { Alert } from "libs/alert";
import { UserDto } from "store/models/users";
import { UserFormDto, UserFormInitialState } from "store/models/users";
import { SnackModel, SnackInitialState } from "store/models/global";
import { createUser, getUsers, updateUser, deleteUser} from "store/actions/userActions";
import { getPets } from "store/actions/petActions";
import { getVisits } from "store/actions/visitActions";

const Users = () => {
  const dispatch = useAppDispatch();
  const Users = useAppSelector<UserDto>((state) => state.user);
  const [snack, setSnack] = useState<SnackModel>(SnackInitialState);
  const [FormData, setFormData] = useState<UserFormDto>(UserFormInitialState);
  const [addModal, setAddModal] = useState(false);
  const [editModal, setEditModal] = useState(false);
  const [dialog, setDialog] = useState(false);

  const onEditUser = (event: any) => {
    setFormData({ ...UserFormInitialState, ...event.data.row });
    setEditModal(true);
  };

  const submitForm = () => {
    setDialog(false);
    const action = addModal ? createUser(FormData) : updateUser(FormData);

    dispatch(action).then((res) => {
      if (!res.payload.status) {
        setSnack({
          message: res.payload.errors[0],
          success: false,
          open: true,
        });
      } else {
        setSnack({
          message: res.payload.message,
          success: true,
          open: true,
        });
        dispatch(getUsers());
        setAddModal(false);
        setEditModal(false);
      }
    });
  };

  const deleteData = (e: React.FormEvent) => {
    dispatch(deleteUser({ userId: FormData.userId }))
      .unwrap()
      .then((res) => {
        setSnack({
          message: res.errors || res.message,
          success: res.status,
          open: true,
        });
        if (!res.status) return;
        setEditModal(false);
        dispatch(getUsers());
        dispatch(getPets());
        dispatch(getVisits());
      })
      .catch((err) => {
        setSnack({
          message: err.message,
          success: false,
          open: true,
        });
      });
  };

  const dataGridProps: DataGridFilterProps = {
    getRowId: (row: any) => row.userId,
    onCellClick: ClickHandler(false, onEditUser),
  };

  const verifyForm = (type: string) => (event: React.FormEvent) => {
    if (
      !Validate.string(FormData.firstName) ||
      !Validate.string(FormData.lastName) ||
      !Validate.string(FormData.email) ||
      !Validate.string(FormData.username) ||
      !Validate.string(FormData.password) ||
      !Validate.string(FormData.verify)
    ) {
      return;
    }
    event.preventDefault();

    if (!Validate.equal([FormData.verify, FormData.password])) {
      setSnack({
        message: "Password not Match!",
        success: false,
        open: true,
      });
      return;
    }

    setDialog(true);
  };

  const handleClose = () => {
    setDialog(false);
  };

  return (
    <>
      <Dashboard title={"Users"}>
        <Grid container spacing={3}>
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
                rows={Users.index}
                columns={userCol}
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
        <UserForm
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
        <UserForm
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

export default Users;
