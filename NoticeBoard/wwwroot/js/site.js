// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#signupModal").click(function () {
        
        $("#signup-modal-content").fadeIn();
    });

$("#loginModal").click(function () {
    
        $("#login-modal-content").fadeIn();
    });

$(document).mouseup(function () {
    $("#signup-modal-content").fadeOut();
    $("#login-modal-content").fadeOut();
});

$("#creatbtn").click(function () {
    $("#signup-modal-content").fadeIn();
});