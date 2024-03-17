using GManagement.Enum;

namespace GManagement.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Hero { get; set; }
    public DateTime DeliverMissionTo { get; set; }
    public MissionLevel Level { get; set; }
}