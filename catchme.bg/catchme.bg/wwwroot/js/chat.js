//Bind DOM elements
var sendForm = document.getElementById("send-form");
var sendButton = document.getElementById("send-button");
var messagesList = document.getElementById("messages-list");
var messageTextbox = document.getElementById("message-textbox");

function appendMessage(content) {
    var li = document.createElement("li");
    li.innerText = content;
    messagesList.appendChild(li);
}

//var connection = new signalR.HubConnection("/hubs/chat");
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/chat")
    .configureLogging(signalR.LogLevel.Information)
    .build();

sendForm.addEventListener("submit",
    function(evt) {
        var message = messageTextbox.value;
        messageTextbox.value = "";
        connection.send("Send", message);
        evt.preventDefault;
    });

connection.on("SendMessage",
    function(sender, message) {
        appendMessage(sender + " :" + message);
    });

connection.on("SendAction",
    function (sender, action) {
        appendMessage(sender + " :" + action);
    });

connection.start().catch(err => console.error(err.toString())).then(function() {
    messageTextbox.disabled = false;
    sendButton.disabled = false;
});