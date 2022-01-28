"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
document.getElementById("sendButton").disabled = true;


var Selectedchanel = "";

function myFunction(chanel) {
    Selectedchanel = chanel;
    //Disable send button until connection is established
    document.getElementById("sendButton").disabled = false;
    $.ajax({
        url: "/Home/GetList",
        data: { "chanelID": Selectedchanel },
        type: 'GET',
        success: function (result) {
            document.getElementById("messagesList").innerHTML = "";
            /* listeleme yapılacak fonksiyon buraya yazılacak.*/

        },
        error: function (result) {
        }
    });
}


connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} :  ${message}`;

    $.ajax({
        url: "/Home/Create",
        data: { 'UserName': user, 'Message': message, "Chanel": Selectedchanel },
        type: 'GET',
        success: function (result) {
            //do the necessary updations
        },
        error: function (result) {
        }
    });
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});