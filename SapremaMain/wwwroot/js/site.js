$('#primContainer').on('click', '.medItem', function () {
    $.ajax({
        type: "POST",
        data: JSON.stringify($(this).attr('data-medId')),
        url: '/Meditation/GetMeditationRecord',
        contentType: "application/json charset=UTF-8"
    }).success(function (data) {
        $('#editMed').html(data);
    });
});

$('#primContainer').on('click', '.groupItem', function () { 
    var foo = $(this).attr('data-group-item');
    $('#' + foo).css('display', 'block');
});

$('#primContainer').on('click', '.meditation-list-btn', function () {
    var foo = $(this).data('medid');
    $.ajax({
        type: "GET",
        data: {MeditationId : foo},
        url: '/Meditation/PlayMeditation',
        contentType: "application/json charset=UTF-8"
    }).success(function (data) {
        $('#primContainer').html(data);
    });
});

$('#primContainer').on('click', '.teacher-list-btn', function () {
    var foo = $(this).data('medid');
    $.ajax({
        type: "POST",
        data: { TeacherId: foo },
        url: '/Manage/ManageTeachers',
        contentType: "application/json charset=UTF-8"
    }).success(function (data) {
        $('#primContainer').html(data);
    });
});

function studentSelect() {
    document.getElementById("teacher-details").style.display = "none";
}

function teacherSelect() {
    document.getElementById("teacher-details").style.display = "block";
}

//Functions that deal with modal and partial C# views

//$('body').on('click', '.modal-link', function (e) {
//    e.preventDefault();
//    $(this).attr('data-target', '#modal-container');
//    $(this).attr('data-toggle', 'modal');
//});

//$('body').on('click', '.close', function () {
//    $('#modal-container').modal('hide');
//});

//$('#modal-container').on('hidden.bs.modal', function () {
//    $(this).removeData('bs.modal');
//});