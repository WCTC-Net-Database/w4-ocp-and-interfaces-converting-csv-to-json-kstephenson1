﻿namespace w4_assignment_ksteph.Characters;

using Spectre.Console;
using System.Collections;
using w4_assignment_ksteph.FileIO;
using w4_assignment_ksteph.Config;
using w4_assignment_ksteph.DataHelper;
using w4_assignment_ksteph.Inventories;
using w4_assignment_ksteph.UI;


// The CharacterHandler class contains methods that manipulate Characters data, including displaying, adding, and leveling up characters.

public static class CharacterManager
{
    public static List<Character> Characters { get; set; } = new(); // A list of characters objects for reference

    public static void ImportCharacters() //Imports the characters from the csv file and stores them.
    {
        Characters = new FileManager().ImportCharacters();
    }

    public static void ExportCharacters() //Exports the stored characters into the specified csv file
    {
        new FileManager().ExportCharacters(Characters);
    }

    public static void DisplayAllCharacters() //Displays each character's information.
    {
        Console.Clear();

        foreach (Character character in CharacterManager.Characters)
        {
            character.DisplayCharacterInfo();
        }
    }

    public static void NewCharacter() // Creates a new character.  Asks for name, class, level, hitpoints, and items.
    {
        string name = Input.GetString("Enter your character's name: ");
        string characterClass = Input.GetString("Enter your character's class: ");
        int level = Input.GetInt("Enter your character's level: ", 1, Config.CHARACTER_LEVEL_MAX, $"character level must be 1-{Config.CHARACTER_LEVEL_MAX}");
        int hitPoints = Input.GetInt("Enter your character's maximum hit points: ", 1, "must be greater than 0");
        Inventory inventory = new();

        while (true)
        {
            string? newItem = Input.GetString($"Enter the name of an item in {name}'s inventory. (Leave blank to end): ", false);
            if (newItem != "")
            {
                inventory.Items!.Add(new(newItem));
                continue;
            }
            break;
        }

        Console.Clear();
        Console.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", inventory)}.\n");

        CharacterManager.AddCharacter(
            new() { Name = name, Class = characterClass, Level = level, HitPoints = hitPoints, Inventory = inventory });

        CharacterManager.ExportCharacters();
    }

    public static void FindCharacter() // Asks the user for a name and displays a character based on input.
    {
        string characterName = Input.GetString("What is the name of the character you would like to search for? ");
        Character character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            character.DisplayCharacterInfo();
        } else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}\n[/]");
        }
    }

    private static Character? FindCharacterByName(string name) // Finds and returns a character based on input.
    {
        return Characters.Where(character => character.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
    }

    public static void LevelUp() //Asks the user for a character to level up, then displays that character.
    {
        string characterName = Input.GetString("What is the name of the character that you would like to level up? ");
        Character character = FindCharacterByName(characterName)!;
        Console.Clear();

        if (character != null)
        {
            if (character.Level < Config.CHARACTER_LEVEL_MAX)
            {
                character.LevelUp();
                AnsiConsole.MarkupLine($"[Green]Congratulations! {character.Name} has reached level {character.Level}[/]\n");
                character.DisplayCharacterInfo();
            }
            else
            {
                AnsiConsole.MarkupLine($"[Red]{character.Name} is already max level! ({Config.CHARACTER_LEVEL_MAX})[/]\n");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[Red]No characters found with the name {characterName}[/]\n");
        }
    }
    public static void AddCharacter(Character character) // Adds a new character to the stored characters list.
    {
        Characters.Add(character);
    }

    public static void DeleteCharacter(Character character) // Removes a character from the stored characters list.
    {
        Characters.Remove(character);
    }
}
