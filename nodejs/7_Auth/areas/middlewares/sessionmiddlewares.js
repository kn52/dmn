require('dotenv').config();


function sessionmiddleware (req, res, next) {
    next();
}


module.exports = sessionmiddleware