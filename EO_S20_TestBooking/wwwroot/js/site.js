﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var func = function () {
    document.getElementById("times").hidden = true;
}();

document.getElementById("dateButton").addEventListener(function (event) {
    document.getElementById("times").hidden = false;
});