require('dotenv').config();
const jwt = require('jsonwebtoken');
const { response } = require('../responses/response');

function authenticationmiddleware (req, res, next) {
    const authHeader = req.headers['authorization'];
    let token = authHeader && authHeader.split(' ')[1]
    if (!token) {
        return res.send(new response(true, "Failed", "Unauthorized User."));
    }

    jwt.verify(token, process.env.ACCESS_TOKEN_SECRET, (err, user) => {
        if (err) {
            return res.send(new response(true, "Failed", "Something went wrong."))
        }
        next();
    });
    
} 


module.exports = authenticationmiddleware