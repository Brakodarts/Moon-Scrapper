using System;
using System.Threading;
using MoonScrapper.Data;
using MoonScrapper.Models;
using MoonScrapper.Services;
using MoonScrapper.UI;
using Spectre.Console;

namespace MoonScrapper
{
    public class Game
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            bool showBuildings = false;

            // Initialize the DataManager for SQLite operations
            var dataManager = new DataManager("moonscraper_save.db");

            while (true)
            {
                AnsiConsole.Clear();

                GameUI.DrawHeader();
                GameUI.DrawResourceBar();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.B)
                    {
                        showBuildings = !showBuildings;
                    }
                    else if (key == ConsoleKey.S)
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

                        // Clear screen and exit loop
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("\n[bold green]💾 Game Saved Successfully![/]\n[gray]Goodbye![/]\n");
                        break;
                    }
                }

                GameUI.DrawBuildingsTable(showBuildings);

                // 5. Leave the ticking run on the background
                GameEngine.ProcessTick();

                // 1 Sekunde warten
                Thread.Sleep(1000);
            }
        }
    }
}