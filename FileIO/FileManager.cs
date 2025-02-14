namespace w4_assignment_ksteph.FileIO;

using w4_assignment_ksteph.FileIO.Csv;
using w4_assignment_ksteph.FileIO.Json;
using w4_assignment_ksteph.Characters;
using w4_assignment_ksteph.Config;
using w4_assignment_ksteph.DataTypes;

public class FileManager
{

    private FileType _fileType = Config.DEFAULT_FILE_TYPE;
    public ICharacterIO GetFileType()
    {
        switch (_fileType)
        {
            case FileType.Csv:
                return new CsvFileHandler();
                break;
            case FileType.Json:
                return new JsonFileHandler();
                break;
            default:
                throw new NullReferenceException("Error: File type not found in FileManager.GetFileType()");
        }
    }
    // FileManager contains redirects to functions that assist with Csv functions. 
    public List<Character> ImportCharacters() => GetFileType().ReadCharacters();
    public void ExportCharacters(List<Character> characters) => GetFileType().WriteCharacters(characters);
}
