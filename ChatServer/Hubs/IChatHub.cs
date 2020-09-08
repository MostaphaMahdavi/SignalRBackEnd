using System.Threading.Tasks;

namespace ChatServer.Hubs
{
    public interface IChatHub
    {
        Task ReceiveMessage(string message);
    }
}