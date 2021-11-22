const express = require("express");
const { appendFile } = require("fs");
const router = express.Router();
const peopleController = require("../controllers/person.controller");

router.get("/", peopleController.getPersonList);

module.exports = router;
