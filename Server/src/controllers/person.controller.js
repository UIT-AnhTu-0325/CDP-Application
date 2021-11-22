const Person = require("../models/person.model");

exports.getPersonList = async (req, res) => {
  try {
    const people = await Person.find();
    res.status(200).json(people);
  } catch (err) {
    res.status(500).json({ error: err });
  }
};
