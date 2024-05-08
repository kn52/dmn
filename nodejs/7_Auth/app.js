require('dotenv').config();
const express = require('express');
// const cors = require('cors');
const authenticationmiddleware = require('./areas/middlewares/authmiddlewares');
const sessionmiddleware = require('./areas/middlewares/sessionmiddlewares');
const demo = require('./areas/routes/demo');
const login = require('./areas/routes/login');

const port =  process.env.PORT || 3000;
const app = express();

// app.use(cors);
app.use(express.json());
app.use(login);
app.use(sessionmiddleware);
app.use(authenticationmiddleware);
app.use(demo);



app.listen(port, () => console.log(`Listening to port: ${port}...`));