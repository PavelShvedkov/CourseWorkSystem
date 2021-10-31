namespace BLL.Interface.Servicies
{
    public interface IMessageSender
    {
        string Message { get; set; }

        void Send();
    }
}