import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import CssBaseline from "@mui/material/CssBaseline";
import History from "./Session";
import App from "./App";
import "./style.scss";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <History>
      <CssBaseline>
        <App />
      </CssBaseline>
    </History>
  </StrictMode>
);
