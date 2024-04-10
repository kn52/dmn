const mongoose = require("mongoose");
const Joi = require("joi");

const categorySchema = new mongoose.Schema({
  name: { type: String, required: true, minlength: 3 },
});

const Category = mongoose.model("Category", categorySchema);

function validateData(category) {
  const schema = {
    id: Joi.string().allow(null, ""),
    name: Joi.string().min(3).required(),
  };
  return Joi.validate(category, schema);
}


module.exports = {
    "Category" : Category,
    "categorySchema" : categorySchema,
    "validateData": validateData
};