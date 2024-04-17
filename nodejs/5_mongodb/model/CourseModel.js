const mongoose = require("mongoose");

const courseSchema = new mongoose.Schema({
  name: { type: String, required: true },
  tag: {
    type: Array,
    validate: {
      validator: function (tags) {
        return tags.length > 1;
      },
    },
  },
  creator: { type: String, required: true },
  category: {
    type: String,
    required: true,
    enum: ["DSA", "Web", "Mobile", "Data Science"],
  },
  publishedDate: { type: String, default: new Date().toString() },
  isPublished: { type: Boolean, default: false },
  rating: { type: Number, required: true },
});


const Course = mongoose.model("Courses", courseSchema);

module.exports = {
    "Course": Course
}