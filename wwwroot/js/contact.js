function enableEditor() {
    document.getElementById("display-section").setAttribute("hidden", "hidden");
    document.getElementById("info-form").removeAttribute("hidden");
}

function disableEditor() {
    document.getElementById("display-section").removeAttribute("hidden");
    document.getElementById("info-form").setAttribute("hidden", "hidden");
}

function infoSaver() {
    var data = $("#info-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Contact/EditInfo',
        data: data,
        async: true
    });

    alert("Edit Successful!");
    $("#left-card").load(window.location.href + " #left-card");
}

function sendEmail() {
    var data = $("#emailer-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Contact/SendEmail',
        data: data,
        async: true
    });

    alert("Email sent!");
    $("#emailer-card").load(window.location.href + " #emailer-card");
}