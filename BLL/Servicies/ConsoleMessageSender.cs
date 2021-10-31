using System;
using BLL.Interface.Servicies;

namespace BLL.Servicies
{
    public class ConsoleMessageSender: IMessageSender
    {
        public ConsoleMessageSender(string message)
        {
            this.Message = message;
        }
        
        public string Message { get; set; }
        public void Send()
        {
            Console.WriteLine(Message);
        }
    }
}