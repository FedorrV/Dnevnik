var Students = document.getElementById("Students");
var listGrades = document.getElementById("listGrades");
var buttonSubmit = document.getElementById("buttonSubmit");
function changeOption() {
   
    var GradeId = listGrades.options[listGrades.selectedIndex].value;
    var xhr = new XMLHttpRequest();

    var params = 'gradeId=' + GradeId;

    xhr.open("GET", "/Teacher/getStudents?" + params);
    //var body = JSON.stringify({ "teacherId": teacherId });
    xhr.send();

    xhr.onreadystatechange = function () {
        if (xhr.readyState != 4) return;

        var i = 0;
        while (i != Students.options.length)
            Students.remove(i);

        var bodyResponse = JSON.parse(xhr.responseText);

        for (var i = 0; i < bodyResponse.length; i++) {
            var newOption = new Option(bodyResponse[i].fullname, bodyResponse[i].StudentId);
            Students.options[Students.options.length] = newOption;
        }


        //if (xhr.status != 200) {
        //    alert(xhr.status + ': ' + xhr.statusText);
        //} else {
        //    alert(xhr.responseText);
        //}

    }
}

function checkGrade() {
    if (listGrades.selectedIndex == 0) {
        alert("выберите класс");
        return false;
    }
    return;
}

listGrades.addEventListener("change", changeOption);
buttonSubmit.addEventListener('onclick', checkGrade);