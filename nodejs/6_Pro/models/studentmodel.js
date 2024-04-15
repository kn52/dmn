const mongoose = require("mongoose");
const Joi = require("joi");

const studentSchema = new mongoose.Schema({
  name: { type: String, required: true, minlength: 1, maxlength: 50 },
  isEnrolled: { type: Boolean, default: false },
  phoneNumber: { type: String, required: true, minlength: 10, maxlength: 15 },
});

studentSchema.set('toObject', {
  transform: function (doc, ret) {
    ret.id = ret._id
    delete ret._id
    delete ret.__v
  }
})

const Student = mongoose.model("Student", studentSchema);

function validateData(student) {
  const schema = {
    id: Joi.string().allow(null, ""),
    name: Joi.string().min(1).required(),
    isEnrolled: Joi.boolean(),
    phoneNumber: Joi.string().min(10).max(15).required()
  };
  return Joi.validate(student, schema);
}


module.exports = {
    "Student" : Student,
    "validateData": validateData
};