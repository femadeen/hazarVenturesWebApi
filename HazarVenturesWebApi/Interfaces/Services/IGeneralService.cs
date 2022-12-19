using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Interfaces.Services
{
    public interface IGeneralService
    {
        Task<DashboardResponseModel> DashBoard();
    }
}
