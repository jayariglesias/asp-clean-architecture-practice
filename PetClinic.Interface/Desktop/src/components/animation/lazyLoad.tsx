import LinearProgress from "@mui/material/LinearProgress";
import Box from "@mui/material/Box";
import Micorn from "components/animation/micorn";

const lazyLoad = () => {
  return (
    <div
      style={{
        margin: "auto",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column",
        height: "100vh",
      }}
    >
      <Micorn />
      <Box sx={{ width: "30vw" }}>
        <LinearProgress color="primary"  />
      </Box>
    </div>
  );
};

export default lazyLoad;
