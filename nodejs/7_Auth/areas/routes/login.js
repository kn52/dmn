require('dotenv').config();
const express = require('express');
const jwt = require('jsonwebtoken');
const  { response } = require('../responses/response');

const router = express.Router();
const baseurl= "/api/login";

let refreshTokens = [];

router.post(baseurl + "/token", (req, res) => {
    const body = req.body;
    const token = body.token;
    if (refreshTokens == null || refreshTokens.includes(token)) {
        return res.send(new response(true, "Failed", "Unauthorized User."));
    }
   
    jwt.verify(token, process.env.REFRESH_TOKEN_SECRET, (err, user) => {
        
        if (err) {
            return res.send(new response(true, "Failed", "Something went wrong."))
        }
        const usr = {
            name: user.name
        }
        const jwttoken = getAccessToken(user);
        const rjwttoken = getRefreshAccessToken(user);
        refreshTokens = [];
        refreshTokens.push(rjwttoken);
        return res.send(new response(true, "Success!", {
            token: jwttoken,
            rtoken: rjwttoken
        }));
    });
});    


router.post(baseurl + "/deletetoken", (req, res) => {
    const body = req.body;
    if (refreshTokens == null) {
        return res.send(new response(true, "Success!", "Token deleted."));
    }
    const index = refreshTokens.findIndex(x => token == body.token);
    
    if (index != -1) {
        refreshTokens.splice(index, 1);
        return res.send(new response(true, "Success!", "Token deleted."));
    }
    
    if (refreshTokens.length == 0) {
        return res.send(new response(true, "Success!", "Token deleted."));
    }
    else {
        return res.send(new response(true, "Failed", "Something went wrong."));
    }
});

router.post(baseurl + "/userlogin", (req, res) => {
    const body = req.body;
    const user = {
        name: body.username
    }

    const jwttoken = getAccessToken(user);
    const rjwttoken = getRefreshAccessToken(user);
    refreshTokens.push(rjwttoken);
    return res.send(new response(true, "Success!", {
        token: jwttoken,
        rtoken: rjwttoken
    }));
});

app.delete("/logout", (req, res) => {
  refreshTokens = refreshTokens.filter((c) => c != req.body.token);
  res.status(204).send("Logged out!");
});


function getAccessToken(user) {
    return jwt.sign(user, process.env.ACCESS_TOKEN_SECRET, { expiresIn: '20s'});
}

function getRefreshAccessToken(user) {
    return jwt.sign(user, process.env.REFRESH_TOKEN_SECRET);
}

module.exports = router;