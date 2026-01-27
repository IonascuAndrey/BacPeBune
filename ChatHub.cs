using Microsoft.AspNetCore.SignalR;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace BacPeBune.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatCompletionService _chatCompletionService;

        public ChatHub(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
        }

        public async Task SendMessage(string userMessage)
        {
            const string systemPrompt = "Ești un profesor de informatică pentru Bacalaureat. Răspunde EXCLUSIV în limba română. Fii concis și direct. Nu folosi 'Step 1' sau explicații lungi pentru calcule simple.";

            var chatHistory = new ChatHistory();
            chatHistory.AddSystemMessage(systemPrompt);
            chatHistory.AddUserMessage(userMessage);

            await foreach (var content in _chatCompletionService.GetStreamingChatMessageContentsAsync(chatHistory))
            {
                if (content.Content != null)
                {
                    await Clients.Caller.SendAsync("ReceiveMessageChunk", content.Content);
                }
            }
            await Clients.Caller.SendAsync("ReceiveMessageDone");
        }
    }
}