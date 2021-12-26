using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Wpf22.Models;
using Wpf22.Services.Interfaces;
using Wpf22.Views;

namespace Wpf22.Services
{
    internal class WindowsUserDialogService : IUserDialogService
    {
        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(Message, Caption, MessageBoxButton.YesNo, Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;

        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                case Student student:
                    return EditStudent(student);
                default:
                    throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
                    
            }
        }

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        private static bool EditStudent(Student student)
        {
            var dlg = new StudentEditorWindow
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronymic = student.Patronymic,
                Rating = student.Rating,
                BirthDay = student.Birthday
            };

            if (dlg.ShowDialog() != true) return false;

            student.Name = dlg.FirstName;
            student.Surname = dlg.LastName;
            student.Patronymic = dlg.Patronymic;
            student.Rating = dlg.Rating;
            student.Birthday = dlg.BirthDay;

            return true;

        }

        public string GetStringValue(string Message, string Caption, string DefaultValue = null)
        {
            var value_dialog = new StringValueDialogWindow
            {
                Message = Message,
                Title = Caption,
                Value = DefaultValue ?? String.Empty
                //Owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsFocused)
            };

            return value_dialog.ShowDialog() == true ? value_dialog.Value : DefaultValue;
        }
    }
}
