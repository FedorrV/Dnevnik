var listStudents = document.getElementById("listStudens");
var listGrades = document.getElementById("listGrades");
var tableRatings = document.getElementById("tableRatings");

function changeOptionListGrades() {
    var GradeId = listGrades.options[listGrades.selectedIndex].value;
    var xhr = new XMLHttpRequest();

    var params = 'gradeId=' + GradeId;

    xhr.open("GET", "/Teacher/getStudents?" + params);
    //var body = JSON.stringify({ "teacherId": teacherId });
    xhr.send();

    xhr.onreadystatechange = function () {
        if (xhr.readyState != 4) return;

        var i = 0;
        while (i != listStudents.options.length)
            listStudents.remove(i);

        var bodyResponse = JSON.parse(xhr.responseText);

        listStudents.options[0] = new Option("-", 0);
        for (var i = 0; i < bodyResponse.length; i++) {
            var newOption = new Option(bodyResponse[i].fullname, bodyResponse[i].StudentId);
            listStudents.options[listStudents.options.length] = newOption;
        }


        //if (xhr.status != 200) {
        //    alert(xhr.status + ': ' + xhr.statusText);
        //} else {
        //    alert(xhr.responseText);
        //}

    }
}


function changeOptionListStudents() {
    if (listStudents.selectedIndex == 0)
        return;
    var StudentId = listStudents.options[listStudents.selectedIndex].value;
    var xhr = new XMLHttpRequest();

    var params = 'studentId=' + StudentId;

    xhr.open("GET", "/Parent/getRatings?" + params);
    //var body = JSON.stringify({ "teacherId": teacherId });
    xhr.send();
    
    xhr.onreadystatechange = function () {
        if (xhr.readyState != 4) return;
        var counRows = tableRatings.rows.length;
        for (var i = counRows - 1; i > 0; i--) {
            tableRatings.deleteRow(i);
        } 

        var bodyResponse = JSON.parse(xhr.responseText);
        for (var i = 0; i < bodyResponse.length; i++) {
            var curRating = bodyResponse[i];
            var curRow = tableRatings.insertRow(i+1);
            curRow.insertCell(0).innerHTML = curRating.subjectName;
            curRow.insertCell(1).innerHTML = curRating.teacherFullname;
            curRow.insertCell(2).innerHTML = curRating.dateLesson;
            curRow.insertCell(3).innerHTML = curRating.timeLesson;
            curRow.insertCell(4).innerHTML = curRating.rating;
        }
    }
}

listGrades.addEventListener("change", changeOptionListGrades);
listStudents.addEventListener("change", changeOptionListStudents);

changeOptionListGrades();