using AoC23.File;

namespace AoC23;

public class Day1
{
    public void Execute()
    {
        var data = FileFetcher.GetFileData(nameof(Day1));
        var sum = 0;
        foreach (var line in data)
        {
            var value = GetValueFromLine(line);

            sum += value;
        }
        Console.WriteLine("Total sum is:");
        Console.WriteLine(sum);
    }

    private int GetValueFromLine(string line)
    {
        var allNumbers = line.Where(char.IsDigit)
            .ToList();

        var numbers = new List<char>()
        {
            allNumbers[0],
            allNumbers[^1]
        }.ToArray();

        return int.Parse(new string(numbers));
    }
}