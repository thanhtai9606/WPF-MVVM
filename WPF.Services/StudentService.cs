using FE.Advanture.Pattern.Services;
using Repository.Pattern.EF.Repositories;
using WPF.Contract;
using WPF.Model;

namespace WPF.Services
{

    public class StudentService : Service<Student>, IStudentService
    {
        public StudentService(IRepositoryAsync<Student> repository) : base(repository)
        {
        }
    }
}
