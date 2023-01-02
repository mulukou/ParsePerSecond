using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using ParsePerSecond.Utils;
namespace ParsePerSecond.Triggers
{
    public class ChatTrigger : TriggerBase
    {

        private FileManager fileManager;

        public ChatTrigger(string filePath)
        {
            this.fileManager = new FileManager(filePath);
        }

        public override void Attach()
        {
            base.Attach();
            Plugin.ChatGui.ChatMessage += this.OnChatMessage;
            PluginLog.Information("ChatTrigger Attached");
        }

        public override void Detach()
        {
            base.Detach();
            Plugin.ChatGui.ChatMessage -= this.OnChatMessage;
        }

        private void OnChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            this.OnChatMessage(sender.TextValue, message.TextValue, type);
        }

        public void OnChatMessage(string sender, string message, XivChatType type)
        {
            bool isSystem = string.IsNullOrEmpty(sender);

            if (!isSystem)
                message = sender + ": " + message;

            PluginLog.Information($"Chat Type: {type} | Chat Message: \"{message}\"");

        }
    }
}