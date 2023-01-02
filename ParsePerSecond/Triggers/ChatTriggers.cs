using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;

namespace ParsePerSecond.Triggers
{
	public class ChatTrigger : TriggerBase
	{
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
			if (type != (XivChatType)2729) {
				PluginLog.Information($"CHAT TYPE: \"{type}\"");
			}
			
			this.OnChatMessage(sender.TextValue, message.TextValue, type);
		}

		public void OnChatMessage(string sender, string message, XivChatType type)
		{
			bool isSystem = string.IsNullOrEmpty(sender);

			// Add the sender back into the message before regex.
			if (!isSystem)
				message = sender + ": " + message;
			
			// 2729 -> damage dealt
			// 2222 2091 2224
			if (type == (XivChatType)2729 || type == (XivChatType)2222 || type == (XivChatType)2091 || type == (XivChatType)2224) {
				PluginLog.Information($"Triggered: {this.Name} with chat message: \"{message}\"");
			}
		}
	}
}