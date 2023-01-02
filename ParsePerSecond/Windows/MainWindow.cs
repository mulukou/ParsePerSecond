using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using ImGuiNET;
using ImGuiScene;

namespace ParsePerSecond.Windows;

public class MainWindow : Window, IDisposable
{
    private Plugin Plugin;
    internal ChatGui chatGui { get; private init; } = null!;

    public MainWindow(Plugin plugin) : base(
        "Parse Per Second", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.Plugin = plugin;
    }

    public void Dispose()
    {
    }

    public override void Draw()
    {
        ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }

        if (ImGui.Button("DPS")) {
        }
        ImGui.SameLine();
        if (ImGui.Button("Tank")) {
            
        }
        ImGui.SameLine();
        if (ImGui.Button("Heal")) {
            
        }
        ImGui.SameLine();
        if (ImGui.Button("24")) {
            
        }
    }
}
