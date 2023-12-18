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
}