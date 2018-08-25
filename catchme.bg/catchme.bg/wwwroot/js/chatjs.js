        $(function () {

            setScreen(false);

            var connection = new signalR.HubConnectionBuilder()
                .withUrl("/hubs/chat")
                .configureLogging(signalR.LogLevel.Information)
                .build();

            

            connection.start().catch(err => console.error(err.toString())).then(function () {
                registerClientMethods(connection);
                registerEvents(connection);
            });

        });

        function setScreen(isLogin) {

            if (!isLogin) {

                $("#divChat").hide();
                //$("#divLogin").show();
            } else {

                $("#divChat").show();
                //$("#divLogin").hide();
            }

        }

        function AddUser(connection, id, name, privateMessages) {

            var userId = $('#hdId').val();

            var code = "";

            if (userId == id) {

                code = $('<div class="loginUser">' + name + "</div>");

            } else {

                code = $('<a id="' + id + '" class="user" >' + name + '<a>');

                $(code).dblclick(function () {

                    var id = $(this).attr('id');

                    if (userId != id)
                        OpenPrivateChatWindow(connection, id, name, privateMessages);

                });
            }

            $("#divusers").append(code);

        }

        function AddMessage(userName, message) {
            $('#divChatWindow').append('<div class="message"><span class="userName">' +
                userName +
                '</span>: ' +
                message +
                '</div>');

            var height = $('#divChatWindow')[0].scrollHeight;
            $('#divChatWindow').scrollTop(height);
}

        function registerEvents(connection) {

            $("#btnStartChat").click(function () {

                var name = $("#txtNickName").val();
                if (name.length > 0) {
                    connection.server.connect(name);
                } else {
                    alert("Please enter name");
                }

            });


            $('#btnSendMsg').click(function () {

                var msg = $("#txtMessage").val();
                if (msg.length > 0) {

                    //var userName = $('#hdUserName').val();
                    connection.send("SendMessageToAll", msg);
                    $("#txtMessage").val('');
                }
            });


            $("#txtNickName").keypress(function (e) {
                if (e.which == 13) {
                    $("#btnStartChat").click();
                }
            });

            $("#txtMessage").keypress(function (e) {
                if (e.which == 13) {
                    $('#btnSendMsg').click();
                }
            });


        }

        function registerClientMethods(connection) {

            // Calls when user successfully logged in
            connection.on("OnConnected",
                function (id, userName, allUsers, messages, privateMessages) {

                    setScreen(true);

                    $('#hdId').val(id);
                    $('#hdUserName').val(userName);
                    $('#spanUser').html(userName);

                    // Add All Users
                    for (i = 0; i < allUsers.length; i++) {

                        AddUser(connection, allUsers[i].connectionId, allUsers[i].userName, privateMessages);
                    }

                    // Add Existing Messages
                    for (i = 0; i < messages.length; i++) {

                        AddMessage(messages[i].userName, messages[i].message);
                    }

                    

                });

            // On New User Connected
            connection.on("NewUserConnected",
                function (id, name, privateMesssages) {
                    AddUser(connection, id, name, privateMesssages);
                });
            


            // On User Disconnected
            connection.on("UserDisconnected",
                function (id, userName) {

                    $('#' + id).remove();

                    var ctrId = 'private_' + id;
                    $('#' + ctrId).remove();


                    var disc = $('<div class="disconnect">"' + userName + '" logged off.</div>');

                    $(disc).hide();
                    $('#divusers').prepend(disc);
                    $(disc).fadeIn(200).delay(2000).fadeOut(200);

                });

            connection.on("MessageReceived",
                function (userName, message) {

                    AddMessage(userName, message);
                    
                });

            connection.on("SendPrivateMessage",
                function (windowId, fromUserName, message) {

                    var ctrId = 'private_' + windowId;


                    if ($('#' + ctrId).length == 0) {

                        createPrivateChatWindow(connection, windowId, ctrId, fromUserName);

                    }

                    $('#' + ctrId).find('#divMessage').append('<div class="message"><span class="userName">' +
                        fromUserName +
                        '</span>: ' +
                        message +
                        '</div>');

                    // set scrollbar
                    var height = $('#' + ctrId).find('#divMessage')[0].scrollHeight;
                    $('#' + ctrId).find('#divMessage').scrollTop(height);

                });

        }

        function OpenPrivateChatWindow(connection, id, userName, privateMessages) {

            var ctrId = 'private_' + id;

            if ($('#' + ctrId).length > 0) return;

            createPrivateChatWindow(connection, id, ctrId, userName);

            //Add Private Messages
            for (i = 0; i < privateMessages.length; i++) {

                $('#' + ctrId).find('#divMessage').append('<div class="message"><span class="userName">' +
                    privateMessages[i].userNameFrom +
                    '</span>: ' +
                    privateMessages[i].message +
                    '</div>');
            }

            // set scrollbar
            var height = $('#' + ctrId).find('#divMessage')[0].scrollHeight;
            $('#' + ctrId).find('#divMessage').scrollTop(height);

        }

        function createPrivateChatWindow(connection, userId, ctrId, userName) {

            var div = '<div id="' +
                ctrId +
                '" class="ui-widget-content draggable" rel="0">' +
                '<div class="header">' +
                '<div  style="float:right;">' +
                '<img id="imgDelete"  style="cursor:pointer;" src="/images/delete.png"/>' +
                '</div>' +
                '<span class="selText" rel="0">' +
                userName +
                '</span>' +
                '</div>' +
                '<div id="divMessage" class="messageArea">' +
                '</div>' +
                '<div class="buttonBar">' +
                '<input id="txtPrivateMessage" class="msgText" type="text"   />' +
                '<input id="btnSendMessage" class="submitButton button" type="button" value="Send"   />' +
                '</div>' +
                '</div>';

            var $div = $(div);

            // DELETE BUTTON IMAGE
            $div.find('#imgDelete').click(function () {
                $('#' + ctrId).remove();
            });

            // Send Button event
            $div.find("#btnSendMessage").click(function () {

                $textBox = $div.find("#txtPrivateMessage");
                var msg = $textBox.val();
                if (msg.length > 0) {

                    connection.send("SendPrivateMessage", userId, msg);
                    $textBox.val('');
                }
            });

            // Text Box event
            $div.find("#txtPrivateMessage").keypress(function (e) {
                if (e.which === 13) {
                    $div.find("#btnSendMessage").click();
                }
            });

            

            AddDivToContainer($div);

        }

        function AddDivToContainer($div) {
            $('#divContainer').prepend($div);

            $div.draggable({
                handle: ".header",
                stop: function () {

                }
            });

            ////$div.resizable({
            ////    stop: function () {

            ////    }
            ////});

        }
