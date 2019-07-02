using System;
using System.Collections.Generic;
using System.Text;
using WPF.Common;

namespace WPF.Model
{
    public class Student:BaseViewModel
    {
        private int _ID;
        private string _LastName;
        private string _FirstMidName;
        private DateTime _EnrollmentDate;
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        public string LastName { get => _LastName; set { _LastName = value; OnPropertyChanged(); } }
        public string FirstMidName { get => _FirstMidName; set { _FirstMidName = value;OnPropertyChanged(); } }
        public DateTime EnrollmentDate { get { if (_EnrollmentDate.Date == DateTime.Parse("1/1/0001")) return DateTime.Now; else return _EnrollmentDate; } set { _EnrollmentDate = value ; OnPropertyChanged(); } }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
