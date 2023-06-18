using Application.ExploreStarshipsApplication;
using Domain.StarshipsInformationsDomain.Entities;
using Domain.StarshipsInformationsDomain.Enuns;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using Moq;
using NUnit.Framework;

namespace UnitTests.ApplicationTest.ExploreStarshipsApplicationTests
{
    public class ExploreStartshipsTests
    {
        private Mock<IStarshipInformationService> _starshipInformationService;
        private ExploreStarships _exploreStarships;

        [SetUp]
        public void Setup()
        {
            _starshipInformationService = new Mock<IStarshipInformationService>();
            _exploreStarships = new ExploreStarships(_starshipInformationService.Object);
        }

        [Test]
        public async Task GetInformations_WhenWasNotPossibleGetInformationsAndServiceReturnNull_ShouldBeErrorMenssageAsync()
        {
            
            // Arrange
            
            var id = 9;
            
            _starshipInformationService.Setup(x => x.GetBydId(id)).ReturnsAsync((StarshipsInformations)null);
            
            var expectStringError = "Não foi possível resgatar as informações, tente novamente!";

            // Action
            var result = await _exploreStarships.GetInformations(StarshipEnum.Death_Star);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectStringError, result);
        }

        [Test]
        public async Task GetInformations_WhenPropertiePassengersIsNA_ShouldFormatted()
        {
            // Arrange
            var id = 9;
            
            var starshipResult = new StarshipsInformations
            {
                Name = "Death Star",
                Model = "DS-1 Orbital Battle Station",
                Manufacturer = "Imperial Department of Military Research, Sienar Fleet Systems",
                Cost_in_credits = "1000000000000",
                Crew = "342953",
                Passengers = "n/a",
                Cargo_capacity = "1000000000000",
                Max_atmosphering_speed = "500000",
                Starship_class = "Deep Space Mobile Battlestation"
            };
            
            var expectString = "Name: Death Star\n" +
                               "Model: DS-1 Orbital Battle Station\n" +
                               "Starship_class: Deep Space Mobile Battlestation\n" +
                               "Manufacturer: Imperial Department of Military Research, Sienar Fleet Systems\n" +
                               "Cost_in_credits: 1000000000000\n" +
                               "Crew: 342953\n" +
                               "Passengers: 0\n" +
                               "Max_atmosphering_speed: 500000\n" +
                               "Cargo_capacity: 1000000000000\n";
            
            _starshipInformationService.Setup(x => x.GetBydId(id))
                .ReturnsAsync(starshipResult);
            
            // Action
            
            var result = await _exploreStarships.GetInformations(StarshipEnum.Death_Star);
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectString, result);
        }
        
        [Test]
        public async Task GetInformations_WhenPropertieMax_atmosphering_speedIsNA_ShouldFormatted()
        {
            // Arrange
            var id = 9;
            
            var starshipResult = new StarshipsInformations
            {
                Name = "Death Star",
                Model = "DS-1 Orbital Battle Station",
                Manufacturer = "Imperial Department of Military Research, Sienar Fleet Systems",
                Cost_in_credits = "1000000000000",
                Crew = "342953",
                Passengers = "843342",
                Cargo_capacity = "1000000000000",
                Max_atmosphering_speed = "n/a",
                Starship_class = "Deep Space Mobile Battlestation"
            };
            
            var expectString = "Name: Death Star\n" +
                               "Model: DS-1 Orbital Battle Station\n" +
                               "Starship_class: Deep Space Mobile Battlestation\n" +
                               "Manufacturer: Imperial Department of Military Research, Sienar Fleet Systems\n" +
                               "Cost_in_credits: 1000000000000\n" +
                               "Crew: 342953\n" +
                               "Passengers: 843342\n" +
                               "Max_atmosphering_speed: 0\n" +
                               "Cargo_capacity: 1000000000000\n";
            
            _starshipInformationService.Setup(x => x.GetBydId(id))
                .ReturnsAsync(starshipResult);
            
            // Action
            
            var result = await _exploreStarships.GetInformations(StarshipEnum.Death_Star);
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectString, result);
        }
    }
}
