const express = require("express");
const { Course, validateData } = require("../models/coursemodel");
const { Category } = require("../models/categorymodel");
const router = express.Router();
const baseurl = "/api/courses";

router.post(baseurl + "/getAll", async (req, res) => {
  try {
    console.log(req.body);
    const result = await Course.find({});
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/getById", async (req, res) => {
  try {
    console.log(req.body);
    const body = req.body;
    const result = await Course.findById(body.id);
    if (!result) res.status(404).send("course not exist");
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/add", async (req, res) => {
  try {
    console.log(req.body);
    const body = req.body;
    const _er = validateData(body);
    if (_er.error) {
      res.send(_er.error.details);
    }
    const list = await Course.find({ name: body.name });
    if (list.length > 0) {
      res.send("Course already exist");
    } else {
      const category = await Category.findById(body.categoryId);
      const course = new Course({
        name: body.name,
        tag: body.tag,
        creator: body.creator,
        category: {
          categoryId: "",
          categoryName: "",
        },
        publishedDate: "" + new Date(),
        updatedDate: "" + new Date(),
        isPublished: body.isPublished,
        rating: body.rating,
      });

      if (category != null) {
        course.category.categoryId = body.categoryId;
        course.category.categoryName = category.name;
      }
      const result = await course.save();
      res.send(result);
      res.send("s");
    }
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/update", async (req, res) => {
  try {
    const body = req.body;
    const _er = validateData(body);
    if (_er.error) {
      res.send(_er.error.details);
    }

    const category = await Category.findById(body.categoryId);
      let course = Category.findById(body.id);
    if (course == null) {
      res.send("Not Found");
    }
    course.name = course.name == body.name ? course.name : body.name;
    course.tag = course.tag == body.tag ? course.tag : body.tag;
    course.creator =
      course.creator == body.creator ? course.creator : body.creator;
    course.updatedDate = "" + new Date();
    course.isPublished =
      course.isPublished == body.isPublished
        ? course.isPublished
        : body.isPublished;
    course.rating = course.rating == body.rating ? course.rating : body.rating;
    if (category != null) {
      course.category = {
        categoryId:
          course.category.categoryId == body.categoryId
            ? course.category.categoryId
            : body.categoryId,
            categoryName:
          course.category.categoryName != category.name
            ? course.category.categoryName
            : category.name,
      };
    }
    const result = await course.save();
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

router.post(baseurl + "/delete", async (req, res) => {
  try {
    const body = req.body;
    console.log(body);
    const result = await Course.findByIdAndDelete(body.id);
    if (result == null) {
      res.send("Not Found");
    }
    res.send(result);
  } catch (e) {
    console.log(e);
    res.send(e);
  }
});

module.exports = router;
