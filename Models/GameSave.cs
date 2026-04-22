using SQLite;

namespace MoonScrapper.Models;

[Table("GameSaves")]
public class GameSave
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Fuel { get; set; }
    public int Oxigen { get; set; }

    public DateTime SaveTime { get; set; }

}
