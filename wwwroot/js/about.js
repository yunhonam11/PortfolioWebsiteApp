/* about title */
function titleEditor1() {
    document.getElementById("about-title").setAttribute("hidden", "hidden");
    document.getElementById("edit-about-title").removeAttribute("hidden");
}

function titleEditor2() {
    document.getElementById("about-title").removeAttribute("hidden");
    document.getElementById("edit-about-title").setAttribute("hidden", "hidden");
}

function titleSaver() {
    var data = $("#title-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/About/EditTitle',
        data: data,
        async: true
    });

    alert("Edit Successful!");
    $("#title-load").load(window.location.href + " #title-load");
}


/* about body */
function countTextarea() {
    var len = document.getElementById("body-edit-form").value.length;
    var finallen = 1000 - len;

    if (finallen < 0) {
        document.getElementById("body-length").style.color = "red";
        document.getElementById("body-length").innerHTML = finallen * -1 + " characters over limit";
    } else {
        document.getElementById("body-length").style.color = "white";
        document.getElementById("body-length").innerHTML = finallen + " characters left";
    }
}

function bodyEditor1() {
    document.getElementById("about-body").setAttribute("hidden", "hidden");
    document.getElementById("edit-about-body").removeAttribute("hidden");
}

function bodyEditor2() {
    document.getElementById("about-body").removeAttribute("hidden");
    document.getElementById("edit-about-body").setAttribute("hidden", "hidden");
}

function bodySaver() {
    var data = $("#body-form").serialize();
    var dataChecker = $('#body-form').serializeArray();

    if (dataChecker[0].value.length <= 1000) {
        $.ajax({
            type: 'POST',
            url: '/About/EditBody',
            data: data,
            async: true
        });

        alert("Edit successful!");
        $("#body-load").load(window.location.href + " #body-load");
    } else {
        alert("Character count cannot exceed 1000");
    }
}

/* about logos */
function logoSaver() {
    var form = $('#logos-form').closest('form');
    var formData = new FormData(form[0]);

    $.ajax({
        type: 'POST',
        url: 'About/AddLogo',
        data: formData,
        processData: false,
        contentType: false,
    });
}

function logoWiper() {
    $.ajax({
        type: 'POST',
        url: 'About/WipeLogos',
        async: true
    });

    alert("All logos deleted! Refresh page.");
}

