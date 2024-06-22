﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/rateHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveRate", function (request) {
    var li;
    for (var i = 0; i < request.length; i++) {
        li = document.createElement("li");
        document.getElementById("rateList").appendChild(li);
        li.textContent = `${request[i].code} : ${request[i].rate}`;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var currencyPair = document.getElementById("currencyPairInput").value;
    var rate = parseFloat(document.getElementById("rateInput").value);
    var dataToSend = [];
    dataToSend.push({ Code: currencyPair, Rate: rate })
    console.log(JSON.stringify(dataToSend))
    connection.invoke("SendRate", dataToSend).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});