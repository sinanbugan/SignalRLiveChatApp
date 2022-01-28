using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SignalRLiveChatApp.Models;
using SignalRLiveChatApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveChatApp.DAL
{
    public class LogManager:ILogManager
    {
        private readonly IMongoCollection<ChatLog> mongoCollection;
        public LogManager(string mongoDbConnetionString,string dbName,string connectionName)
        {
            var client = new MongoClient(mongoDbConnetionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<ChatLog>(connectionName);
        }


        public void Create(string user, string message,string ChanelID)
        {


            ChatLog chat = new ChatLog();
            chat.Id = Guid.NewGuid();
            chat.UserName = user;
            chat.Message = message;
            chat.Chanel = ChanelID;


            mongoCollection.InsertOne(chat);

        }

        public List<ChatLog> GetAll()
        {
          


            return mongoCollection.Find(log=>true).ToList();
        }

        public string GetById(string chanel)
        {
            List<ChatLog> chatlog = new List<ChatLog>();
            var redisManager = new RedisCacheManager();
            var docId = new string(chanel);
            var redisLog = redisManager.Get<List<ChatLog>>(chanel);

            if (redisLog==null)
            {
                redisLog= mongoCollection.Find<ChatLog>(m => m.Chanel == docId).ToList();

               

                redisManager.Set(docId, redisLog, 60);
            }

            var getlog = JsonConvert.SerializeObject(redisLog);
            return getlog;
        }
    }
}
