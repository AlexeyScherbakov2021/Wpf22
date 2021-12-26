using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Models;

namespace Wpf22.Services.Students
{
    class StudentManager
    {
        private StudentsRepository _Students;
        private GroupsRepository _Groups;

        public IEnumerable<Student> Students => _Students.GetAll();

        public IEnumerable<Group> Groups => _Groups.GetAll();


        public StudentManager(StudentsRepository Students, GroupsRepository Groups)
        {
            _Students = Students;
            _Groups = Groups;
        }

        public void Update(Student student) => _Students.Update(student.Id, student);

        public bool Create(Student student, string GroupName)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrEmpty(GroupName)) throw new ArgumentException("Некорректное имя группы", nameof(GroupName));

            var group = _Groups.Get(GroupName);
            if(group is null)
            {
                group = new Group { Name = GroupName };
                _Groups.Add(group);
            }

            group.Students.Add(student);
            _Students.Add(student);

            return true;
        }

    }
}
