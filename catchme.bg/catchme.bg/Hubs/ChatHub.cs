using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg
{
    [Authorize]
    public class ChatHub : Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "joined");
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "left");
        //}

        //public async Task Send(string message)
        //{
        //    await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        //}

        private CatchmeContext _context { get; set; }

        public ChatHub(CatchmeContext context) 
        {
            _context = context;
        }

        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        #endregion

        #region Methods

        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;
            
            var id = Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail {ConnectionId = id, UserName = userName});

                CurrentMessage.Clear();

                foreach (var _user in ConnectedUsers.Distinct())
                {
                    CurrentMessage.AddRange(GetMessageDetailsForUser(_user.UserName).Result);
                }
                
                // send to caller
                await Clients.Caller.SendAsync("OnConnected", id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                await Clients.AllExcept(id).SendAsync("NewUserConnected", id, userName);
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

        public async Task SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                await Clients.Client(toUserId).SendAsync("SendPrivateMessage", fromUserId, fromUser.UserName, message);

                // send to caller user
                await Clients.Caller.SendAsync("SendPrivateMessage", toUserId, fromUser.UserName, message);
            }

        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                await Clients.All.SendAsync("UserDisconnected", id, item.UserName);

            }
        }


        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string message)
        {
            var privateMessage = new MessageDetail {UserName = userName, Message = message};
            CurrentMessage.Add(privateMessage);
            _context.MessageDetails.Add(privateMessage);
            _context.SaveChanges();

            if (CurrentMessage.Count > 100)
            {
                CurrentMessage.RemoveAt(0);
                _context.MessageDetails.Remove(CurrentMessage[0]);
                _context.SaveChanges();
            }

            
        }

        #endregion

        public async Task<List<MessageDetail>> GetMessageDetailsForUser(string userName)
        {
            return await _context.MessageDetails.Where(u=>u.UserName==userName).ToListAsync();
        }
    }
}
