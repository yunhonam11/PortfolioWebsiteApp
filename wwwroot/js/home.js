/* home picture */
function pictureSaver()
{
    var form = $('#picture-form').closest('form');
    var formData = new FormData(form[0]);

    $.ajax({
        type: 'POST',
        url: '/Home/EditPicture',
        data: formData,
        processData: false,
        contentType: false,
    });
}

/* home title */
function titleEditor1() {
    document.getElementById("home-title").setAttribute("hidden", "hidden");
    document.getElementById("edit-home-title").removeAttribute("hidden");
}

function titleEditor2() {
    document.getElementById("home-title").removeAttribute("hidden");
    document.getElementById("edit-home-title").setAttribute("hidden", "hidden");
}

function titleSaver() {
    var data = $("#title-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Home/EditTitle',
        data: data,
        async: true
    });

    alert("Edit Successful!");
    $("#title-load").load(window.location.href + " #title-load");
}

/* home body */
function countTextarea() {
    var len = document.getElementById("body-edit-form").value.length;
    var finallen = 500 - len;

    if (finallen < 0) {
        document.getElementById("body-length").style.color = "red";
        document.getElementById("body-length").innerHTML = finallen * -1 + " characters over limit";
    } else {
        document.getElementById("body-length").style.color = "black";
        document.getElementById("body-length").innerHTML = finallen + " characters left";
    }
}

function bodyEditor1() {
    document.getElementById("home-body").setAttribute("hidden", "hidden");
    document.getElementById("edit-home-body").removeAttribute("hidden");
}

function bodyEditor2() {
    document.getElementById("home-body").removeAttribute("hidden");
    document.getElementById("edit-home-body").setAttribute("hidden", "hidden");
}

function bodySaver() {
    var data = $("#body-form").serialize();
    var dataChecker = $('#body-form').serializeArray();

    if (dataChecker[0].value.length <= 500) {
        $.ajax({
            type: 'POST',
            url: '/Home/EditBody',
            data: data,
            async: true
        });

        alert("Edit successful!");
        $("#body-load").load(window.location.href + " #body-load");
    } else {
        alert("Character count cannot exceed 500.");
    }
}
