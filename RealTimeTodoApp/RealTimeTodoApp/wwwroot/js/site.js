// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/todoHub")
    .build();

connection.on("ReceiveUpdate", (todoItem) => {
    // Handle the received todoItem update
});

connection.start().then(() => {
    console.log("Connected to the hub");
});

