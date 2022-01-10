import "./App.css";
import "./asset/css/base.css";
import { Route, Routes } from "react-router-dom";
import { HomePage } from "./pages/HomePage";
import { UserExplorer } from "./pages/UserExplorer";
import { DetailUser } from "./pages/DetailUser";
function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/user" element={<UserExplorer />} />
        <Route path="/detailuser" element={<DetailUser />} />
      </Routes>
    </div>
  );
}

export default App;
