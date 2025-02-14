namespace w4_assignment_ksteph.FileIO.Json;

using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using w4_assignment_ksteph.Characters;
using w4_assignment_ksteph.Config;

public class JsonFileHandler : ICharacterIO
{
    private const string JSON_FILE_PATH = "Files/Input.json";
    // CsvFileHandler is used to convert bwtween characters and csv
    public List<Character> ReadCharacters()
    {
        throw new NotImplementedException();
    }

    // CsvCharacterWriter is used to export the characters to a text file.
    public void WriteCharacters(List<Character> characters)
    {
        throw new NotImplementedException();
    }
}
