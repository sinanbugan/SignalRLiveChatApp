using Microsoft.AspNetCore.SignalR;
using SignalRLiveChatApp.DAL;
using SignalRLiveChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveChatApp.Hubs
{
    public class ChatHub : Hub
    {
        //private readonly ILogManager logmanager;
        //public ChatHub(ILogManager _logmanager)
        //{
        //    logmanager = _logmanager;
        //}
        public async Task SendMessage(string user, string message)
        {
            //ChatLog chatLog = new ChatLog();
            //chatLog.Id = Guid.NewGuid();
            //chatLog.UserName = user;
            //chatLog.Message = message;

            //logmanager.Create(chatLog);

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
