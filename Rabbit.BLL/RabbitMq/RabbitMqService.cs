using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Rabbit.BLL.RabbitMq
{
    public class RabbitMqService
    {
        private readonly string _hostname = "localhost",
        _userName="mucahit",
        _password="0000";

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = _hostname,
                VirtualHost = "/",
                UserName = _userName,
                Password = _password,
                Uri = new Uri($"amqp://{_userName}:{_password}@{_hostname}")
            };
            return connectionFactory.CreateConnection();

        }
    }
}
