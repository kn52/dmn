const mongoose = require("mongoose");
const Joi = require("joi");

const courseSchema = new mongoose.Schema({
  name: { type: String, required: true },
  tag: {
    type: Array,
    validate: {
      validator: function (tags) {
        return tags.length > 1
      },
    },
  },
  creator: { type: String, required: true },
  category: {
    categoryId: { type: String, required: false },
    categoryName: { type: String, required: false },
  },
  publishedDate: { type: String, default: new Date().toString() },
  updatedDate: { type: String, default: new Date().toString() },
  isPublished: { type: Boolean, default: false },
  rating: { type: Number, required: true },
});

courseSchema.set('toObject', {
  transform: function (doc, ret) {
    ret.id = ret._id
    delete ret._id
    delete ret.__v
  }
})

const Course = mongoose.model("Course", courseSchema);

function validateData(student) {
  const schema = {
    id: Joi.string().allow(null, ""),
    categoryId: Joi.string().allow(null, ""),
    name: Joi.string().min(1).required(),
    tag: Joi.array().required(),
    creator: Joi.string().required(),
    publishedDate: Joi.string().allow(null, ""),
    updatedDate: Joi.string().allow(null, ""),
    isPublished: Joi.boolean(),
    rating: Joi.number().required()
  };
  return Joi.validate(student, schema);
}


exports.Course = Course;
exports.validateData = validateData;
