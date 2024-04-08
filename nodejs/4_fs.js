const fs = require ('fs');


const file1 = fs.readFileSync('file1.txt');

console.log("" + file1);

fs.writeFileSync('file2.txt', "hello")

fs.appendFileSync('file2.txt', "world");


fs.mkdirSync('directory')