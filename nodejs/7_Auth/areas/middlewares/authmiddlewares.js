function authenticationmiddleware (req, res, next) {
    const authHeader = req.headers['authorization'];
    let token = authHeader && authHeader.split(' ')[1]
    if (!token) {
        res.send(new response(true, "Failed", "Unauthorized user."))
    }
    next();
}


module.exports = authenticationmiddleware