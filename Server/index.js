const express = require("express");
const mongoose = require("mongoose");

const url = "mongodb://localhost/Test";

const app = express();

const port = process.env.PORT || 9000;

mongoose.connect(url, { useNewUrlParser: true, useUnifiedTopology: true });
const con = mongoose.connection;
con.on("open", () => {
  console.log("Database connected");
});

app.get("/", (req, res) => {
  res.send("Hello World");
});

const personRoutes = require("./src/routes/person.route");
app.use("/api/v1/person", personRoutes);

app.listen(port, () => {
  console.log(`Express Server is running at port ${port}`);
});
