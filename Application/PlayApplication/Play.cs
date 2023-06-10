using Application.MenuApplication;
using Domain.BoardDomain.Enums;
using Domain.GameDomain.Entities;
using Domain.PlayerDomain.Execptions;

namespace Application.PlayApplication;
using static System.Console;

public class Play
{
    private string Name = string.Empty;
    private Dificulty Dificulty;
    private int NumberOfChances = 0;
    private Game Game = new Game();
    
    public void Start()
    {
        RunPlayGame();
    }

    private void RunPlayGame()
    {
        while (true) {
            if (ChooseYourName()) break;
        }
        ChooseDificultMenu();
        Game.Start();
    }

    private bool ChooseYourName() 
    {
        Clear();
        try {
            WriteLine("Choose your name:");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("OBS: The name must be between 1 and 20 characters and is not allowed to use special characters!");
            ResetColor();
            Write(">> ");
            Name = ReadLine();
            Game.LoadPlayer(Name);
        } catch (InvalidCharactersNameException) {
            WriteLine("Is not allowed to use special characters! Try again!");
            ReadKey(true);
            return false;
        } catch (InvalidNameLengthException) {
            WriteLine("The name must be between 1 and 20 characters! Try again!");
            ReadKey(true);
            return false;
        }
        
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"Hello {Name}! Welcome to the Star Wars Game!, Your name has been saved!");
        WriteLine("Press any key to continue...");
        ResetColor();
        ReadKey(true);
        return true;
    }

    private void ChooseDificultMenu()
    {
        var prompt = "Choose the dificulty: \n" +
                     "Press the arrows key to cycle in the options";
        string[] options = {"Easy", "Medium", "Hard" };
        var dificultMenu = new Menu(prompt, options);
        var selectedIndex = dificultMenu.Run();
        
        switch (selectedIndex)
        {
            case 0:
                Game.LoadBoard(Dificulty.Easy);
                break;
            case 1:
                Game.LoadBoard(Dificulty.Medium);
                break;
            case 2:
                Game.LoadBoard(Dificulty.Hard);
                break;
            default:
                break;
        }
    }
}