using System;
using MoonScrapper.Data;
using MoonScrapper.Models;
using Spectre.Console;

namespace MoonScrapper.UI
{
    public static class GameUI
    {
        public static string DrawBar(int current, int max, int length = 10)
        {
            current = Math.Clamp(current, 0, max);
            int filled = (int)Math.Round((double)current / max * length);
            int empty = length - filled;
            string color = "";

            if (current < max * 0.25)
            {
                color = "red";
            }
            else if (current < max * 0.6)
            {
                color = "yellow";
            }
            else
            {
                color = "green";
            }

            return $"[{color}]{new string('█', filled)}[{color}]{new string('░', empty)}[/]";
        }

        public static void DrawHeader()
        {
            var header = new Rule("[gray] MOON SCRAPPER V1.0 [/]");
            header.Justification = Justify.Center;
            AnsiConsole.Write(header);
            AnsiConsole.WriteLine();
        }

        public static void DrawResourceBar()
        {
            string resourceBar = $"🍎 Food: {DrawBar(Food.Amount, Food.Storage)}[/]  |  💨 Oxigen: {DrawBar(Oxigen.Amount, Oxigen.Storage)}[/]  |  🔥 Fuel: []{Fuel.Amount}[/]  |  📦 Steel: [green]{Steel.Amount}[/]  |  👥 Crew: [green]{Crew.Amount}[/]  |  📡 Power: [green]{Power.Amount}[/]";
            AnsiConsole.MarkupLine(resourceBar);
            AnsiConsole.WriteLine();
        }

        public static void DrawBuildingsTable(bool showBuildings)
        {
            AnsiConsole.MarkupLine("[gray]Press [[B]] to toggle Buildings Menu  |  Press [[S]] to Save and Exit[/]");

            if (showBuildings)
            {
                var buildingTable = new Table();
                buildingTable.Border(TableBorder.Rounded);
                buildingTable.AddColumn("[blue]Buildings[/]");
                buildingTable.AddColumn("[blue]Current Level[/]");
                buildingTable.AddColumn("[blue]Cost[/]");

                buildingTable.AddRow("🏠 Habitation Module", $"[yellow]{HabitationModule.Level}[/]");
                buildingTable.AddRow("🚀 Docking Station", $"[yellow]{DockingStation.Level}[/]");
                buildingTable.AddRow("🏭 Mines", $"[yellow]{Mines.Level}[/]");
                buildingTable.AddRow("💧 Ice Extractor", $"[yellow]{IceExtractor.Level}[/]");
                buildingTable.AddRow("📦 Storage Unit", $"[yellow]{StorageUnit.Level}[/]");
                buildingTable.AddRow("⚙️ Refinery", $"[yellow]{SteelSmelter.Level}[/]");
                buildingTable.AddRow("🌳 Plantation", $"[yellow]{Plantation.Level}[/]");
                buildingTable.AddRow("🧪 Oxygen Generator", $"[yellow]{OxygenGenerator.Level}[/]");
                buildingTable.AddRow("🛡️ Shield Generator", $"[yellow]{ShieldGenerator.Level}[/]");
                buildingTable.AddRow("🛰️ Satellite Array", $"[yellow]{SatelliteArray.Level}[/]");
                buildingTable.AddRow("⚡ Solar Array", $"[yellow]{SolarArray.Level}[/]");
                buildingTable.AddRow("🚀 Rocket", $"[yellow]{Rocket.Level}[/]");

                AnsiConsole.Write(buildingTable);
            }
        }
    }
}