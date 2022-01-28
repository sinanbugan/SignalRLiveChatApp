using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveChatApp.Models
{
    public class ChatLog
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Chanel { get; set; }
        public string Message { get; set; }
    }

    public class ChatLogDTO
    
    {
        public string UserName { get; set; }
        public string Message { get; set; }

    }
}
