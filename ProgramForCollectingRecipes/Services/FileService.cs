namespace ProgramForCollectingRecipes.Services;

public class FileService
{
    public bool Exists(string filename)
    {
        return File.Exists(filename);
    }

    public Stream Read(string filename)
    {
        return new FileStream(filename, FileMode.Open);
    }

    public void Write(string filename, Stream stream)
    {
        using var sw = new StreamWriter(filename);
        stream.CopyTo(sw.BaseStream);
    }
}
