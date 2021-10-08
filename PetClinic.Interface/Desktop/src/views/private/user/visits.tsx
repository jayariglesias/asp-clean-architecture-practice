import { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import AddBox from "@mui/icons-material/AddBox";
import Drawer from "@mui/material/Drawer";
import Snackbar from "@mui/material/Snackbar";
import ClickHandler from "libs/double-click";
import DataGridFilter, { DataGridFilterProps } from "components/datagrid";
import VisitForm from "components/admin/VisitForm";
import Dashboard from "components/dashboard";
import { useAppDispatch, useAppSelector } from "libs/redux";
import { Validate } from "libs/validate";
import { Alert } from "libs/alert";
import { VisitDto, VisitFormState, VisitModel } from "store/models/visits";
import { createVisit, deleteVisit, getVisits, updateVisit } from "store/actions/visitActions";
import { visitCol } from "constants/fields";
import { SnackInitialState, SnackModel } from "store/models/global";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";

let mount = false;
const Visits = () => {
  const dispatch = useAppDispatch();
  const Visits = useAppSelector<VisitDto>((state) => state.visit);
  const Auth = useAppSelector((state) => state.auth);
  const [snack, setSnack] = useState<SnackModel>(SnackInitialState);
  const [FormData, setFormData] = useState<VisitModel>(VisitFormState);
  const [addModal, setAddModal] = useState(false);
  const [editModal, setEditModal] = useState(false);
  const [dialog, setDialog] = useState(false);

  const onEditVisit = (e: any) => {
    setFormData({ ...VisitFormState, ...e.data.row });
    setEditModal(true);
  };

  const submitForm = () => {
    setDialog(false);
    setSnack(SnackInitialState);

    const action = addModal ? createVisit(FormData) : updateVisit(FormData);
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
        dispatch(getVisits());
        setAddModal(false);
        setEditModal(false);
      }
    });
  };

  const deleteData = (e: React.FormEvent) => {
    dispatch(deleteVisit({ visitId: FormData.visitId }))
      .unwrap()
      .then((res) => {
        setSnack({
          message: res.errors || res.message,
          success: res.status,
          open: true,
        });
        if (!res.status) return;
        setEditModal(false);
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

  const verifyForm = (type: string) => (event: React.FormEvent) => {
    if (
      !Validate.number(FormData.petId) ||
      !Validate.string(FormData.notes) ||
      !Validate.string(FormData.visitDate) ||
      !Validate.number(FormData.visitType)
    ) {
      return;
    }
    event.preventDefault();
    setDialog(true);
  };

  const handleClose = () => {
    setDialog(false);
  };

  const dataGridProps: DataGridFilterProps = {
    getRowId: (row: any) => row.visitId,
  };

  return (
    <>
      <Dashboard title={"Visits"}>
        <Grid container spacing={3}>
          <Grid item xs={12} md={12} lg={12}>
            <Paper sx={{ p: 2 }}>
              {/* <Button
                variant="outlined"
                size="medium"
                startIcon={<AddBox />}
                sx={{ my: 1 }}
                onClick={() => setAddModal(true)}
              >
                Create
              </Button> */}
              <DataGridFilter
                dataGridProps={dataGridProps}
                isLoading={Visits.isLoading}
                height={500}
                rows={Visits.index}
                columns={visitCol}
                dateRange={true}
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
        <VisitForm
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
        <VisitForm
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

export default Visits;
