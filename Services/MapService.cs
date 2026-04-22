using MoonScrapper.Models;

namespace MoonScrapper.Services;

public class MapService
{
    public static Random _random = new Random();
    public Tile[,] grid;
    public readonly int width = 21;
    public readonly int height = 21;

    public int CursorX { get; set; } = 4;
    public int CursorY { get; set; } = 4;
    public MapService()
    {
        GenerateMap();
    }

    public Tile GetTile(int x, int y)
    {
        return grid[x, y];
    }

    public void GenerateMap()
    {
        grid = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = new Tile { X = x, Y = y, Terrain = GetTerrain(x, y), Resource = GetResource(x, y), IsOccupied = false, Building = BuildingType.Empty };
            }
        }
    }

    public TerrainType GetTerrain(int x, int y)
    {
        if (4 < x && x < 7 && 4 < y && y < 7)
        {
            return TerrainType.Flat;
        }
        int terrain = _random.Next(0, 3);
        return (TerrainType)terrain;
    }

    public ResourceType GetResource(int x, int y)
    {
        if (4 < x && x < 7 && 4 < y && y < 7)
        {
            return ResourceType.Regolith;
        }

        int resource = _random.Next(0, 5);
        return (ResourceType)resource;
    }

    public void MoveCursor(int x, int y)
    {
        CursorX += x;
        CursorY += y;

        if (CursorX < 0) CursorX = 0;
        if (CursorX >= width) CursorX = width - 1;
        if (CursorY < 0) CursorY = 0;
        if (CursorY >= height) CursorY = height - 1;
    }

}
