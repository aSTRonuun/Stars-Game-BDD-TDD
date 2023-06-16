using Application.ExploreStarshipsApplication;
using Domain.StarshipsInformationsDomain.Port;
using Infrastructure.StarshipInformationsServiceInfra.Port;
using Moq;
using NUnit.Framework;

namespace UnitTests.ApplicationTest.ExploreStarshipsApplicationTests
{
    public class ExploreStartshipsTests
    {
        private Mock<IStarshipInformationService> _service;
        private ExploreStarships _exploreStarships;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IStarshipInformationService>();
            _exploreStarships = new ExploreStarships(_service.Object);
        }
    }
}
