const express = require("express");
const { Category, validateData } =  require("../models/categorymodel");
const router = express.Router();
const baseurl  = "/api/categories";



router.post(baseurl + "/getAll", async (req, res) => {
  try {
    console.log(req.body);
    const result = await Category.find({});
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
    const result = await Category.findById(body.id);
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
    const list = await Category.find({ name: body.name });
    if (list.length > 0) {
      res.send("Category already exist");
    } else {
      const category = new Category({
        name: body.name
      });
      const result = await category.save();
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
    const result = await Category.findByIdAndUpdate(
      body.id,
      { name: body.name },
      { new: true }
    );
    if (result == null) {
      res.send("Not Found");
    }
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
    const result = await Category.findByIdAndDelete(body.id);
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
