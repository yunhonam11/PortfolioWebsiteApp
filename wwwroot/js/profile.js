/* top menu */

function changeMenu(mode) {
    if (mode == '1') {
        document.getElementById("menu-1").setAttribute("hidden", "hidden");
        document.getElementById("menu-2").setAttribute("hidden", "hidden");
        document.getElementById("menu-3").removeAttribute("hidden");
        document.getElementById("menu-4").removeAttribute("hidden");
        document.getElementById("about").setAttribute("hidden", "hidden");
        document.getElementById("contact-info").removeAttribute("hidden");
    } else {
        document.getElementById("menu-1").removeAttribute("hidden");
        document.getElementById("menu-2").removeAttribute("hidden");
        document.getElementById("menu-3").setAttribute("hidden", "hidden");
        document.getElementById("menu-4").setAttribute("hidden", "hidden");
        document.getElementById("about").removeAttribute("hidden");
        document.getElementById("contact-info").setAttribute("hidden", "hidden");
    }
}

/* Profile Picture */

function profilePicSaver(username) {
    var form = $('#profile-pic-form').closest("form");
    var formData = new FormData(form[0]);

    $.ajax({
        type: 'POST',
        url: '/Profile/EditProfilePic/' + username,
        data: formData,
        processData: false,
        contentType: false,
    });
}

/* About Description */

function countTextarea() {
    var len = document.getElementById("about-textarea").value.length;
    var finallen = 1000 - len;

    if (finallen < 0) {
        finallen = finallen * -1;
        document.getElementById("about-length").style.color = "red";
        document.getElementById("about-length").innerHTML = finallen + " characters over limit";
    } else {
        document.getElementById("about-length").style.color = "gray";
        document.getElementById("about-length").innerHTML = finallen + " characters left";
    }
}

function aboutNullEditor1() {
    document.getElementById("about-id1").setAttribute("hidden", "hidden");
    document.getElementById("about-id2").removeAttribute("hidden");
}

function aboutNullEditor2() {
    document.getElementById("about-id1").removeAttribute("hidden");
    document.getElementById("about-id2").setAttribute("hidden", "hidden");
}

function aboutEditor1() {
    document.getElementById("about-id3").setAttribute("hidden", "hidden");
    document.getElementById("about-id4").removeAttribute("hidden");
}

function aboutEditor2() {
    document.getElementById("about-id3").removeAttribute("hidden");
    document.getElementById("about-id4").setAttribute("hidden", "hidden");
}

function aboutSaver(username, state) {
    if (state == 'null') {
        var dataChecker = $("#about-null-form").serializeArray();
        var data = $("#about-null-form").serialize();
    } else {
        var dataChecker = $("#about-form").serializeArray();
        var data = $("#about-form").serialize();
    }

    if (dataChecker[0].value.length <= 1000) {
        $.ajax({
            type: 'POST',
            url: '/Profile/EditAbout/' + username,
            data: data,
            async: true,
        });

        alert("Edit successful!");
        $("#info-card").load(window.location.href + " #info-card");
    } else {
        alert("Character count cannot exceed 1000.");
    }
}

/* Phone number */

function phoneNullEditor1() {
    document.getElementById("phone-id1").setAttribute("hidden", "hidden");
    document.getElementById("phone-id2").removeAttribute("hidden");
}

function phoneNullEditor2() {
    document.getElementById("phone-id1").removeAttribute("hidden");
    document.getElementById("phone-id2").setAttribute("hidden", "hidden");
}

function phoneEditor1() {
    document.getElementById("phone-id3").setAttribute("hidden", "hidden");
    document.getElementById("phone-id4").removeAttribute("hidden");
}

function phoneEditor2() {
    document.getElementById("phone-id3").removeAttribute("hidden");
    document.getElementById("phone-id4").setAttribute("hidden", "hidden");
}

function phoneSaver(username, state) {
    if (state == 'null') {
        var dataChecker = $("#phone-null-form").serializeArray();
        var data = $("#phone-null-form").serialize();
    } else {
        var dataChecker = $("#phone-form").serializeArray();
        var data = $("#phone-form").serialize();
    }

    var regEx = /^\(?(\d{3})\)?[- ]?(\d{3})[- ]?(\d{4})$/;
    if (regEx.test(dataChecker[0].value)) {
        $.ajax({
            type: 'POST',
            url: '/Profile/EditPhone/' + username,
            data: data,
            async: true,
        });

        alert("Edit successful!");
        $("#info-card").load(window.location.href + " #info-card");
    } else {
        alert("Phone number format must be xxx-xxx-xxxx where x is a number");
    }
}

function phoneDeleter(username) {
    $.ajax({
        type: 'POST',
        url: '/Profile/DeletePhone/' + username,
        async: true,
    });

    alert("Delete Successful!");
    $("#info-card").load(window.location.href + " #info-card");
}

/* Birthdate */

function birthNullEditor1() {
    document.getElementById("birth-id1").setAttribute("hidden", "hidden");
    document.getElementById("birth-id2").removeAttribute("hidden");
}

function birthNullEditor2() {
    document.getElementById("birth-id1").removeAttribute("hidden");
    document.getElementById("birth-id2").setAttribute("hidden", "hidden");
}

function birthEditor1() {
    document.getElementById("birth-id3").setAttribute("hidden", "hidden");
    document.getElementById("birth-id4").removeAttribute("hidden");
}

function birthEditor2() {
    document.getElementById("birth-id3").removeAttribute("hidden");
    document.getElementById("birth-id4").setAttribute("hidden", "hidden");
}

function birthSaver(username, state) {
    if (state == 'null') {
        var data = $("#birth-null-form").serialize();
    } else {
        var data = $("#birth-form").serialize();
    }

    $.ajax({
        type: 'POST',
        url: '/Profile/EditBirth/' + username,
        data: data,
        async: true,
    });

    alert("Edit successful!");
    $("#info-card").load(window.location.href + " #info-card");
}

function birthDeleter(username) {
    $.ajax({
        type: 'POST',
        url: '/Profile/DeleteBirth/' + username,
        async: true,
    });

    alert("Delete Successful!");
    $("#info-card").load(window.location.href + " #info-card");
}

/* Address */

function addressNullEditor1() {
    document.getElementById("address-id1").setAttribute("hidden", "hidden");
    document.getElementById("address-id2").removeAttribute("hidden");
}

function addressNullEditor2() {
    document.getElementById("address-id1").removeAttribute("hidden");
    document.getElementById("address-id2").setAttribute("hidden", "hidden");
}

function addressEditor1() {
    document.getElementById("address-id3").setAttribute("hidden", "hidden");
    document.getElementById("address-id4").removeAttribute("hidden");
}

function addressEditor2() {
    document.getElementById("address-id3").removeAttribute("hidden");
    document.getElementById("address-id4").setAttribute("hidden", "hidden");
}

function addressSaver(username, state) {
    if (state == 'null') {
        var data = $("#address-null-form").serialize();
    } else {
        var data = $("#address-form").serialize();
    }

    $.ajax({
        type: 'POST',
        url: '/Profile/EditAddress/' + username,
        data: data,
        async: true,
    });

    alert("Edit successful!");
    $("#info-card").load(window.location.href + " #info-card");
}

function addressDeleter(username) {
    $.ajax({
        type: 'POST',
        url: '/Profile/DeleteAddress/' + username,
        async: true,
    });

    alert("Delete Successful!");
    $("#info-card").load(window.location.href + " #info-card");
}
