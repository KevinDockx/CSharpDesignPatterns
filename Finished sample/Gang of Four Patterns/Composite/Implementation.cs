namespace Composite;

/// <summary>
/// Component
/// </summary>
public abstract class FileSystemItem(string name)
{
    public string Name { get; set; } = name;

    public abstract long GetSize();
}

/// <summary>
/// Leaf
/// </summary>
public class File(string name, long size) : FileSystemItem(name)
{
    private readonly long _size = size;

    public override long GetSize()
    {
        return _size;
    }
}

/// <summary>
/// Composite
/// </summary>
public class Directory(string name, long size) : FileSystemItem(name)
{
    private readonly List<FileSystemItem> _fileSystemItems = [];

    private readonly long _size = size;

    public void Add(FileSystemItem itemToAdd)
    {
        _fileSystemItems.Add(itemToAdd);
    }

    public void Remove(FileSystemItem itemToRemove)
    {
        _fileSystemItems.Remove(itemToRemove);
    }

    public override long GetSize()
    {
        var treeSize = _size;
        foreach (var fileSystemItem in _fileSystemItems)
        {
            treeSize += fileSystemItem.GetSize();
        }
        return treeSize;
    }
}
