using System;
using System.Text.RegularExpressions;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using ParsePerSecond;
using ImGuiNET;

namespace ParsePerSecond.Triggers
{
	public class ChatTrigger : TriggerBase
	{
		public override void Attach()
		{
			base.Attach();
			Plugin.ChatGui.ChatMessage += this.OnChatMessage;
		}

		public override void Detach()
		{
			base.Detach();
			Plugin.ChatGui.ChatMessage -= this.OnChatMessage;
		}

		private void OnChatMessage(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
		{
			if (this.Pattern == null)
				return;

			this.OnChatMessage(sender.TextValue, message.TextValue);
		}

		public void OnChatMessage(string sender, string message)
		{
			bool isSystem = string.IsNullOrEmpty(sender);

			// Add the sender back into the message before regex.
			if (!isSystem)
				message = sender + ": " + message;

			PluginLog.Information($"Triggered: {this.Name} with chat message: \"{message}\"");
		}
	}
}