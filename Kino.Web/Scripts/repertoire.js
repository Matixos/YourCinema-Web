$(document).ready(function () {
    $(".date-picker").datepicker({
        showOn: "button",
        buttonImage: "../Content/themes/images/calendar.png",
        buttonImageOnly: true,
        dateFormat: "yy-mm-dd"
    });

    $('#acceptDate').click(function () {
        window.location = "../../Repertoire/Index?date=" + document.getElementById('Date').value;
    });
});