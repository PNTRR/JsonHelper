using System.Text.Json;

internal class JsonHelper
{
    static private string ProjectDir = null;


    private bool ProjectDirNotSetError()
    {
        if (ProjectDir == null)
        {
            Console.WriteLine("Error: ProjectDir variable is not set");
            return false;
        }
        return true;
    }

    private bool InvalidProjectDirError(string projectDir)
    {
        if (!Directory.Exists(projectDir))
        {
            Console.WriteLine("Error: ProjectDir is specified as an empty path");
            return false;
        }
        if (string.IsNullOrEmpty(projectDir))
        {
            Console.WriteLine("Error: ProjectDir directory does not exist");
            return false;
        }
        return true;
    }

    private bool FileAccessError(string fileName)
    {
        if (System.IO.File.Exists(fileName))
        {
            Console.WriteLine("Error: cannot create or delete file — check if it exists");
            return false;
        }
        return true;
    }
    private bool FileAccessError(string[] fileName)
    {
        foreach (string file in fileName)
        {
            if (System.IO.File.Exists(file))
            {
                Console.WriteLine("Error: cannot create or delete file — check if it exists");
                return false;
            }
        }
        return true;
    }


    public void SetRootPath(string projectDir)
    {
        if (InvalidProjectDirError(projectDir)) return;

        ProjectDir = projectDir;
    }

    public void ResetRootPath()
    {
        ProjectDir = null;
    }

    public void CreateFile(string fileName)
    {
        if (ProjectDirNotSetError()) return;
        if (FileAccessError(fileName)) return;

        using (File.Create($@"{ProjectDir}\{fileName}.json")) { }
    }

    public void CreateFile(string filePath, string fileName)
    {
        if (FileAccessError(fileName)) return;
        if (InvalidProjectDirError(filePath)) return;

        using (File.Create($@"{filePath}\{fileName}.json")) { }
    }

    public void CreateFile(string[] fileName)
    {
        if (ProjectDirNotSetError()) return;
        if (FileAccessError(fileName)) return;

        for (int i = 0; i < fileName.Length; i++)
        {
            CreateFile(fileName[i]);
        }
    }

    public void CreateFile(string filePath, string[] fileName)
    {
        if (FileAccessError(fileName)) return;
        if (InvalidProjectDirError(filePath)) return;

        for (int i = 0; i < fileName.Length; i++)
        {
            CreateFile(filePath, fileName[i]);
        }
    }

    public void DeleteFile(string fileName)
    {
        if (ProjectDirNotSetError()) return;
        if (FileAccessError(fileName)) return;

        File.Delete($@"{ProjectDir}\{fileName}.json");
    }

    public void DeleteFile(string filePath, string fileName)
    {
        if (FileAccessError(fileName)) return;
        if (InvalidProjectDirError(filePath)) return;

        File.Delete($@"{filePath}\{fileName}.json");
    }

    public void DeleteFile(string[] fileName)
    {
        if (ProjectDirNotSetError()) return;
        if (FileAccessError(fileName)) return;

        for (int i = 0; i < fileName.Length; i++)
        {
            DeleteFile(fileName[i]);
        }
    }

    public void DeleteFile(string filePath, string[] fileName)
    {
        if (FileAccessError(fileName)) return;
        if (InvalidProjectDirError(filePath)) return;

        for (int i = 0; i < fileName.Length; i++)
        {
            DeleteFile(filePath, fileName[i]);
        }
    }

    public void SaveFile(string fileName, object data)
    {
        if (ProjectDirNotSetError()) return;

        string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($@"{ProjectDir}\{fileName}.json", jsonString);
    }

    public void SaveFile(string filePath, string fileName, object data)
    {
        if (InvalidProjectDirError(filePath)) return;

        string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($@"{filePath}\{fileName}.json", jsonString);
    }

    public void SaveFile(string[] fileName, object[] data)
    {
        if (ProjectDirNotSetError()) return;

        for (int i = 0; i < fileName.Length; i++)
        {
            SaveFile(fileName[i], data[i]);
        }
    }

    public void SaveFile(string filePath, string[] fileName, object[] data)
    {
        if (InvalidProjectDirError(filePath)) return;

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
