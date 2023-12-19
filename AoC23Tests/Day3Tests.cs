using AoC23;

namespace AoC23Tests;

public class Day3Tests
{
    [Fact]
    public void LineAboveChecksFirstLineWhenIndex0()
    {
        var day3 = new Day3("test1");
        var grid = new char[1,3]
        {
            {'1', '2', '*'}
        };
        var chars = new List<char>()
        {
            '1', '2'
        };
        var isValid = day3.InspectNeighboursForSymbols(grid, chars, 0,0);
        
        Assert.True(isValid);
    }
    
    [Fact]
    public void WhenIndexIs00ChecksNextLine()
    {
        var day3 = new Day3("test1");
        var grid = new char[1,3]
        {
            {'1', '2', '*'}
        };
        var chars = new List<char>()
        {
            '1', '2'
        };
        var isValid = day3.InspectNeighboursForSymbols(grid, chars, 0,0);
        
        Assert.True(isValid);
    }
    
    [Fact]
    public void OnlyChecks3CharsWhenAtStartOfRow()
    {
        var day3 = new Day3("test1");
        var grid = new char[1,4]
        {
            {'1', '2', '.', '*'}
        };
        var chars = new List<char>()
        {
            '1', '2'
        };
        var isValid = day3.InspectNeighboursForSymbols(grid, chars, 0,0);
        
        Assert.False(isValid);
    }
    
    [Fact]
    public void ChecksNegativeDiagonalAbove()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,5]
        {
            {'*', '.', '.', '.', '.'},
            {'.', '1', '2', '.', '.'},
        };
        var chars = new List<char>
        {
            '1', '2'
        };
        var isValid = day3.InspectNeighboursForSymbols(grid, chars, 1,1);
        
        Assert.True(isValid);
    }
    
    [Fact]
    public void ChecksPositiveDiagonalAbove()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,5]
        {
            {'.', '.', '.', '*', '.'},
            {'.', '1', '2', '.', '.'},
        };
        var chars = new List<char>
        {
            '1', '2'
        };
        var isValid = day3.InspectNeighboursForSymbols(grid, chars, 1,1);
        
        Assert.True(isValid);
    }
    
    [Fact]
    public void LooksInCorrectDirection()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,5]
        {
            {'.', '.', '.', '*', '.'},
            {'.', '1', '2', '.', '.'},
        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 12 };
        
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void GetsMultipleValidPartNumbers()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,10]
        {
            {'.', '.', '.', '*', '.', '.', '*', '3', '.', '.'},
            {'.', '1', '2', '.', '.','.', '.', '.', '*', '.'},
        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 3, 12 };
        
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void IgnoresInvalidPartNumbers()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,10]
        {
            {'.', '.', '.', '.', '.', '.', '*', '3', '.', '.'},
            {'.', '1', '2', '.', '.','.', '.', '.', '*', '.'},
        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 3 };
        
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void GetSymbolsPositiveDiagonalBelow()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,10]
        {
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '1', '2', '.', '.','.', '.', '.', '*', '.'},
        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 3 };
        
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void GetSymbolsNegativeDiagonalBelow()
    {
        var day3 = new Day3("test1");
        var grid = new char[2,10]
        {
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '1', '2', '.', '.','.', '*', '.', '.', '.'},
        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 3 };
        
        Assert.Equal(expected, value);
    }
    
    [Fact]
    public void GetPartNumbersOnTheEnd()
    {
        var day3 = new Day3("test1");
        var grid = new char[10,10]
        {
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '1', '.', '.', '.','.', '*', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '3', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.', '2', '.'},

        };
        var value = day3.GetPartNumbers(grid);

        var expected = new List<int> { 3, 3 };
        
        Assert.Equal(expected, value);
    }
}