using FE.Advanture.Pattern.Services;
using Repository.Pattern.EF.Repositories;
using WPF.Contract;
using WPF.Model;

namespace WPF.Services
{

    public class EnrollmentService : Service<Enrollment>, IEnrollmentService
    {
        public EnrollmentService(IRepositoryAsync<Enrollment> repository) : base(repository)
        {
        }
    }
}
