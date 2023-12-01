namespace AoC23.File;

public static class FileFetcher
{
    public static IEnumerable<string> GetFileData(string fileName)
    {
        // Todo - use path/URI construction for this?
        return System.IO.File.ReadLines(@"File\Data\" + fileName + ".txt");
    }
}