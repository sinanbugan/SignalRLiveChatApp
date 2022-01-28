using SignalRLiveChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveChatApp.DAL
{
   public interface ILogManager
    {

         void Create(string user,string message,string ChanelID);

        string GetById(string chanelId);

        List<ChatLog> GetAll();
    }
}
