namespace HazarVenturesWebApi.Models.ResponseModels
{
    public class DashboardResponseModel : BaseResponse
    {
        public int StudentCount { get; set; }
        public int LecturerCount { get; set; }
        public int DepartmentCount { get; set; }
    }
}
