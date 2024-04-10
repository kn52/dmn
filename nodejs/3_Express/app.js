const express = require('express');
const middleware = require('./middlewares/middle');
const morgan = require('morgan');


const app = express();
const port = process.env.port || 3000; 

app.use(express.json());
app.use(middleware.myMiddleWare1);
app.use(middleware.myMiddleWare2);
app.use(morgan('tiny'));


let courses = [
    { id: "1", name: "javascript"},
    { id: "2", name: "python"},
    { id: "3", name: "dontnet"}
]

app.get('/', (req, res) =>{
    res.send("Hello")
});

app.get('/about', (req, res) =>{
    res.send("Hello world")
});

app.get('/contact', (req, res) =>{
    res.send("123456789")
});

app.get('/courses/:id', (req, res) =>{
    const params = req.params;
    const course = courses.find(x => x.id == params.id);
    if (!course) res.status(404).send('course not exist')
    res.send(course);

});

app.get('/courses', (req, res) =>{
    res.send(courses);
});

app.post('/courses', (req, res) =>{
    const body = req.body;
    const courseIndex = courses.findIndex(x => x.id == body.name);
    if (courseIndex == -1) {
        res.send('course already exist');
    }
    const course = {
        id: courses.length + 1,
        name:  body.name
    }
    courses.push(course)
    res.send(courses);
});

app.put('/courses', (req, res) =>{
    const body = req.body;
    const courseIndex = courses.findIndex(x => x.name == body.id);
    if (courseIndex == -1) {
        res.send('error');
    }
    courses[courseIndex].name = body.name;
    res.send('success');
});

app.delete('/courses', (req, res) =>{
    const body = req.body;
    const courseIndex = courses.findIndex(x => x.id == body.id);
    if (courseIndex == -1) {
        res.send('error');
    }
    courses.splice(courseIndex, 1);
    res.send('success');
});

app.listen(port, () => console.log('port:' + port));

