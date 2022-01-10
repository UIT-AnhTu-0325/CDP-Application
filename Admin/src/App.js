import "./App.css";
import "./asset/css/base.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { HomePage } from "./pages/HomePage";
import { UserExplorer } from "./pages/UserExplorer";
import { DetailUser } from "./pages/DetailUser";
import asyncComponent from "./helpers/asyncComponent";
function App() {
  const HomePage = asyncComponent(() =>
    import("./pages/HomePage").then((module) => module.default)
  );

  const UserExplorer = asyncComponent(() =>
    import("./pages/UserExplorer").then((module) => module.default)
  );
  const DetailUser = asyncComponent(() =>
    import("./pages/DetailUser").then((module) => module.default)
  );

  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/user" element={<UserExplorer />} />
          <Route path="/detailuser" element={<DetailUser />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
