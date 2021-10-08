import * as React from "react";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Container from "@mui/material/Container";
import Copyright from "./copyright";
import { Navigator } from "./navigator";

const Dashboard = ({
  children,
  title,
}: {
  children: React.ReactNode;
  title?: string;
}) => {
  return (
    <>
      <Box sx={{ display: "flex" }}>
        <Navigator title={title} />
        <Box
          component="main"
          sx={{
            backgroundColor: (theme) =>
              theme.palette.mode === "light"
                ? theme.palette.grey[100]
                : theme.palette.grey[900],
            flexGrow: 1,
            height: "100vh",
            overflow: "auto",
          }}
        >
          <Toolbar />
          <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            {children}
            <Copyright title="Pet Clinic" sx={{ pt: 4 }} />
          </Container>
        </Box>
      </Box>
    </>
  );
};

export default Dashboard;
