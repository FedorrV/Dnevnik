var listSubj = document.getElementById("ListSubj");
var listTeachers = document.getElementById("listTeacher");

function changeOption() {
    var SubjectId = listSubj.options[listSubj.selectedIndex].value;
    var xhr = new XMLHttpRequest();

    var params = 'SubjectId=' + SubjectId;

    xhr.open("GET", "/Teacher/getTeachers?"+params);
   //var body = JSON.stringify({ "teacherId": teacherId });
    xhr.send();

    xhr.onreadystatechange = function () { 
        if (xhr.readyState != 4) return;

        var i = 0;
        while (i != listTeachers.options.length)
            listTeachers.remove(i);

        var bodyResponse = JSON.parse(xhr.responseText);

        for (var i = 0; i < bodyResponse.length; i++) {
            var newOption = new Option(bodyResponse[i].fullname, bodyResponse[i].TeacherId);
            listTeachers.options[listTeachers.options.length] = newOption;
        }
        

        //if (xhr.status != 200) {
        //    alert(xhr.status + ': ' + xhr.statusText);
        //} else {
        //    alert(xhr.responseText);
        //}

    }
}

listSubj.addEventListener("change", changeOption);