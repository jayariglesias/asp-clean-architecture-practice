import { Tooltip } from "@mui/material";
import { GridColDef } from "@mui/x-data-grid";
import PetTypes from "./pet-types.json";
import VisitTypes from "./visit-types.json";
import moment from "moment";
import { store } from "store";

const state = store.getState();
const { REACT_APP_ROLE_ADMIN } = process.env;

const Default: any = {
  align: "left",
  headerAlign: "left",
  editable: false,
};

const Fluid: any = {
  flex: 1,
  minWidth: 150,
};

export const userCol: GridColDef[] = [
  {
    field: "userId",
    headerName: "User ID",
    ...Default,
  },
  {
    field: "firstName",
    headerName: "First name",
    ...Fluid,
    ...Default,
  },
  {
    field: "lastName",
    headerName: "Last name",
    ...Fluid,
    ...Default,
  },
  {
    field: "middleName",
    headerName: "Middle Name",
    ...Fluid,
    ...Default,
  },
  {
    field: "email",
    headerName: "Email",
    ...Fluid,
    ...Default,
  },
  {
    field: "username",
    headerName: "Username",
    ...Fluid,
    ...Default,
  },
  {
    field: "userType",
    headerName: "Role",
    ...Fluid,
    ...Default,
    valueGetter: (params: any) => {
      let cell =
        params.row.userType == REACT_APP_ROLE_ADMIN ? "Admin" : "Customer";
      return cell;
    },
  },
];

export const petCol: GridColDef[] = [
  {
    field: "petId",
    headerName: "Pet ID",
    filterable: false,
    ...Default,
  },
  {
    field: "petName",
    headerName: "Pet name",
    ...Fluid,
    ...Default,
  },
  {
    field: "breed",
    headerName: "Breed",
    ...Fluid,
    ...Default,
  },
  {
    field: "birthdate",
    headerName: "Birthdate",
    type: "date",
    ...Fluid,
    ...Default,
    renderCell: (params: any) => (
      <span>{moment(params.row.birthdate).format("YYYY-MM-DD")}</span>
    ),
  },
  {
    field: "petType",
    headerName: "Type",
    ...Fluid,
    ...Default,
    valueGetter: (params) => {
      let Pet = PetTypes.find((item) => item.petType == params.row.petType);
      let cell = `${Pet?.petTypeAlias}`;
      return cell;
    },
  },
  {
    field: "owner",
    headerName: "Owner",
    hide: state.auth.currentUser?.userType != REACT_APP_ROLE_ADMIN,
    ...Fluid,
    ...Default,
    renderCell: (params: any) => (
      params.row.Owner && <span>{params.row.Owner.firstName} {params.row.Owner.lastName}</span>
    ),
  },
];

export const visitCol: GridColDef[] = [
  {
    field: "visitId",
    headerName: "Visit ID",
    filterable: false,
    ...Default,
  },
  {
    field: "petName",
    headerName: "Pet Name",
    ...Fluid,
    ...Default,
    valueGetter: (params) => params.row.pet.petName,
  },
  {
    field: "visitType",
    headerName: "Visit Type",
    ...Fluid,
    ...Default,
    valueGetter: (params) => {
      let Visit = VisitTypes.find(
        (item) => item.visitType == params.row.visitType
      );
      let cell = `${Visit?.visitTypeAlias}`;
      return cell;
    },
  },
  {
    field: "visitDate",
    headerName: "Visit Date",
    type: "date",
    ...Fluid,
    ...Default,
    renderCell: (params: any) => (
      <span>{moment(params.row.visitDate).format("YYYY-MM-DD")}</span>
    ),
  },
  {
    field: "notes",
    headerName: "Notes",
    ...Fluid,
    ...Default,
  },
];
