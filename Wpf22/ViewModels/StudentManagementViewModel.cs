using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Wpf22.Infrastructire.Commands;
using Wpf22.Models;
using Wpf22.Services.Students;
using Wpf22.Views;

namespace Wpf22.ViewModels
{
    internal class StudentManagementViewModel : ViewModel
    {
        private StudentManager _StudentManager;
        public string Title { get; set; } = "Управление студентами";

        public IEnumerable<Student> Students => _StudentManager.Students;

        public IEnumerable<Group> Groups => _StudentManager.Groups;

        private Group _SelectedGroup;
        public Group SelectedGroup { get => _SelectedGroup; set => Set(ref _SelectedGroup, value); }

        private Student _SelectedStudent;
        public Student SelectedStudent { get => _SelectedStudent; set => Set(ref _SelectedStudent, value); }


        private ICommand _EditStudentCommand;
        public ICommand EditStudentCommand => _EditStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecute, CanEditStudentCommandExecute);
        //{
        //    if(_EditStudentCommand == null)
        //        _EditStudentCommand = new LambdaCommand(OnEditStudentCommandExecute, CanEditStudentCommandExecute);

        //    return _EditStudentCommand;
        //} 
        private bool CanEditStudentCommandExecute(object p) => p is Student;
        private void OnEditStudentCommandExecute(object p)
        {
            var student = (Student)p;

            var dlg = new StudentEditorWindow
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronymic = student.Patronymic,
                Rating = student.Rating,
                BirthDay = student.Birthday
            };

            if (dlg.ShowDialog() == true)
                MessageBox.Show("Редактирование выполнено.");
            else
                MessageBox.Show("Пользователь отказался.");
        }

        private ICommand _CreateNewStudentCommand;
        public ICommand CreateNewStudentCommand  => _CreateNewStudentCommand ??= new LambdaCommand(OnCreateNewStudentCommandExecute, CanCreateNewStudentCommandExecute);
        //{
        //    if (_CreateNewStudentCommand == null)
        //        _CreateNewStudentCommand = new LambdaCommand(OnCreateNewStudentCommandExecute, CanCreateNewStudentCommandExecute);

        //    return _CreateNewStudentCommand;
        //}
        private bool CanCreateNewStudentCommandExecute(object p) => p is Group;
        private void OnCreateNewStudentCommandExecute(object p)
        {
            var group = (Group)p;


        }


        public StudentManagementViewModel(StudentManager StudentManager) { _StudentManager = StudentManager; }
    }
}
