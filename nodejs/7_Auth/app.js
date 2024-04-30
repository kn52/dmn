const express = require('express');
// const cors = require('cors');
const authenticationmiddleware = require('./areas/middlewares/authmiddlewares');
const demo = require('./areas/routes/demo');
const login = require('./areas/routes/login');

const port =  process.env.port || 3000;
const app = express();

// app.use(cors);
app.use(express.json());
app.use(demo);

app.use(authenticationmiddleware);
app.use(login);


app.listen(port, () => console.log(`Listening to port: ${port}...`));