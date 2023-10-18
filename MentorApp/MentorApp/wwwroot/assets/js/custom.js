$(document).ready(function () {

    let path = window.location.pathname.split('/')[1];
    console.log(path)
    if (path == "")
    {
        $('#Home').addClass('active');
    }
    else
    {
        $('#' + path).addClass('active');
    }
})