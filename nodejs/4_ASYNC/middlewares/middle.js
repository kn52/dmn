function middleware1(req, res, next){
    console.log("I am middleware 1");
    next();
    // console.log("req: " + req);
    // console.log("res: " + res);
};


function middleware2(req, res, next) {
    console.log("I am middleware 2");
    next();
    // console.log("req: " + req);
    // console.log("res: " + res);
};

module.exports = {
    myMiddleWare1: middleware1,
    myMiddleWare2: middleware2
};