using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Wpf22.Models;
using Wpf22.Services.Interfaces;

namespace Wpf22.Services
{
    internal class WindowsUserDialogService : IUserDialogService
    {
        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(Message, Caption, MessageBoxButton.YesNo, Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                == MessageBoxResult.Yes;

        public bool Edit(object item)
        {
            switch (item)
            {
                case Student student:
                    break;
                default:
                    throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
                    
            }
        }

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        private static bool EditStudent(Student student
        {

        }

    }
}
