const mongoose = require("mongoose");
const  service   = require("./dbservice/DbService");

const uri = 'mongodb://localhost:27017';
const dbName = 'testDB';

const dummy = [
  {
    name: "javascript",
    creator: "aashish",
    tag: ["a", "b"],
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
    tag: ["a", "b"],
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
    tag: ["a", "b"],
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
    tag: ["a", "b"],
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
    tag: ["a", "b"],
    category: "Web",
    isPublished: false,
    rating: 3.5,
    publishedDate: {
      $date: "2024-04-09T13:36:55.040Z",
    },
  },
];

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
  publishedDate: { type: Date, default: Date.now },
  isPublished: { type: Boolean, default: false },
  rating: { type: Number, required: true },
});

const Course = mongoose.model("Courses", courseSchema);

async function createCourse() {
  const course = new Course({
    name: "Dotnet",
    creator: "akhil",
    category: "Web",
    isPublished: false,
    rating: 3.5,
  });
  try {
    const result = await service.saveData(course, "Courses");
    console.log(result);
  } catch (e) {
    for (var field in e.errors) {
      console.log(e.errors[field]);
    }
  }
}

async function updateCourse(id) {
  const query = { _id: new ObjectID(id) };
  let course = await service.getData(query, "Courses");

  if (!course) {
    return;
  }
  course.creator = "aki";
  const result = await service.saveData(course, "Courses");
  console.log(result);
}

async function deleteCourse(id) {
  const result = await service.deleteData(id, "Courses");
  console.log(result);
}

// $gt
// $gte
// $lt
// $lte
// $in
// $not in

async function getCourses() {
  const query = {};
  const courses = await service.getData(query, "Courses");
  console.log(courses);
}

async function getCoursesComparator() {
  let query = { rating: { $gt: 4 } };
  let courses = await service.getData(query, "Courses");
  console.log("gt: ", courses);

  query = { rating: { $lt: 4 } };
  courses = await service.getData(query, "Courses");
  console.log("lt: ", courses);

  query = { rating: { $lte: 4 } };
  courses = awaitservice.getData(query, "Courses");
  console.log("lte: ", courses);

  query = { rating: { $gte: 4 } };
  courses = await service.getData(query, "Courses");
  console.log("gte: ", courses);

  query = { rating: { $in: [4] } };
  courses = await service.getData(query, "Courses");
  console.log("in: ", courses);

  query = { rating: { $nin: [4] } };
  courses = await service.getData(query, "Courses");
  console.log("not in: ", courses);
}

async function getCoursesLogical() {
  const query = {};
  const courses = await service.service
    .getData(query, "Courses")
    .or([{ creator: "aashish" }, { creator: "akhil" }]);
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
    const result = await service.saveData(course, "Courses");
    console.log(result);
  } catch (e) {
    console.log(e);
  }
}

function createCourseBy() {
  for (const obj of dummy) {
    createCoursebyOBJ(obj);
  }
}

// createCourse();
// createCourseBy();
getCourses();
// getCoursesComparator();
// getCoursesLogical();
// updateCourse('66153c7aa5864f145d9c2f44');
// deleteCourse('661596519e318c2f7d9ce58f');
