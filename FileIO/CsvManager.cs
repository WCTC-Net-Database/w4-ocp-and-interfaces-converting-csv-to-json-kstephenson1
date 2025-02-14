namespace w3_assignment_ksteph.FileIO;

using w3_assignment_ksteph.FileIO.Csv;
using w4_assignment_ksteph.Characters;

public static class CsvManager
{
    // CsvManager contains redirects to functions that assist with Csv functions. 
    public static List<Character> ImportCharacters(string path) => CsvCharacterReader.Import(path);
    public static void ExportCharacters(List<Character> characters, string path) => CsvCharacterWriter.Export(characters, path);
}
