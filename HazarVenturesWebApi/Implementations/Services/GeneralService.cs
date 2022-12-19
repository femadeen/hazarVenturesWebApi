using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.ResponseModels;

namespace HazarVenturesWebApi.Implementations.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        public GeneralService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, ILecturerRepository lecturerRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _lecturerRepository = lecturerRepository;
        }

        public async  Task<DashboardResponseModel> DashBoard()
        {
            var studentCount = await _studentRepository.GetStudentCount();
            var departmentCount = await _departmentRepository.GetDepartmentCount();
            var lecturerCount = await _lecturerRepository.GetLecturerCount();
            return new DashboardResponseModel
            {
                StudentCount = studentCount,
                DepartmentCount = departmentCount,
                LecturerCount = lecturerCount,
                Status = true,
                Message = " Count Retreived"
            };
        }
    }
}
