const express = require('express');
const mongoose = require("mongoose");
const categories = require('./routes/categories');
const students = require('./routes/students');
const courses = require('./routes/courses');

const app = express();
const port = process.env.port || 3000; 

mongoose.connect("mongodb://127.0.0.1/testDB")
  .then(() => {
    console.log("connected successfully");
  })
  .catch((err) => {
    console.err("Cannot can't to mongo_db", err);
  });

app.use(express.json());
app.use(categories);
app.use(students);
app.use(courses);


app.listen(port, () => console.log(`Listening to port: ${port}...`));

