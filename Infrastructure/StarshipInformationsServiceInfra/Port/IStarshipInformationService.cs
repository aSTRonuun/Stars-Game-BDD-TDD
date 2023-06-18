using Domain.StarshipsInformationsDomain.Entities;

namespace Infrastructure.StarshipInformationsServiceInfra.Port
{
    public interface IStarshipInformationService
    {
        Task<StarshipsInformations> GetBydId(int id);
    }
}
