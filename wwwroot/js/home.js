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

    //alert("Edit was successful!")
    //$("#picture-load").load(window.location.href + " #picture-load");
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

    $.ajax({
        type: 'POST',
        url: '/Home/EditBody',
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#body-load").load(window.location.href + " #body-load")
}
