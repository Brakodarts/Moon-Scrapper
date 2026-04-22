using MoonScrapper.Services;

namespace MoonScrapper.Models
{

    public class Food
    {
        public static int Amount { get; set; } = 700;
        public static int ProductionRate { get; set; } = 0;
        public static int DrainRate { get; set; } = 3;
        public static int Storage { get; set; } = 1000;


    }

    public class Oxigen
    {
        public static int Amount { get; set; } = 700;
        public static int DrainRate { get; set; } = 5;
        public static int ProductionRate { get; set; } = 0;
        public static int Storage { get; set; } = 1000;

    }

    public class Fuel
    {
        public static int Amount { get; set; } = 1000;
        public static int ProductionRate { get; set; } = 0;
        public static int DrainRate { get; set; } = 0;


    }

    public class Steel
    {
        public static int Amount { get; set; } = 1000;
        public static int ProductionRate { get; set; } = 0;
        public static int DrainRate { get; set; } = 0;


    }

    public class Crew
    {
        public static int Amount { get; set; } = 5;
        public static int ProductionRate { get; set; } = 0;
        public static int DrainRate { get; set; } = 0;


    }



    public class Power
    {
        public static int Amount { get; set; } = 100;
        public static int ProductionRate { get; set; } = 0;
        public static int DrainRate { get; set; } = 0;


    }
}