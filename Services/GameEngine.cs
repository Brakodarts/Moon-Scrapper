using System;
using MoonScrapper.Models;

namespace MoonScrapper.Services
{
    public static class GameEngine
    {
        public static void ProcessTick()
        {
            // Every 5 seconds, you gain some resources automatically
            if (DateTime.Now.Second % 5 == 0)
            {
                Oxigen.Amount += Oxigen.ProductionRate - Oxigen.DrainRate;
                Fuel.Amount += Fuel.ProductionRate - Fuel.DrainRate;
                Iron.Amount += Iron.ProductionRate - Iron.DrainRate;
                Crew.Amount += Crew.ProductionRate - Crew.DrainRate;
                Food.Amount += Food.ProductionRate - Food.DrainRate;
                Power.Amount += Power.ProductionRate - Power.DrainRate;
            }
        }
    }
}