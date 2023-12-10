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
    }

    private List<int> GetPartNumbers(char[,] grid)
    {
        var partNumbers = new List<int>();

        var length = grid.GetLength(0);
        var width = grid.GetLength(1);

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                var c = grid[i, j];
                var d = c;

                var digits = new List<char>();
                var index = j;
                // is it a digit?
                if (char.IsDigit(c))
                {
                    // figure out how many digits
                    while (char.IsDigit(d) && index < length - 1)
                    {
                        digits.Add(d);

                        d = grid[i, ++index];
                    }
                    
                    // TODO - inspect array neighbours to find if it's a valid part number
                    // Valid part number == adjacent to a symbol incl diagonally
                    var isValidPartNumber = InspectNeighboursForSymbols(grid, digits, i, j);
                    
                    // TODO - can we skip the next digits if we've already checked? 
                    // Am I overcomplicating it by trying to look at all of the digits?
                    // Otherwise I'd have to look back to find the whole number, so I think I prefer this?

                    // TODO - if it's valid, turn chars into a number and add it to list of valid part numbers
                }

            }
        }

        return partNumbers;
    }

    public bool InspectNeighboursForSymbols(char[,] grid, List<char> digits, int i, int j)
    {
        // Check line above
        // This is going to run unnecessarily over the first line twice but I think that's fine
        // I could just change the values but will look at that later
        
        // TODO - the +2 doesn't account for 0 index, so need to re-think
        for (var k = Math.Max(j - 1, 0); k < digits.Count + 2; k++)
        {
            var l = Math.Max(i - 1, 0);
            if (IsValidSymbol(grid[l, k]))
            {
                return true;
            }
        }
        
        // Check adjacent on same line
        // TODO: okay this is where a custom class starts to sound better tbh
        var length = grid.GetLength(0);
        // Left
        if (IsValidSymbol(grid[Math.Max(i - 1, 0), j])) return true;
        // Right
        if (IsValidSymbol(grid[Math.Min(i + digits.Count, length - 1), j])) return true;

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