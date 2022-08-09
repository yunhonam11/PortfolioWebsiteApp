function checkboxChanger() {
    var checkBox = document.getElementById("rememberMe");

    if (checkBox.getAttribute("value").toString() == "false") {
        checkBox.setAttribute('value', 'true');
    } else {
        checkBox.setAttribute('value', 'false');
    }
}
