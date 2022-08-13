/*objective section*/
function objectiveEditor1() {
    document.getElementById("objective-edit-load1").setAttribute("hidden", "hidden");
    document.getElementById("objective-edit-load2").removeAttribute("hidden");
}

function objectiveEditor2() {
    document.getElementById("objective-edit-load1").removeAttribute("hidden");
    document.getElementById("objective-edit-load2").setAttribute("hidden", "hidden");
}

function objectiveSaveR() {
    var data = $("#objective-edit-form").serialize();

    $.ajax({
        type: 'POST',
        url: '/Resume/EditObjective',
        data: data,
        async: true
    });

    alert("Edit successful!");
    $("#objective").load(window.location.href + " #objective");
}

