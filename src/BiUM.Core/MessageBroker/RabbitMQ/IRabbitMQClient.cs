using System;
using System.Threading.Tasks;
using BiUM.Core.Models.MessageBroker.RabbitMQ;

namespace BiUM.Core.MessageBroker.RabbitMQ;
public interface IRabbitMQClient
{
    void SendMessage(Message message, string exchangeName = "", string queueName = "", bool persistent = false);
    Task<Message> ReceiveMessageAsync(string queueName = "");
    void Dispose();
}