const express = require("express");
const courses = require("./services/CourseService");

const app = express();
const port = process.env.port || 3000; 


app.use(express.json());
app.use(courses);


app.listen(port, () => console.log(`Listening to port: ${port}...`));