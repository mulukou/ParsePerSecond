using System.Collections.Generic;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using ParsePerSecond.Utils;
namespace ParsePerSecond.Triggers
{
    public class ChatTrigger : TriggerBase
    {

        private FileManager fileManager;


        private HashSet<ushort> existingChatTypes = new HashSet<ushort>();


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
            this.fileManager.Dispose();
        }

        private void OnChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            this.OnChatMessage(sender.TextValue, message.TextValue, type);
        }

        public void OnChatMessage(string sender, string message, XivChatType type)
        {
            // bool isSystem = string.IsNullOrEmpty(sender);

            // if (!isSystem)
            //     message = sender + ": " + message;

            if (existingChatTypes.Contains((ushort)type))
            {
                return;
            }

            PluginLog.Information($"Chat Type: {type} | Chat Message: \"{message}\"");
            this.fileManager.Write($"Chat Type: {type} | Chat Message: \"{message}\"");
            existingChatTypes.Add((ushort)type);

        }
    }
}