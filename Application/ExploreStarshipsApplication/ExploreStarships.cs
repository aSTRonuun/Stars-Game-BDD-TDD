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
        }

        private async Task RunExploreStartShip()
        {
            Clear();
            while (true)
            {
                var result = await ChooseStarship();
                if (!result) break;
            }
            return;
        }

        private async Task<bool> ChooseStarship()
        {
            var prompt = "Chosse starship to see informations: \n" +
                     "Press the arrows key to cycle in the options";
            string[] options = { "Star Destroyer", "Death Star", "Millennium Falcon", "Executor" };
            var starshipsMenu = new Menu(prompt, options);
            var selectedIndex = starshipsMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    var startshipInformations = await GetInformations(StarshipEnum.Star_Destroyer);
                    Console.WriteLine(startshipInformations);
                    break;
                case 1:
                    var startshipInformations1 = await GetInformations(StarshipEnum.Death_Star);
                    Console.WriteLine(startshipInformations1);
                    break;
                case 2:
                    var startshipInformations2 = await GetInformations(StarshipEnum.Millennium_Falcon);
                    Console.WriteLine(startshipInformations2);
                    break;
                case 3:
                    var startshipInformations3 = await GetInformations(StarshipEnum.Executor);
                    Console.WriteLine(startshipInformations3);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press any key to continue... or SPACE to exit");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar)
                return false;
            return true;
        }

        public async Task<string> GetInformations(StarshipEnum starshipEnum)
        {
            var result = await _starshipInformationService.GetBydId((int) starshipEnum);

            if (result is null) return "Não foi possível resgatar as informações, tente novamente!";

            var resumeInformations = ConcatInformations(result);

            return resumeInformations;
        }


        private string ConcatInformations(StarshipsInformations startshipInformation)
        {
            var buffer = new StringBuilder();

            buffer.Append("\n ⭐ 🚀 Starship Informations: 🚀 ⭐\n");
            buffer.Append("Name: " + VerifyNullOrEmpty(startshipInformation.Name) + "\n");
            buffer.Append("Model: " + VerifyNullOrEmpty(startshipInformation.Model) + "\n");
            buffer.Append("Starship class: " + VerifyNullOrEmpty(startshipInformation.Starship_class) + "\n");
            buffer.Append("Manufacturer: " + VerifyNullOrEmpty(startshipInformation.Manufacturer) + "\n");
            buffer.Append("Cost in credits: " + VerifyNullOrEmpty(startshipInformation.Cost_in_credits) + "\n");
            buffer.Append("Crew: " + (startshipInformation.Crew) + "\n");
            
            if (VerifyNullOrEmpty(startshipInformation.Passengers) == "n/a")
                buffer.Append("Passengers: " + "0" + "\n");
            else
                buffer.Append("Passengers: " + startshipInformation.Passengers + "\n");

            if (VerifyNullOrEmpty(startshipInformation.Max_atmosphering_speed) == "n/a")
                buffer.Append("Max atmosphering speed: " + "0" + "\n");
            else
                buffer.Append("Max atmosphering speed: " + startshipInformation.Max_atmosphering_speed + "\n");
            
            buffer.Append("Cargo capacity: " + VerifyNullOrEmpty(startshipInformation.Cargo_capacity) + "\n");

            return buffer.ToString();
        }
        
        private string VerifyNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "Not informed";
            return value;
        }
        
    }
}
