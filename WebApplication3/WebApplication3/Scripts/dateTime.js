function startTime() {

    var today = new Date();
    var month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";


    var mn = month[today.getMonth()];
    var y = today.getFullYear();
    f_date = today.getDate();
    f_date += " " + mn;
    f_date += " " + y;
    f_date += "<br />";

    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    m = checkTime(m);
    s = checkTime(s);

    document.getElementById('showDate').innerHTML = f_date + h + ":" + m + ":" + s;
    var t = setTimeout(function () { startTime() }, 500);
}

function checkTime(i) {
    if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
    return i;
}



