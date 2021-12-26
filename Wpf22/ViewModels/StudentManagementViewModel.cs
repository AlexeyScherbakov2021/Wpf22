using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Wpf22.Infrastructire.Commands;
using Wpf22.Models;
using Wpf22.Services.Interfaces;
using Wpf22.Services.Students;
using Wpf22.Views;

namespace Wpf22.ViewModels
{
    internal class StudentManagementViewModel : ViewModel
    {
        private StudentManager _StudentManager;
        private IUserDialogService _UserDialog;

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
        private bool CanEditStudentCommandExecute(object p) => p is Student;
        private void OnEditStudentCommandExecute(object p)
        {
            if (_UserDialog.Edit(p))
            {
                _StudentManager.Update((Student)p);

                _UserDialog.ShowInformation("Студент отредавтирован", "Менеджер студентов");
            }
            else
                _UserDialog.ShowWarning("Отказ от редактирования", "Менеджер студентов");

        }

        private ICommand _CreateNewStudentCommand;
        public ICommand CreateNewStudentCommand  => _CreateNewStudentCommand ??= new LambdaCommand(OnCreateNewStudentCommandExecute, CanCreateNewStudentCommandExecute);

        private bool CanCreateNewStudentCommandExecute(object p) => p is Group;
        private void OnCreateNewStudentCommandExecute(object p)
        {
            var group = (Group)p;

            var student = new Student();
            if(!_UserDialog.Edit(student) || _StudentManager.Create(student, group.Name))
            {
                OnPropertyChanged(nameof(student));
                return;
            }

            if (_UserDialog.Confirm("Не удалось создать студента. Повторить?", "Менеджер студентов"))
                    OnCreateNewStudentCommandExecute(p);

        }

        private ICommand _TestCommand;
        public ICommand TestCommand => _TestCommand ??= new LambdaCommand(OnTestCommandExecute, CanTestCommandExecute);
        private bool CanTestCommandExecute(object p) => true;
        private void OnTestCommandExecute(object p)
        {
            var value = _UserDialog.GetStringValue("Введите строку","123","Значение по умлочанию");
            _UserDialog.ShowInformation($"Введено: {value}","123");
        }


        public StudentManagementViewModel(StudentManager StudentManager, IUserDialogService UserDialog) 
        { 
            _StudentManager = StudentManager;
            _UserDialog = UserDialog;
        }

    }
}
