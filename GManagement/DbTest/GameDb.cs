using GManagement.Enum;
using GManagement.Models;

namespace GManagement.DbTest;

public class GameDb
{
    private static readonly List<Game> _games = new()
    {
        new Game
        {
            Id = 1, Name = "Save the company", Hero = true, Level = MissionLevel.Brutal,
            DeliverMissionTo = new DateTime(2024, 04, 14)
        },
        new Game
        {
            Id = 2, Name = "Ask for a Coffee Machine", Hero = false, Level = MissionLevel.Young,
            DeliverMissionTo = new DateTime(2024, 05, 1)
        },
        new Game
        {
            Id = 3, Name = "Send the job", Hero = true, Level = MissionLevel.Senior,
            DeliverMissionTo = new DateTime(2024, 3, 20)
        }
    };

    public static List<Game> Get()
    {
        return _games;
    }

    public static List<Game> Post(Game game)
    {
        _games.Add(game);
        return _games;
    }

    public static List<Game> Put(Game updateGame, int id)
    {
        var indexOldGame = _games.FindIndex(game => game.Id == id);

        if (indexOldGame != -1) _games.Insert(indexOldGame, updateGame);

        return _games;
    }

    public static List<Game> Delete(int id)
    {
        return _games.FindAll(game => game.Id != id);
    }
}