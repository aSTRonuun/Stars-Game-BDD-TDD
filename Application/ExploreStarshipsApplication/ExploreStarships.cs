using Application.MenuApplication;
using Domain.StarshipsInformationsDomain.Entities;
using Domain.StarshipsInformationsDomain.Enuns;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using System.Text;
using static System.Console;

namespace Application.ExploreStarshipsApplication
{
    public class ExploreStarships
    {
        private IStarshipInformationService _starshipInformationService { get; set; }

        public ExploreStarships(IStarshipInformationService starshipInformationService)
        {
            _starshipInformationService = starshipInformationService;
        }

        public async Task Start()
        {
            await RunExploreStartShip();
            return;
        }

        private async Task RunExploreStartShip()
        {
            Clear();
            await ChooseStarship();
            ExitGame();
            return;
        }

        private async Task ChooseStarship()
        {
            var prompt = "Chosse starship to see informations: \n" +
                     "Press the arrows key to cycle in the options";
            string[] options = { "Star Destroyer", "Death Star", "Millennium Falcon", "Executor" };
            var starshipsMenu = new Menu(prompt, options);
            var selectedIndex = starshipsMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    var startshipInformations = await _starshipInformationService.GetBydId((int)StarshipEnum.Star_Destroyer);
                    Console.WriteLine(ConcatInformations(startshipInformations));
                    break;
                case 1:
                    var startshipInformations1 = await _starshipInformationService.GetBydId((int)StarshipEnum.Death_Star);
                    Console.WriteLine(ConcatInformations(startshipInformations1));
                    break;
                case 2:
                    var startshipInformations2 = await _starshipInformationService.GetBydId((int)StarshipEnum.Millennium_Falcon);
                    Console.WriteLine(ConcatInformations(startshipInformations2));
                    break;
                case 3:
                    var startshipInformations3 = await _starshipInformationService.GetBydId((int)StarshipEnum.Executor);
                    Console.WriteLine(ConcatInformations(startshipInformations3));
                    break;
                default:
                    break;
            }
            return;
        }

        public string ConcatInformations(StarshipsInformations startshipInformation)
        {
            var buffer = new StringBuilder();

            buffer.Append("Name: " + startshipInformation.Name + "\n");
            buffer.Append("Model: " + startshipInformation.Model + "\n");
            buffer.Append("Starship_class: " + startshipInformation.Starship_class + "\n");
            buffer.Append("Manufacturer: " + startshipInformation.Manufacturer + "\n");
            buffer.Append("Cost_in_credits: " + startshipInformation.Cost_in_credits + "\n");
            buffer.Append("Crew: " + startshipInformation.Crew + "\n");
            
            if (startshipInformation.Passengers == "n/a")
                buffer.Append("Passengers: " + "0" + "\n");
            else
                buffer.Append("Passengers: " + startshipInformation.Passengers + "\n");

            if (startshipInformation.Max_atmosphering_speed == "n/a")
                buffer.Append("Max_atmosphering_speed: " + "0" + "\n");
            else
                buffer.Append("Max_atmosphering_speed: " + startshipInformation.Max_atmosphering_speed + "\n");
            
            buffer.Append("Cargo_capacity: " + startshipInformation.Cargo_capacity + "\n");
            buffer.Append("qtdFamousPilots: " + startshipInformation.qtdFamousPilots + "\n");

            return buffer.ToString();
        }

        private void ExitGame()
        {
            WriteLine("\n Press any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
