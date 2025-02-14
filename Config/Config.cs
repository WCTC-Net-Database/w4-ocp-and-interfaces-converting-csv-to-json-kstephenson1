namespace w4_assignment_ksteph.Config;

public static class Config
{
    // Added this config file to add changable aspects of the program.  Could (and probably should) be changed to a .config file at a later date.

    /* * * * * * * * * * * * * * * * *
     *       CHARACTER SETTINGS      *
     * * * * * * * * * * * * * * * * */

    // Sets the maximum level for characters. (Default: 20)
    public const int CHARACTER_LEVEL_MAX = 20;

    /* * * * * * * * * * * * * * * * *
     *         CSV SETTINGS          *
     * * * * * * * * * * * * * * * * */

    // If true, the program will add double quotes on all values when writing .csv files.(Default: true)
    public const bool CSV_CHARACTER_WRITER_QUOTES_ON_EXPORT = true;
}
