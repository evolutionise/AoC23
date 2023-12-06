using System.Text.RegularExpressions;
using System.Xml;
using AoC23.File;

namespace AoC23;

public class Day2
{
    private static List<int> ValidGames = new List<int>();
    public void Execute()
    {
        var games = ReadGames();

        var validStones = new List<Stones>()
        {
            new Stones(12, Colour.Red),
            new Stones(13, Colour.Green),
            new Stones(14, Colour.Blue)
        };
        var validBag = new Draw(validStones);
        foreach (var game in games)
        {
            AddToGamesListIfValid(validBag, game);
        }
        Console.WriteLine("Day 2!");
        Console.WriteLine("Total sum is:");
        Console.WriteLine(ValidGames.Sum());
    }

    private static void AddToGamesListIfValid(Draw validBag, Game game)
    {
        foreach (var draw in game.Draws)
        {
            foreach (var validStone in validBag.Stones)
            {
                var stone = draw.Stones.FirstOrDefault(x => x.Colour == validStone.Colour);
                if (stone is null) continue;

                if (stone.Count > validStone.Count) return;
            }
        }
        ValidGames.Add(game.Id);
    }

    private IEnumerable<Game> ReadGames()
    {
        var data = FileFetcher.GetFileData(nameof(Day2)).ToList();
        var games = new List<Game>();
        for (int i = 0; i < data.Count; i++)
        {
            var split = data[i].Split(':');
            var drawData = split[1].Split(';');

            var draws = new List<Draw>();
            foreach (var d in drawData)
            {
                var output = new List<Stones>();
                var stones = d.Split(',');
                foreach (var setStone in stones)
                {
                    var digits = int.Parse(Regex.Match(setStone, @"\d+").Value);
                    switch(setStone)
                    {
                        case var blue when setStone.ToLowerInvariant().Contains("blue"):
                            output.Add( new Stones(digits, Colour.Blue));
                            break;
                        case var red when setStone.ToLowerInvariant().Contains("red"):
                            output.Add(new Stones(digits, Colour.Red));
                            break;
                        case var green when setStone.ToLowerInvariant().Contains("green"):
                            output.Add(new Stones(digits, Colour.Green));
                            break;
                    }
                }
                draws.Add(new Draw(output));
            }
            games.Add(new Game(i + 1, draws));
        }

        return games;
    }
}

public record Game(int Id, List<Draw> Draws);

public record Draw(List<Stones> Stones);

public record Stones(int Count, Colour Colour);

public enum Colour
{
    Blue,
    Green,
    Red,
}