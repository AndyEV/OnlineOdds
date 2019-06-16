"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/oddPublisher").build();

connection.on("BroadcastData", data => {

    console.table(data);
    refresh(result);
    //getAll();
})


connection.start().then(function () {
    getAll();
}).catch(function (err) {
    return console.error(err.toString());
});

var model = $('#dataModel');
function getAll() {
    
    $.ajax({
        url: '/home/GetLatestOddData',
        dataType: 'json',
        data: data,
        success: refresh(data)
    });
}

function refresh(data) {
    for (var i = 0; i < data.length; i++) {
        var Html = "<tr><td>" +
            data[i].homeTeam + " VS " +
            data[i].awayTeam + "</td><td>" +
            data[i].homeOdd + "</td><td>" +
            data[i].drawOdd + "</td><td>" +
            data[i].awayOdd + "</td><td>" +
            data[i].lastUpdated + "</td></tr > ";
        model.empty().append(Html);

    }
}