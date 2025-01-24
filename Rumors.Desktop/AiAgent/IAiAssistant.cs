
namespace Rumors.Desktop.AiAgent
{
    public interface IAiAssistant
    {
        Task<string> Chat(string input);
        Task DestroyAgent();
    }
}