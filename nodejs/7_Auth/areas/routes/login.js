const express = require('express');
const jwt = require('jsonwebtoken');
const  { response } = require('../responses/response');

const router = express.Router();
const baseurl= "/api/login";

router.post(baseurl + "/userlogin", (req, res) => {

    const body = req.body;

    const user = {
        name: body.username
    }

    const jwttoken = jwt.sign(user, "asd");
    res.send(new response(true, "Success!", jwttoken));
});


module.exports = router;