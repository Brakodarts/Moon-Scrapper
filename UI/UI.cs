using System;
using MoonScrapper.Data;
using MoonScrapper.Models;
using MoonScrapper.Services;
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

        public static Rule GetHeader()
        {
            var header = new Rule("[gray] MOON SCRAPPER V1.0 [/]");
            header.Justification = Justify.Center;
            return header;
        }

        public static Markup GetResourceBar()
        {
            string resourceBar = $"🍎 Food: {DrawBar(Food.Amount, Food.Storage)}[/]  |  💨 Oxigen: {DrawBar(Oxigen.Amount, Oxigen.Storage)}[/]  |  🔥 Fuel: [green]{Fuel.Amount}[/]  |  📦 Iron: [green]{Iron.Amount}[/]  |  👥 Crew: [green]{Crew.Amount}[/]  |  📡 Power: [green]{Power.Amount}[/]";
            return new Markup(resourceBar);
        }

        public static Table GetBuildingsTable()
        {
            var buildingTable = new Table();
            buildingTable.Border(TableBorder.Rounded);
            buildingTable.AddColumn("[blue]Buildings[/]");
            buildingTable.AddColumn("[blue]Qty[/]");
            buildingTable.AddColumn("[blue]Cost[/]");

            buildingTable.AddRow("📦 Storage Unit", $"[yellow]{StorageUnit.Level}[/]");
            buildingTable.AddRow("🏠 Habitation Module", $"[yellow]{HabitationModule.Level}[/]");
            buildingTable.AddRow("🚀 Docking Station", $"[yellow]{DockingStation.Level}[/]");
            buildingTable.AddRow("🏭 Mineral Extractor", $"[yellow]{MineralExtractor.Level}[/]");
            buildingTable.AddRow("💧 Ice Extractor", $"[yellow]{IceExtractor.Level}[/]");
            buildingTable.AddRow("⚙️ Refinery", $"[yellow]{Refinery.Level}[/]");
            buildingTable.AddRow("🌳 Plantation", $"[yellow]{Plantation.Level}[/]");
            buildingTable.AddRow("🧪 Oxygen Generator", $"[yellow]{OxygenGenerator.Level}[/]");
            buildingTable.AddRow("🚀 Rocket", $"[yellow]{Rocket.Level}[/]");

            return buildingTable;
        }

        public static Table GetMap(MapService mapService)
        {
            var mapTable = new Table();
            mapTable.Border(TableBorder.Rounded);
            mapTable.HideHeaders();
            int width = mapService.width;
            int height = mapService.height;

            for (int x = 0; x < width; x++)
            {
                // Fixed width of 3 characters per column
                mapTable.AddColumn(new TableColumn($"[blue]{x}[/]").Centered().Width(3));
            }

            for (int y = 0; y < height; y++)
            {
                var row = new List<string>();
                for (int x = 0; x < width; x++)
                {
                    Tile tile = mapService.GetTile(x, y);
                    string display = "☐";
                    if (x == mapService.CursorX && y == mapService.CursorY)
                    {
                        display = "🚀";
                    }

                    row.Add(display);
                }
                mapTable.AddRow(row.ToArray());
            }
            return mapTable;
        }

        public static Panel GetTileInfo(Tile tile)
        {
            var content = new Markup(
            $"[bold]LOCATION:[/] ({tile.X}, {tile.Y})\n" +
            $"[bold]TERRAIN:[/] {tile.Terrain}\n" +
            $"[bold]RESOURCE:[/] {tile.Resource}\n" +
            $"[bold]BUILDING:[/] {tile.Building}\n"
            );
            return new Panel(content)
                                    .Header("LOCATION INFORMATION")
                                    .BorderColor(Color.Cyan1);
        }
    }
}