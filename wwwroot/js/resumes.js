function contactScroll() {
    window.scrollTo(0, document.getElementById("god-bod").scrollHeight);
}

function addResume() {
    var answer = prompt("Enter name of new resume");
    if (answer != null) {
        if (answer == '') {
            alert("Resume name cannot be blank!");
        } else {
            $.ajax({
                type: 'POST',
                url: '/Resumes/MakeResume/' + answer
            });

            alert("New resume successfully created!");
            window.location.href = "/Resumes/Index/" + answer;
        }
    }
}

function pictureSaver(type) {
    var form = $('#picture-form').closest('form');
    var formData = new FormData(form[0]);

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditPicture/' + type,
        data: formData,
        processData: false,
        contentType: false,
    });
}

/* aboutme section */
function aboutmeEditor1() {
    document.getElementById("aboutme-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("aboutme-edit-load2").removeAttribute("hidden");
}

function aboutmeEditor2() {
    document.getElementById("aboutme-edit-load1").removeAttribute("hidden");
    document.getElementById("aboutme-edit-load2").setAttribute("hidden", "hidden");
}

function aboutmeSaver(type) {
    var data = $("#aboutme-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditAboutme/' + type,
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#aboutme").load(window.location.href + " #aboutme");
}

/* objective section */
function objectiveEditor1() {
    document.getElementById("objective-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("objective-edit-load2").removeAttribute("hidden");
}

function objectiveEditor2() {
    document.getElementById("objective-edit-load1").removeAttribute("hidden");
    document.getElementById("objective-edit-load2").setAttribute("hidden", "hidden");
}

function objectiveSaver(type) {
    var data = $("#objective-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditObjective/' + type,
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#objective").load(window.location.href + " #objective");
}

/* education section */
function educationEditor1() {
    document.getElementById("education-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("education-edit-load2").removeAttribute("hidden");
}

function educationEditor2() {
    document.getElementById("education-edit-load1").removeAttribute("hidden");
    document.getElementById("education-edit-load2").setAttribute("hidden", "hidden");
}

function educationSaver(type) {
    var data = $("#education-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditEducation/' + type,
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#education").load(window.location.href + " #education");
}

function deleteEducation(id) { 
    $.ajax({
        type: 'POST',
        url: '/Resumes/DeleteEducation/' + id,
        async: true
    });

    alert("Delete successful!");
    $("#education").load(window.location.href + " #education");
}

/* skill section */
function skillEditor1() {
    document.getElementById("skill-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("skill-edit-load2").removeAttribute("hidden");
}

function skillEditor2() {
    document.getElementById("skill-edit-load1").removeAttribute("hidden");
    document.getElementById("skill-edit-load2").setAttribute("hidden", "hidden");
}

function skillSaver(type) {
    var data = $("#skill-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditSkill/' + type,
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#skill").load(window.location.href + " #skill");
}

function deleteSkill(id) {
    $.ajax({
        type: 'POST',
        url: '/Resumes/DeleteSkill/' + id,
        async: true
    });

    alert("Delete successful!");
    $("#skill").load(window.location.href + " #skill");
}

/* experience section */
function experienceEditor1() {
    document.getElementById("experience-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("experience-edit-load2").removeAttribute("hidden");
    document.getElementById("experience").style.minHeight = "40rem";
}

function experienceEditor2() {
    document.getElementById("experience-edit-load1").removeAttribute("hidden");
    document.getElementById("experience-edit-load2").setAttribute("hidden", "hidden");
    document.getElementById("experience").style.minHeight = "15rem";
}

function experienceSaver(type) {
    tinymce.triggerSave(true, true);
    $("#experience-edit-form").submit();
    var data = $("#experience-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resumes/EditExperience/' + type,
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#experience").load(window.location.href + " #experience");
}

function deleteExperience(id) {
    $.ajax({
        type: 'POST',
        url: '/Resumes/DeleteExperience/' + id,
        async: true
    });

    alert("Delete successful!");
    $("#experience").load(window.location.href + " #experience");
}
