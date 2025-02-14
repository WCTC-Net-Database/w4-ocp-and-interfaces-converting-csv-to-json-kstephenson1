
using w4_assignment_ksteph.DataHelper;
using w4_assignment_ksteph.Characters;
using w4_assignment_ksteph.UI;

namespace w4_assignment_ksteph;

class Program
{
    static void Main()
    {
        Initialization();
        //Test();
        Run();
        End();
    }

    public static void Initialization()
    {
        // The Initialization method runs a few things that need to be done before the main part of the program runs.

        UserInterface.BuildMenus(); // Builds the menus and prepares the user interface tables.
        CharacterManager.ImportCharacters(); //Imports the caracters from the csv file.
    }

    public static void Run()
    {
        while (true) // Will run until exit is selected
        {
            UserInterface.MainMenu.Show(); //Shows the main menu.

            int selection = Input.GetInt(1, 5, "Value must be between 1-5"); // Uses a helper file to get an int between 1-5 from the user

            if (selection == 5) break; // Exits the program if '5' is selected.
            UserInterface.MainMenu.Action(selection); // Runs the action of the selected main menu item.
        }
    }

    public static void End()
    {
        // Exports the character list back to csv formation and ends the program.

        CharacterManager.ExportCharacters(); //Outputs the characters into the csv file.
        UserInterface.ExitMenu.Show(true); //Shows the exit menu and leaves the program.
    }

    //public static void Test() // for testing purposes only.
    //{
       
    //}

}
