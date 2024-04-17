const ObjectID = require("mongodb").ObjectId;
const { Course } = require("../model/CourseModel");
const service = require("../dbservice/DbService");
const express = require("express");

const router = express.Router();
const baseurl = "/mongodb/courses";

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

const _op = {
    "gt": '$gt',
    "gte": '$gte',
    "lt": '$lt',
    "lte": '$lte',
    "gt": '$gt',
    "in": '$in',
    "nin": '$nin'
};

const _nop = {
    "or": '$or',
    "and": '$and',
    "not": '$not'
};

async function createCoursebyOBJ(obj) {
  const query = { name: obj.name };
  let d = await service.getData(query, "Courses");

  if (d.data != null && d.data?.length > 0) {
    return res.send("Course already exists.");
  }
  const course = new Course({
    name: obj.name,
    creator: obj.creator,
    tag: obj.tag,
    category: obj.category,
    isPublished: obj.isPublished,
    rating: obj.rating,
    publishedDate: new Date().toString(),
  });

  try {
    const result = await service.saveData(course, "Courses");
    console.log(result);
    return [true, result];
  } catch (e) {
    console.log(e);
    return [false, e];
  }
}

router.post(baseurl + "/createCourseCollection", async (req, res) => {
  try {
    const exists = await service.checkCollectionExistence("Courses");
    if (exists) {
      return res.send("Collection already exists");
    }
    const result = await service.createCollection("Courses");
    console.log(result);
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/createCourse", async (req, res) => {
  const obj = req.body.data;
  const course = new Course({
    name: obj.name,
    creator: obj.creator,
    tag: obj.tag,
    category: obj.category,
    isPublished: obj.isPublished,
    rating: obj.rating,
  });
  try {
    const result = await createCoursebyOBJ(course);
    res.send(result[1]);
  } catch (e) {
    res.send(e);
  }
});

router.post(baseurl + "/createCourseBy", async (req, res) => {
  const _dummy = req.body.data;
  let result = {
    count: 0,
    total: _dummy?.length,
    data: [],
  };
  for (const obj of _dummy) {
    const resp = await createCoursebyOBJ(obj);
    if (resp[0]) {
      result.count++;
      result.data.push(resp[1]);
    } else {
      result.data.push(resp[1]);
    }
  }
  res.send(result);
});

router.post(baseurl + "/updateCourse", async (req, res) => {
  try {
    const id = req.body.id;
    const obj = req.body.data;
    const query = { _id: new ObjectID(id) };
    
    let d = await service.getData(query, "Courses");

    if (d.data == null || d.data?.length == 0) {
      return res.send("Not Found!");
    }

    let course = d.data[0];
    if (obj.name != "" && obj.name != course.name) {
      course.name = obj.name;
    }
    if (obj.creator != "" && obj.creator != course.creator) {
      course.creator = obj.creator;
    }
    if (obj.category != "" && obj.category != course.category) {
      course.category = obj.category;
    }
    if (obj.isPublished != course.category) {
      course.isPublished = obj.isPublished;
    }
    if (obj.rating != 0 && obj.rating != course.rating) {
      course.rating = obj.rating;
    }
    if (obj?.tag?.length > 0) {
      course.tag = obj.tag;
    }
    console.log("course: ", course);
    const result = await service.updateData(query, course, "Courses");
    console.log(result);
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/deleteCourse", async (req, res) => {
  try {
    const id = req.body.id;
    const query = { _id: new ObjectID(id) };
    let d = await service.getData(query, "Courses");

    if (d.data == null || d.data?.length == 0) {
      return res.send("Not Found!");
    }
    const result = await service.deleteData(query, "Courses");
    console.log(result);
    res.send(result);
  } catch (e) {
    res.send(e);
  }
});

router.post(baseurl + "/getCourses", async (req, res) => {
  try {
    const query = {};
    const result = await service.getData(query, "Courses");
    console.log(result);
    res.send(result);
  } catch (e) {
    res.send(e);
  }
});

router.post(baseurl + "/getCoursesComparator", async (req, res) => {
  try {
    const operator  = req.body.data?.operator;
    const condition  = req.body.data?.condition;
    const key  = req.body.data?.key;
    const op = _op[operator];

    if (!op) {
        res.send("Invalid request");
    }

    const query = { [key]: { [op]: condition } };
    const result = await service.getData(query, "Courses");
    res.send(result);
  } catch (e) {
    res.send(e);
  }
});

router.post(baseurl + "/getCoursesLogical", async (req, res) => {
  try {
    const operator  = req.body.data?.operator;
    const condition  = req.body.data?.condition;
    const op = _nop[operator];

    if (!op) {
        res.send("Invalid request");
    }
    
    const query = { [op]:  condition };
    const result = await service.getData(query, "Courses");
    console.log(result);
    res.send(result);
  } catch (e) {
    res.send(e);
  }
});

module.exports = router;
