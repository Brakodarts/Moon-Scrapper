using System;
using System.Collections.Generic;
using System.Threading;
using MoonScrapper.Data;
using MoonScrapper.Models;
using MoonScrapper.Services;
using MoonScrapper.UI;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace MoonScrapper;

public class Game
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        // Initialize the DataManager for SQLite operations
        var dataManager = new DataManager("moonscraper_save.db");
        var mapService = new MapService();

        //counter to control the ticks
        int tickCounter = 0;

        AnsiConsole.Live(new Markup("Initializing..."))
            .Start(ctx =>
            {
                while (true)
                {
                    // 1. UPDATE LOGIC
                    tickCounter++;
                    if (tickCounter >= 100)
                    {
                        GameEngine.ProcessTick();
                        tickCounter = 0;
                    }

                    // 2. RENDER UI
                    var header = GameUI.GetHeader();
                    var resourceBar = GameUI.GetResourceBar();
                    var tile = mapService.GetTile(mapService.CursorX, mapService.CursorY);
                    var infoPanel = GameUI.GetTileInfo(tile);
                    var mapTable = GameUI.GetMap(mapService);
                    var buildingsTable = GameUI.GetBuildingsTable();

                    // Create a list to hold all your UI pieces
                    var components = new List<IRenderable>
                    {
                        header,
                        resourceBar,
                        new Columns(buildingsTable, mapTable, infoPanel)
                    };

                    // Add control hints at the bottom
                    components.Add(new Markup("\n[gray]Press [[S]] to Save and Exit[/]"));

                    // Create the final layout container from the list
                    var root = new Rows(components);

                    // Update the live display
                    ctx.UpdateTarget(root);

                    // 3. HANDLE INPUT
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.UpArrow) mapService.MoveCursor(0, -1);
                        if (key == ConsoleKey.DownArrow) mapService.MoveCursor(0, 1);
                        if (key == ConsoleKey.LeftArrow) mapService.MoveCursor(-1, 0);
                        if (key == ConsoleKey.RightArrow) mapService.MoveCursor(1, 0);

                        if (key == ConsoleKey.S)
                        {
                            // Create a new save snapshot
                            var save = new GameSave
                            {
                                Fuel = Fuel.Amount,
                                Oxigen = Oxigen.Amount,
                                SaveTime = DateTime.Now
                            };

                            // Save to the database
                            dataManager.SaveGame(save);

                            // Exit the live display and main loop
                            break;
                        }
                    }

                    Thread.Sleep(10);
                }
            });

        // Final exit message after Live display ends
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("\n[bold green]💾 Game Saved Successfully![/]\n[gray]Goodbye![/]\n");
    }
}
