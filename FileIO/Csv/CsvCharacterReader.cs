namespace w4_assignment_ksteph.FileIO.Csv;

using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using w4_assignment_ksteph.Characters;

public static class CsvCharacterReader
{
    public static List<Character> Import(string path)
    {
        // CsvCharacterReader is used to import the characters from a text file.

        using StreamReader reader = new(path);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        IEnumerable<Character> characters = csv.GetRecords<Character>();

        return characters.ToList();
    }
}
