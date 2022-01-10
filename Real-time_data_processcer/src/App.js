import axios from "axios";

function App() {
  const user = () => {
    axios.post(`http://localhost:3000/api/`)
      .then(response => {
        console.log(response)
      })
      .catch(error => {
        console.log(error)
      });
  }

  const event = () => {
    axios.post(`http://localhost:3000/api/`)
      .then(response => {
        console.log(response)
      })
      .catch(error => {
        console.log(error)
      });
  }

  return (
    <div className="App">
      <header>
        <h1>Real-time Data Processor</h1>
      </header>
      <div className="">
        <button onClick={user}>
          Gen User
        </button>
        <button onClick={event}>
          Gen Event
        </button>
      </div>
    </div>
  );
}

export default App;
