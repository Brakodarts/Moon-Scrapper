namespace MoonScrapper.Models;

public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public TerrainType Terrain { get; set; }
    public BuildingType Building { get; set; }
    public bool IsOccupied { get; set; }
    public ResourceType Resource { get; set; }

}

public enum ResourceType
{
    Regolith,
    Ice,
    Iron,
    Helium3,
    Silicon
}

public enum TerrainType
{
    Flat,
    Crater,
    Mountain,
}

public enum BuildingType
{
    StorageUnit,
    HabitationModule,
    DockingStation,
    Mines,
    IceExtractor,
    Refinery,
    Plantation,
    OxygenGenerator,
    Rocket,
    Empty,
}