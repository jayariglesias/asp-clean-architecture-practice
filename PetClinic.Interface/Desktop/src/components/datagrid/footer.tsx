import { useState } from "react";
import {GridPagination} from "@mui/x-data-grid/";
import IconButton from "@mui/material/IconButton";
import TextField from "@mui/material/TextField";
import ClearIcon from "@mui/icons-material/Clear";
import SearchIcon from "@mui/icons-material/Search";
import { useStyles } from "./themes";
import Grid from "@mui/material/Grid";
import Divider from "@mui/material/Divider";
import DateRangePicker, { DateRange } from "@mui/lab/DateRangePicker";
import DateAdapter from "@mui/lab/AdapterMoment";
import LocalizationProvider from "@mui/lab/LocalizationProvider";
import Box from "@mui/material/Box";

export const Footer = (props: {
  clearSearch: () => void;
  onChange: () => void;
  value: DateRange<Date>;
  dateRange: boolean; // NIREMOVED KO
}) => {
  const classes = useStyles();

  return (
    <>
      <Divider />
      <div className={classes.root}>
        <div />
        <GridPagination />
      </div>
    </>
  );
};
