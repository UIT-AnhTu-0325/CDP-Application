var dbConn = require("../../config/db.config");

var Person = (person) => {
  this.id = person.id;

  this.first_name = person.first_name;
  this.last_name = person.last_name;
  this.email = person.email;
};

Person.getAllPeople = (result) => {
  dbConn.query("SELECT * FROM person", (err, res) => {
    if (err) {
      console.log("Error while fetching people", err);
      result(null, err);
    } else {
      console.log("People fetched successfully");
      result(null, res);
    }
  });
};

module.exports = Person;
