const express = require("express");
const { Student, validateData } = require("../models/studentmodel");
const { resposnes } = require('../responses/response');
const router = express.Router();
const baseurl = "/api/students";

router.post(baseurl + "/getAll", async (req, res) => {
  try {
    console.log(req.body);
    const result = await Student.find({});
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
    const result = await Student.findById(body.id);
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
    const list = await Student.find({ name: body.name });
    if (list.length > 0) {
      res.send("Student already exist");
    } else {
      const student = new Student({
        name: body.name,
        isEnrolled: body.isEnrolled,
        phoneNumber: body.phoneNumber,
      });
      const result = await student.save();
      res.send(result);
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
    const student = await Student.findById(body.id);
    if (student == null) {
      res.send("Not Found");
    }
    student.name = student.name == body.name ? student.name : body.name;
    student.isEnrolled =
      student.isEnrolled == body.isEnrolled
        ? student.isEnrolled
        : body.isEnrolled;
    student.phoneNumber =
      student.phoneNumber == body.phoneNumber
        ? student.phoneNumber
        : body.phoneNumber;
    const result = await student.save();
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
    const result = await Student.findByIdAndDelete(body.id);
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
