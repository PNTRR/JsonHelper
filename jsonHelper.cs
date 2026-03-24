using System.Text.Json;

internal class JsonHelper
{
    static private string ProjectDir = null;

    public void SetRootPath(string projectDir)
    {
        ProjectDir = projectDir;
    }

    public void CreateFile(string fileName)
    {
        using (File.Create($@"{ProjectDir}\{fileName}.json")) { }
    }

    public void CreateFile(string filePath, string fileName)
    {
        using (File.Create($@"{filePath}\{fileName}.json")) { }
    }

    public void CreateFile(string[] fileName)
    {
        for (int i = 0; i < fileName.Length; i++)
        {
            CreateFile(fileName[i]);
        }
    }

    public void CreateFile(string filePath, string[] fileName)
    {
        for (int i = 0;i < fileName.Length; i++)
        {
            CreateFile(filePath, fileName[i]);
        }
    }

    public void DeleteFile(string fileName)
    {
        File.Delete($@"{ProjectDir}\{fileName}.json");
    }

    public void DeleteFile(string filePath, string fileName)
    {
        File.Delete($@"{filePath}\{fileName}.json");
    }

    public void DeleteFile(string[] fileName)
    {
        for (int i = 0; i < fileName.Length; i++)
        {
            DeleteFile(fileName[i]);
        }
    }

    public void DeleteFile(string filePath, string[] fileName)
    {
        for (int i = 0; i < fileName.Length; i++)
        {
            DeleteFile(filePath, fileName[i]);
        }
    }

    public void SaveFile(string fileName, object data)
    {
        string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($@"{ProjectDir}\{fileName}.json", jsonString);
    }

    public void SaveFile(string filePath, string fileName, object data)
    {
        string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($@"{filePath}\{fileName}.json", jsonString);
    }

    public void SaveFile(string[] fileName, object[] data)
    {
        for (int i = 0; i < fileName.Length; i++)
        {
            SaveFile(fileName[i], data[i]);
        }
    }

    public void SaveFile(string filePath, string[] fileName, object[] data)
    {
        for (int i = 0; i < fileName.Length; i++)
        {
            SaveFile(filePath, fileName[i], data[i]);
        }
    }

    public T LoadFile<T>(out T newVariable, string fileName)
    {
            string jsonString = File.ReadAllText($@"{ProjectDir}\{fileName}.json");
            newVariable = JsonSerializer.Deserialize<T>(jsonString);
            return newVariable;
    }

    public T LoadFile<T>(out T newVariable, string filePath, string fileName)
    {
        string jsonString = File.ReadAllText($@"{filePath}\{fileName}.json");
        newVariable = JsonSerializer.Deserialize<T>(jsonString);
        return newVariable;
    }
}
