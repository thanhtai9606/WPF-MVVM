using Repository.Pattern.EF.Factory;
using Repository.Pattern.EF.UnitOfWork;
using System;
using System.Windows.Input;
using WPF.Common;
using WPF.Contract;
using WPF.Model;
using WPF.Services;

namespace WPF.ViewModel
{
    public class StudentViewModel:BaseViewModel
    {
        private readonly IStudentService _studentService;
        private  readonly IUnitOfWorkAsync _unitOfWork;
        public Student Student { set; get; }

        public ICommand Add { get; set; }
        public ICommand Update { get; set; }
        public ICommand Delete { get; set; }
        public ICommand Get { get; set; }
        public ICommand Find { get; set; }

        public StudentViewModel(IStudentService studentService, IUnitOfWorkAsync unitOfWork)
        {
            _studentService = studentService;
            _unitOfWork = unitOfWork;
            Student = new Student();
            Add = new RelayCommand<object>((p) => 
            {
                bool canExcute;
                canExcute = string.IsNullOrEmpty(Student.FirstMidName) ? false : true;
                return canExcute;
             }, (p) => AddStudent());
            Update = new RelayCommand<object>((p) => { return true; }, (p) => UpdateStudent());
            Delete = new RelayCommand<object>((p) => { return true; }, (p) => DeleteStudent());
        }

        private void AddStudent()
        {
            _studentService.Add(Student);
            _unitOfWork.SaveChanges();
        }
        private void DeleteStudent()
        {
            _studentService.Delete(Student);
            _unitOfWork.SaveChanges();
        }

        private void UpdateStudent()
        {
            _studentService.Update(Student);
            _unitOfWork.SaveChanges();
        }

       

    }
}
