using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Models;
using Wpf22.Services.Base;
using Wpf22.Services.Students;

namespace Wpf22.Services
{
    class StudentsRepository : RepositoryInMemory<Student>
    {
        public StudentsRepository() : base(TestData.Students) { }
        
        protected override void Update(Student Source, Student Destination)
        {
            Destination.Name = Source.Name;
            Destination.Surname = Source.Surname;
            Destination.Patronymic = Source.Patronymic;
            Destination.Birthday = Source.Birthday;
            Destination.Rating = Source.Rating;
        }
    }

}
 