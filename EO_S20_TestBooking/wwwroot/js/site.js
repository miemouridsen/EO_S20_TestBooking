// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var hideTimes = (function () {
    document.getElementById("times").hidden = true;
    document.getElementById("dateButton2").hidden = true;
})();

document.getElementById("dateButton").addEventListener("click", function (event) {
    document.getElementById("times").hidden = false;
    document.getElementById("dateButton").hidden = true;
    document.getElementById("dateButton2").hidden = false;
});

//document.getElementById("dateButton2").addEventListener("click", function (event) {
//    document.getElementById("times").hidden = true;
//    document.getElementById("dateButton").hidden = false;
//    document.getElementById("dateButton2").hidden = true;
//});
