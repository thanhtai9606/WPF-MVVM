using FE.Advanture.Pattern.Services;
using Repository.Pattern.EF.Repositories;
using WPF.Contract;
using WPF.Model;

namespace WPF.Services
{

    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService(IRepositoryAsync<Course> repository) : base(repository)
        {
        }
    }
}
