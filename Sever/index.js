const express = require("express");

const app = express();

const port = process.env.PORT || 9000;

app.get("/", (req, res) => {
  res.send("Hello World");
});

const personRoutes = require("./src/routes/person.route");
app.use("/api/v1/person", personRoutes);

app.listen(port, () => {
  console.log(`Express Server is running at port ${port}`);
});
