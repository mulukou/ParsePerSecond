using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.Gui;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using ParsePerSecond.Windows;
using Dalamud.Game.Text;
using ParsePerSecond.Triggers;
using System;

namespace ParsePerSecond
{
    public sealed class Plugin : IDalamudPlugin
    {
        public string Name => "Parse Per Second";
        private const string MainCommandName = "/pps";
        private const string ConfigurationCommandName = "/ppsconfig";

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        public Configuration Configuration { get; init; }

        [PluginService] public static ChatGui ChatGui { get; private set; } = null!;
        public WindowSystem WindowSystem = new("ParsePerSecond");

        private ChatTrigger chatTrigger;

        public Plugin(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] CommandManager commandManager,
            [RequiredVersion("1.0")] ChatGui chatGui)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;
            ChatGui = chatGui;

            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string now = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            this.chatTrigger = new ChatTrigger(homePath + "/Network_26701_" + now + ".log");
            chatTrigger.Attach();

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            WindowSystem.AddWindow(new ConfigWindow(this));
            WindowSystem.AddWindow(new MainWindow(this));

            this.CommandManager.AddHandler(MainCommandName, new CommandInfo(OnMainCommand)
            {
                HelpMessage = "Opens Parse Per Second."
            });
            this.CommandManager.AddHandler(ConfigurationCommandName, new CommandInfo(OnConfigCommand)
            {
                HelpMessage = "Opens Parse Per Second configuration window."
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
        }

        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();
            this.CommandManager.RemoveHandler(MainCommandName);
            this.chatTrigger.Detach();
        }

        private void OnMainCommand(string command, string args)
        {
            // in response to the slash command, just display our main ui
            WindowSystem.GetWindow("Parse Per Second").IsOpen = true;
        }

        private void OnConfigCommand(string command, string args)
        {
            // in response to the slash command, just display our main ui
            WindowSystem.GetWindow("Parse Per Second Configuration").IsOpen = true;
        }

        private void DrawUI()
        {
            this.WindowSystem.Draw();
        }

        public void DrawConfigUI()
        {
            WindowSystem.GetWindow("Parse Per Second Configuration").IsOpen = true;
        }
    }
}
