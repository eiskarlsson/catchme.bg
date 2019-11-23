using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg
{
    [Authorize]
    public class ChatHub : Hub
    {
        private CatchmeContext _context { get; set; }
        private catchmebgContext _bgContext { get; set; }

        public ChatHub(CatchmeContext context, catchmebgContext bgContext)
        {
            _context = context;
            _bgContext = bgContext;

            AllUsers = _bgContext.Users.Select(u => new UserDetail() { ConnectionId = "", UserName = u.UserName }).ToList();


        }

        #region Data Members

        // List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<UserDetail> AllUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();
        static List<PrivateMessageDetail> CurrentPrivateMessage = new List<PrivateMessageDetail>();

        #endregion

        #region Methods

        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;

            var id = Context.ConnectionId;




            if (AllUsers.Count(x => x.ConnectionId == id) == 0)
            {
                var user = AllUsers.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    user.ConnectionId = id;
                    AllUsers[AllUsers.FindIndex(ind => ind.UserName.Equals(userName))].ConnectionId = id;
                }

                CurrentMessage.Clear();

                CurrentPrivateMessage.Clear();

                foreach (var user_name in AllUsers.Select(u => u.UserName).Distinct())
                {
                    CurrentMessage.AddRange(GetMessageDetailsForUser(user_name).Result);

                    CurrentPrivateMessage.AddRange(GetPrivateMessageDetailsForUsers(Context.User.Identity.Name, user_name).Result);
                }

                // send to caller
                await Clients.Caller.SendAsync("OnConnected", id, userName, AllUsers, CurrentMessage, CurrentPrivateMessage);

                // send to all except caller client
                await Clients.AllExcept(id).SendAsync("NewUserConnected", id, userName, CurrentPrivateMessage);
            }
        }


        public async Task SendMessageToAll(string message)
        {
            var userName = Context.User.Identity.Name;
            // store last 100 messages in cache
            AddMessageinCache(userName, message);

            // Broad cast message
            await Clients.All.SendAsync("MessageReceived", userName, message);
        }

        public async Task SendPrivateMessage(string toUserId, string toUserName, string message)
        {

            string fromUserId = Context.ConnectionId;
            string fromUserName = Context.User.Identity.Name;

            var fromUser = new UserDetail() { UserName = fromUserName, ConnectionId = fromUserId };

            var toUser = new UserDetail() { UserName = toUserName, ConnectionId = toUserId };


            // send to 
            await Clients.Client(toUserId).SendAsync("SendPrivateMessage", fromUserId, fromUser.UserName, message);

            // send to caller user
            await Clients.Caller.SendAsync("SendPrivateMessage", toUserId, fromUser.UserName, message);

            AddPrivateMessageinCache(fromUser.UserName, toUser.UserName, message);


        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var item = AllUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                //ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                await Clients.All.SendAsync("UserDisconnected", id, item.UserName);

            }
        }


        #endregion

        #region public Messages

        private void AddMessageinCache(string userName, string message)
        {
            var publicMessage = new MessageDetail { UserName = userName, Message = message };
            CurrentMessage.Add(publicMessage);
            _context.MessageDetails.Add(publicMessage);
            _context.SaveChanges();

            if (CurrentMessage.Count > 100)
            {
                CurrentMessage.RemoveAt(0);
                _context.MessageDetails.Remove(CurrentMessage[0]);
                _context.SaveChanges();
            }


        }

        #endregion

        #region private Messages



        private void AddPrivateMessageinCache(string userFrom, string userTo, string message)
        {
            var privateMessage = new PrivateMessageDetail { UserNameFrom = userFrom, UserNameTo = userTo, Message = message };
            CurrentPrivateMessage.Add(privateMessage);
            _context.PrivateMessageDetails.Add(privateMessage);
            _context.SaveChanges();

            var singleUserPrivateMessages = CurrentPrivateMessage.Where(u => u.UserNameFrom == userFrom && u.UserNameTo == userTo).ToList();

            if (singleUserPrivateMessages.Count > 100)
            {
                CurrentPrivateMessage.Remove(singleUserPrivateMessages.First());
                _context.PrivateMessageDetails.Remove(singleUserPrivateMessages.First());
                _context.SaveChanges();
            }


        }

        #endregion

        public async Task<List<MessageDetail>> GetMessageDetailsForUser(string userName)
        {
            return await _context.MessageDetails.Where(u => u.UserName == userName).ToListAsync();
        }

        public async Task<List<PrivateMessageDetail>> GetPrivateMessageDetailsForUsers(string userFrom, string userTo)
        {
            return await _context.PrivateMessageDetails.Where(u => u.UserNameFrom == userFrom && u.UserNameTo == userTo).ToListAsync();
        }
    }
}
