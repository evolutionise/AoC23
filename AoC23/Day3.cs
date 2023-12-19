using AoC23.File;

namespace AoC23;

public class Day3(string textFile) : IDay(textFile)
{
    public override void Execute()
    {
        var data = FileFetcher.GetFileData(textFile).ToList();

        // Do I want to do this as a 2D array or write some special classes? I think I want the arrays.
        var grid = ConstructGrid(data);

        var partNumbers = GetPartNumbers(grid);
        
        Console.WriteLine("Day 3 - Part 1");
        Console.WriteLine("Total sum is:");
        Console.WriteLine(partNumbers.Sum());
    }

    public List<int> GetPartNumbers(char[,] grid)
    {
        var partNumbers = new List<int>();

        var length = grid.GetLength(0);
        var width = grid.GetLength(1);

        // Are we going down instead of across? Whoops ...
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var c = grid[i, j];
                var d = c;


                // is it a digit?
                if (char.IsDigit(c))
                {
                    var digits = new List<char>();
                    var index = i;

                    // figure out how many digits
                    while (char.IsDigit(d) && index <= width - 1)
                    {
                        digits.Add(d);
                        // the increment is causing issues when it's right on the end
                        d = grid[i, Math.Min(++index, width-1)];
                    }
                    
                    // Valid part number == adjacent to a symbol incl diagonally
                    var isValidPartNumber = InspectNeighboursForSymbols(grid, digits, i, j);
                    
                    if (isValidPartNumber)
                    {
                        partNumbers.Add(GetValueFromIntChars(digits, i, j));
                        j += digits.Count;
                    }
                }

            }
        }

        return partNumbers;
    }

    private int GetValueFromIntChars(List<char> digits, int i, int index)
    {
        try
        {
            return int.Parse(new string(digits.ToArray()));
        }
        catch (Exception e)
        {
            Console.WriteLine(digits);
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InspectNeighboursForSymbols(char[,] grid, List<char> digits, int i, int j)
    {
        var gridLength = grid.GetLength(0);
        var gridWidth = grid.GetLength(1);
        // Check line above
        // This is going to run unnecessarily over the first line twice but I think that's fine
        // I could just change the values but will look at that later

        // Does this account for start of row?
        // Should I just start at -1?
        var len = j == 0
            ? digits.Count + 1
            : digits.Count + 2;
        
        for (var k = Math.Max(j - 1, 0); k < j + len; k++)
        {
            var l = Math.Max(i - 1, 0);
            if (IsValidSymbol(grid[l, Math.Min(k, gridWidth - 1)]))
            {
                return true;
            }
        }
        
        // Check adjacent on same line
        var length = grid.GetLength(0);
        // Left
        if (IsValidSymbol(grid[Math.Max(i - 1, 0), j])) return true;
        // Right
        if (IsValidSymbol(grid[Math.Min(i + digits.Count, length - 1), j])) return true;
        
        // Check below
        if (i >= gridLength - 1)
        {
            return false;
        }

        for (var k = Math.Min(j - 1, gridWidth - 1); k < j + len; k++)
        {
            var l = Math.Max(i + 1, 0);
            var w = Math.Min(Math.Max(k, 0), gridWidth - 1);
            if (IsValidSymbol(grid[l, w]))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsValidSymbol(char c)
    {
        return !char.IsDigit(c) && c != '.';
    }

    private char[,] ConstructGrid(List<string> data)
    {
        var length = data.Count;
        var width = data[0].Length;
        var grid = new char[length, width];

        // I could do this at the file reading stage, but pfft. This way I can ignore new lines
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid[i, j] = data[i][j];
            }
        }

        return grid;
    }

}