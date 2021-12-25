using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Models;

namespace Wpf22.Services.Students
{
    class StudentManager
    {
        private StudentsRepository _Strudents;
        private GroupsRepository _Groups;

        public IEnumerable<Student> Students => _Strudents.GetAll();

        public IEnumerable<Group> Groups => _Groups.GetAll();


        public StudentManager(StudentsRepository Students, GroupsRepository Groups)
        {
            _Strudents = Students;
            _Groups = Groups;
        }
    }
}
