function additon(x, y) {
  console.log("add:", x + y);
}

function subtract(x, y) {
  console.log("subtract:", x - y);
}

function divide(x, y) {
  if (y == 0) {
    console.log("divide: infinity");
  } else {
    console.log("divide:", x / y);
  }
}

function multiply(x, y) {
  console.log("multiply:", x * y);
}

function mod(x, y) {
    if (y == 0) {
      console.log("divide: infinity");
    } else {
      console.log("divide:", x % y);
    }
  }

module.exports = {
  additon: additon,
  subtract: subtract,
  divide: divide,
  multiply: multiply,
  mod: mod
};
