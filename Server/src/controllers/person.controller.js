const Person = require("../models/person.model");

exports.getPersonList = (req, res) => {
  //console.log("All people");
  Person.getAllPeople((err, people) => {
    console.log("herre");
    if (err) {
      res.send(err);
    } else {
      res.send(people);
    }
  });
};
