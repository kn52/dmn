const mongoose = require("mongoose");

const dummy = [
  {
    name: "javascript",
    creator: "aashish",
    tag: ['a', 'b'],
    isPublished: true,
    publishedDate: {
      $date: "2024-04-09T12:32:12.910Z",
    },
    rating: 4.5,
    category: "Web",
  },
  {
    name: "Java",
    creator: "aashish",
    tag: ['a', 'b'],
    isPublished: false,
    publishedDate: {
      $date: "2024-04-09T12:35:12.489Z",
    },
    rating: 4,
    category: "Web",
  },
  {
    name: "Ruby",
    creator: "aki",
    tag: ['a', 'b'],
    isPublished: false,
    rating: 3,
    publishedDate: {
      $date: "2024-04-09T13:02:30.587Z",
    },
    category: "Web",
  },
  {
    name: "Nextjs",
    creator: "akhil",
    tag: ['a', 'b'],
    isPublished: false,
    rating: 3.5,
    publishedDate: {
      $date: "2024-04-09T13:03:09.147Z",
    },
    category: "Web",
  },
  {
    name: "Dotnet",
    creator: "akhil",
    tag: ['a', 'b'],
    category: "Web",
    isPublished: false,
    rating: 3.5,
    publishedDate: {
      $date: "2024-04-09T13:36:55.040Z",
    },
  },
];

mongoose.connect("mongodb://127.0.0.1/testDB")
  .then(() => {
    console.log("connected successfully");
  })
  .catch((err) => {
    console.err("Connot cont to mongodb", err);
  });

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
    type: String,
    required: true,
    enum: ["DSA", "Web", "Mobile", "Data Science"],
  },
  publishedDate: { type: Date, default: Date.now },
  isPublished: { type: Boolean, default: false },
  rating: { type: Number, required: true },
});

const Course = mongoose.model("Course", courseSchema);

async function createCourse() {
  const course = new Course({
    name: "Dotnet",
    creator: "akhil",
    category: "Web",
    isPublished: false,
    rating: 3.5,
  });

  try {
    const result = await course.save();
    console.log(result);
  } catch (e) {
    for(var field in e.errors) {
        console.log(e.errors[field]);
    }
  }
}

async function updateCourse(id) {
  let course = await Course.findById(id);

  if (!course) {
    return;
  }
  course.creator = "aki";
  const result = await course.save();
  console.log(result);
}

async function deleteCourse(id) {
  const result = await Course.findByIdAndDelete(id);

  console.log(result);
}

// $gt
// $gte
// $lt
// $lte
// $in
// $not in

async function getCourses() {
  const courses = await Course.find({}).sort({ rating: 1 });
  console.log(courses);
}

async function getCoursesComparator() {
  const courses = await Course.find({ rating: { $gt: 4 } });
  console.log(courses);
}

async function getCoursesLogical() {
  const courses = await Course.find({}).or([
    { creator: "aashish" },
    { creator: "akhil" },
  ]);
  console.log(courses);
}

async function createCoursebyOBJ(obj) {
    const course = new Course({
      name: obj.name,
      creator: obj.creator,
      tag: obj.tag,
      category: obj.category,
      isPublished: obj.isPublished,
      rating: obj.rating,
    });
  
    try {
      const result = await course.save();
      console.log(result);
    } catch (e) {
      console.log(e);
    }
}


function createCourseBy() {
    for (const obj of dummy) {
        createCoursebyOBJ(obj)
    }
}
// createCourse();
// createCourseBy();
getCourses();
// getCoursesComparator();
// getCoursesLogical();
// updateCourse('66153c7aa5864f145d9c2f44');
// deleteCourse('66153c7aa5864f145d9c2f44');
