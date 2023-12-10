namespace AoC23;

public abstract class IDay
{
    public IDay(string textFile)
    {
        TextFile = textFile;
    }

    private string TextFile { get; set; }

    public abstract void Execute();
}