import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { store } from "store";
import { Provider } from "react-redux";
import * as serviceWorker from "./serviceWorker";
import { createTheme, ThemeProvider, PaletteColorOptions } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import { red } from "@mui/material/colors";
import "./index.css";

declare module "@mui/material/styles" {
  interface Palette {
    tertiary: PaletteColorOptions;
  }
  interface PaletteOptions {
    tertiary: PaletteColorOptions;
  }
}

declare module "@mui/material/Button" {
  interface ButtonPropsColorOverrides {
    tertiary: true;
  }
}

const { palette } = createTheme();
const MTheme = createTheme({
  palette: {
    primary: {
      main: "#003a63",
    },
    secondary: {
      main: "#f48120",
    },
    tertiary: palette.augmentColor({ color: red }),
  },
});

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <ThemeProvider theme={MTheme}>
        <CssBaseline />
        <App />
      </ThemeProvider>
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
