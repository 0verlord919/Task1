"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/signalrHub").build();

connection.on("AddUser", function (user) {
    console.log(user);
    var t = $('#users').DataTable();
    t.row.add(user).draw();
    $('.toast-body').text(user['fullName'] + ' joined the Avenger.');
    $('.toast').toast('show');
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

