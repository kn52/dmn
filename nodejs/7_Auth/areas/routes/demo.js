const express = require('express');
const  { response } = require('../responses/response');

const router = express.Router();
const baseurl= "/api/demo";

const posts = [
    {
        username: "aashish",
        post: "hi demom"
    }
]


router.get(baseurl + "/hellomessage", (req, res) => {

    res.send(new response(true, "Success!", "Hello"));
});


router.post(baseurl + "/getposts", (req, res) => {

    res.send(new response(true, "Success!", posts));
});

module.exports = router;