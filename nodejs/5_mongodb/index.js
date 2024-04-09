const mongoose = require('mongoose');

mongoose.connect('mongodb://127.0.0.1/testDB').then(()=> {
    console.log('connected successfully')
}).catch((err)=> {
    console.err('Connot cont to mongodb', err)
});


const courseSchema = new mongoose.Schema({
    name: String,
    creator: String,
    publishedDate: { type:Date, default: Date.now },
    isPublished: Boolean
})

const Course = mongoose.model('Course', courseSchema);


async function createCourse() {
    console.log("hi");
    const course = new Course({
        name: "Java",
        creator: "aki",
        isPublished: false 
    });
    
    const result = await course.save();
    console.log(result);
}

createCourse();