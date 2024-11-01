FileSystemWatcher watcher;
string SourceFolder = @"C:\Users\faz\Documents\00_Innotech training\Sessions\session 5\Test";
string GoogleDriveFolder = @"G:\My Drive\Test";

TimeSpan Interval = TimeSpan.FromSeconds(1);

watcher = new FileSystemWatcher(SourceFolder) {
    // Specifies the types of changes in the directory that you want to be notified about
   
    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName ,
    // If a file is modified   |  renaming or creating new files.  | renaming or creating new directories.
    Filter = "*.*", // all files (with any extension)
    EnableRaisingEvents = true

};

watcher.Changed += OnChanged;
watcher.Created += OnChanged;
watcher.Deleted += OnDeleted;
watcher.Renamed += OnRenamed;

Console.WriteLine("Monitoring folder. Press 'q' to quit.");
Timer timer = new Timer(SyncFolder, null, TimeSpan.Zero, Interval);

while (Console.Read() != 'q') ;

void OnChanged(object sender, FileSystemEventArgs e)
{
    Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

    if (!IsFileLocked(new FileInfo(e.FullPath)))
    {
        SyncFile(e.FullPath);
    }

}

void OnDeleted(object sender, FileSystemEventArgs e)
{

    Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
    DeleteFile(e.FullPath);
}

void OnRenamed(object sender, RenamedEventArgs e)
{
    Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
    if (!IsFileLocked(new FileInfo(e.FullPath)))
    {
        SyncFile(e.FullPath);
    }

    DeleteFile(e.OldFullPath);
}

void SyncFile(string sourceFilePath)
    {
        var fileName = Path.GetFileName(sourceFilePath);
        var destinationFilePath = Path.Combine(GoogleDriveFolder, fileName);

        try
        {
            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            File.Copy(sourceFilePath, destinationFilePath);
            Console.WriteLine($"File {fileName} synced to Google Drive.");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"IO Exception during file sync: {ioEx.Message}");
        }
        catch (UnauthorizedAccessException uaEx)
        {
            Console.WriteLine($"Access Exception during file sync: {uaEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected Exception during file sync: {ex.Message}");
        }
    }


void DeleteFile(string sourceFilePath)
{
    var fileName = Path.GetFileName(sourceFilePath);
    var destinationFilePath = Path.Combine(GoogleDriveFolder, fileName);

    try
    {
        if (File.Exists(destinationFilePath))
        {
            File.Delete(destinationFilePath);
            Console.WriteLine($"File {fileName} deleted from Google Drive.");
        }
    }
    catch (IOException ioEx)
    {
        Console.WriteLine($"IO Exception during file delete: {ioEx.Message}");
    }
    catch (UnauthorizedAccessException uaEx)
    {
        Console.WriteLine($"Access Exception during file delete: {uaEx.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected Exception during file delete: {ex.Message}");
    }
}


void SyncFolder(object state)
{
    Console.WriteLine("Syncing folder...");
    foreach (var file in Directory.GetFiles(SourceFolder))
    {
        if (!IsFileLocked(new FileInfo(file)))
        {
            SyncFile(file);
        }
    }
    Console.WriteLine("Folder sync complete.");
}


bool IsFileLocked(FileInfo file)
{
    try
    {
        using (FileStream stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
        {
            stream.Close();
        }
    }
    catch (IOException)
    {
        return true;
    }

    return false;

}


