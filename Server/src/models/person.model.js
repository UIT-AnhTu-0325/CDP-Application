const mongoose = require("mongoose");

const personSchema = new mongoose.Schema({
  id: {
    type: mongoose.Schema.Types.ObjectId,
  },
  first_name: {
    type: String,
  },
  last_name: {
    type: String,
  },
  email: {
    type: String,
  },
});

module.exports = mongoose.model("Person", personSchema);
