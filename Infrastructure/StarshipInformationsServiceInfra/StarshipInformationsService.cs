using Domain.StarshipsInformationsDomain.Entities;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using System.Text.Json;

namespace Infrastructure.StarshipInformationsServiceInfra
{
    public class StarshipInformationsService : IStarshipInformationService
    {
        private readonly HttpClient _client;
        private string apiUrl = "https://swapi.dev/api/starships/";

        public StarshipInformationsService()
        {
            _client = new HttpClient();
        }

        public async Task<StarshipsInformations> GetBydId(int id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(apiUrl + id + "/");

                if (response.IsSuccessStatusCode)
                {
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (JsonDocument jsonDocument = await JsonDocument.ParseAsync(responseStream))
                        {
                            var dateNow = DateTime.Now.ToString("MM-dd-yyyy-H-mm-ss");
                            JsonElement root = jsonDocument.RootElement;
                            string jsonString = jsonDocument.RootElement.ToString();
                            SaveJsonToFile(jsonString, $"../../../../buffersjon/json{dateNow}.txt");

                            // Obtendo os valores das propriedades desejadas
                            string name = root.GetProperty("name").GetString();
                            string model = root.GetProperty("model").GetString();
                            string starship_class = root.GetProperty("starship_class").GetString();
                            string manufacturer = root.GetProperty("manufacturer").GetString();
                            string cost_in_credits = root.GetProperty("cost_in_credits").GetString();
                            string crew = root.GetProperty("crew").ToString();
                            string passengers = root.GetProperty("passengers").ToString();
                            string max_atmosphering_speed = root.GetProperty("max_atmosphering_speed").ToString();
                            string cargo_capacity = root.GetProperty("cargo_capacity").ToString();


                            StarshipsInformations starship = new StarshipsInformations()
                            {
                                Name = name,
                                Model = model,
                                Starship_class = starship_class,
                                Manufacturer = manufacturer,
                                Cost_in_credits = cost_in_credits,
                                Crew = crew,
                                Passengers = passengers,
                                Max_atmosphering_speed = max_atmosphering_speed,
                                Cargo_capacity = cargo_capacity
                            };

                            return starship;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Erro na chamada da API: " + ex.Message);
                return null;
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("A solicitação foi cancelada: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro inesperado: " + ex.Message);
                return null;
            }
        }

        private async Task SaveJsonToFile(string jsonDocument, string path)
        {
            try
            {
                File.WriteAllText(path, jsonDocument);
                Console.WriteLine("JSON saved to file: " + path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving JSON to file: " + ex.Message);
            }
        }
    }
}
