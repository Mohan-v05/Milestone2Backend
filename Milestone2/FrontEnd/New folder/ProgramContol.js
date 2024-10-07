//Courses retrive from Local storage
let courses = [];

const GetAllCoursesURL = 'http://localhost:5297/api/Program/Get-All-Programs';
const AddCourseURL = 'http://localhost:5297/api/Program/Add-program';
const UpdateCourseURL = 'http://localhost:5251/api/Course/Update-Course';
const DeleteCourseURL = 'http://localhost:5297/api/Program/Delete-Program/1230';

//Fetch Students Data from Database
async function GetAllCourses(){
    fetch(GetAllCoursesURL).then((response) => {
        return response.json();
    }).then((data) => {
        courses = data;
        CoursesTable();
    })
};
GetAllCourses()

//Add Courses in Database
async function AddCourse(CourseData){
    // Create new student
    await fetch(AddCourseURL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(CourseData)
    });
    GetAllCourses();
    CoursesTable();
};

//Update Course Fee
async function UpdateCourseFee(CourseId , NewFee){
    // Update Course
    await fetch(`${UpdateCourseURL}/${CourseId}/${NewFee}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
    });
    GetAllCourses();
    CoursesTable();
};

// Delete Course From Database
async function DeleteCourse(CourseId){
    // Delete Course
    await fetch(`${DeleteCourseURL}/${CourseId}`, {
        method: "DELETE"
    });
};

//Site Navebar
const toggle = document.querySelector(".fa-bars")
const toggleClose = document.querySelector(".fa-xmark")
const sideNavebar = document.querySelector(".side-navebar")

toggle.addEventListener("click" ,function(){
    sideNavebar.style.right = "0"
})

toggleClose.addEventListener("click" , function(){
    sideNavebar.style.right = "-60%"
})


//Form Submit Function
document.getElementById("course-offerings-form").addEventListener('submit',(event) =>{
    event.preventDefault();

    const courseName = document.getElementById("courseName").value.trim();
    const level = document.getElementById("level").value;
    const totalFee = Number(document.getElementById("fee").value.trim());
    let id = Number(Math.floor(Math.random()*1000000))

    const course = courses.find(c=>c.courseName == courseName && c.level == level)
    if(course){
        UpdateCourseFee(course.id , totalFee)
        document.getElementById('course-offerings-message').innerHTML = "Update Fee Successfully"
    }else{
        const CourseData = {
            id,
            courseName,
            level,
            totalFee
        };
        AddCourse(CourseData);
        document.getElementById('course-offerings-message').innerHTML = "Added New Course"
    }
    event.target.reset()

    setTimeout(()=>{
        document.getElementById('course-offerings-message').textContent = ""
    }, 2000);

    CoursesTable();
});


//Pop up box For Course details
document.getElementById("view-courses-btn").addEventListener("click" , ()=>{
    document.getElementById("overlay").style.display ="block"
    document.getElementById("popupbox").style.display ="block"
});

document.getElementById("overlay").addEventListener("click" , ()=>{
    document.getElementById("overlay").style.display ="none"
    document.getElementById("popupbox").style.display ="none"
});


//Show Table
function CoursesTable(){
    const table = document.getElementById('table-body-courses');
    table.innerHTML = "";
    courses.forEach((course) => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${course.programName}</td>
            <td>${course.Type}</td>
            <td>${course.totalFee}/= </td>
            <td><button class ="action-btn btn2" onclick="removeCourseById(event,${course.id})" >Remove</button></td>
        `;
        table.appendChild(row);
    });
}
CoursesTable();

//Remove Course
function removeCourseById(event,courseIdToRemove) {
    
    let indexToRemove = courses.findIndex(obj => obj.id === courseIdToRemove);
    if (indexToRemove !== -1) {
        DeleteCourse(courseIdToRemove)
        document.getElementById('course-offerings-message-2').style.color = "Green";
        document.getElementById('course-offerings-message-2').textContent = "Course Removed Successfully";
        const row = event.target.parentElement.parentElement;
        row.remove();
    } else {
        document.getElementById('course-offerings-message-2').textContent = "Course not found in local storage";
    }

    setTimeout(()=>{
        document.getElementById('course-offerings-message-2').textContent = "";
        }, 2000);
}


//Logout function

function logout() {
    window.location.href = "../01_Admin_Login/admin_login.html";
}

const logoutButton = document.getElementById('logoutButton');
logoutButton.addEventListener('click', function() {
  logout();
});