using Application.MenuApplication;
using Application.PlayApplication;
using static System.Console;

namespace Application.StartApplication
{
    public class App
    {
        public void Start()
        {
            
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            var prompt = @"
     _______.___________.    ___      .______         ____    __    ____  ___      .______          _______.
    /       |           |   /   \     |   _  \        \   \  /  \  /   / /   \     |   _  \        /       |
   |   (----`---|  |----`  /  ^  \    |  |_)  |        \   \/    \/   / /  ^  \    |  |_)  |      |   (----`
    \   \       |  |      /  /_\  \   |      /          \            / /  /_\  \   |      /        \   \    
.----)   |      |  |     /  _____  \  |  |\  \----.      \    /\    / /  _____  \  |  |\  \----.----)   |   
|_______/       |__|    /__/     \__\ | _| `._____|       \__/  \__/ /__/     \__\ | _| `._____|_______/
                                          
                                            *** Welcome to the Star Wars Game! ***
                                       (Use the arrows key to cycle in the options)
";
            string[] options = {"Play", "Credits", "Explore Starships", "Exit" };
            var mainMenu = new Menu(prompt, options);
            var selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutCredisInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }
        
        private void ExitGame()
        {
            WriteLine("\n Press any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void RunFirstChoice()
        {
            var play = new Play();
            play.Start();
        }

        private void DisplayAboutCredisInfo()
        {
            do {
                Clear();
                WriteLine("This game was developed by: ");
                WriteLine("1. Vitor Alves");
                WriteLine("2. Rodrigo Morares");

                WriteLine("Subject: Software Verifications and Validations - Universidade Federal do Ceará UFC");
                WriteLine("Professor: Prof. Dr. Paline Calado");
                
                WriteLine("\n Press space to back to Main Menu");
            } while (ReadKey(true).Key != ConsoleKey.Spacebar);
            RunMainMenu();
        }
    }
    
    
}
