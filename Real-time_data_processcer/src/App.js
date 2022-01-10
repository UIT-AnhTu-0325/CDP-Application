import axios from "axios";

function App() {
  var instance = axios.create({
    baseURL: "https://localhost:44304/api",
    timeout: 10000,
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Content-Type": "application/json",
    },
  });
  axios.defaults.headers.post["Content-Type"] =
    "application/x-www-form-urlencoded";

  const user = () => {
    instance
      .post(`Profile`, {
        name: "test1",
        address: "test1",
        email: "test1@gmail.com",
        phoneNumber: "0111222",
        gender: "Male",
        dob: "2022-01-10T18:31:03.607Z",
        createdAt: "2022-01-10T18:31:03.607Z",
        updatedAt: "2022-01-10T18:31:03.607Z",
        firstActivity: "2022-01-10T18:31:03.607Z",
        lastActivity: "2022-01-10T18:31:03.607Z",
      })
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const event = () => {
    axios
      .post(`http://localhost:3000/api/`)
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className="App">
      <header>
        <h1>Real-time Data Processor</h1>
      </header>
      <div className="">
        <button onClick={user}>Gen User</button>
        <button onClick={event}>Gen Event</button>
      </div>
    </div>
  );
}

export default App;
