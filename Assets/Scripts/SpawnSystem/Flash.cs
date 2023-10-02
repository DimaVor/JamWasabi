using System.Collections.Generic;

public class Flash
{
    private int badFilesNum;
    private List<string> files;

    public Flash(int badFilesNum, List<string> files)
    {
        this.badFilesNum = badFilesNum;
        this.files = files;
    }

    public List<string> GetFiles() => files;
    public int GetNumOfBadFiles() => badFilesNum;
}
