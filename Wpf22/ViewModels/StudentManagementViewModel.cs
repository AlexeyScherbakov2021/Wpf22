using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Models;
using Wpf22.Services.Students;

namespace Wpf22.ViewModels
{
    internal class StudentManagementViewModel : ViewModel
    {
        private StudentManager _StudentManager;
        public string Title { get; set; } = "Управление студентами";

        public IEnumerable<Student> Students => _StudentManager.Students;

        public IEnumerable<Group> Groups => _StudentManager.Groups;

        private Group _SelectedGroup;
        public Group SelectedGroup{ get => _SelectedGroup; set => Set(ref _SelectedGroup, value); }

        private Student _SelectedStudent;
        public Student SelectedStudent { get => _SelectedStudent; set => Set(ref _SelectedStudent, value); }

        public StudentManagementViewModel(StudentManager StudentManager) { _StudentManager = StudentManager; }
    }
}
