import "./App.css";
import "./asset/css/base.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { HomePage } from "./pages/HomePage";
import { UserExplorer } from "./pages/UserExplorer";
import { DetailUser } from "./pages/DetailUser";
function App() {
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
