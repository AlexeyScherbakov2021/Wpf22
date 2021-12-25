using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Wpf22.Infrastructire.Commands.Base;
using Wpf22.Views;

namespace Wpf22.Infrastructire.Commands
{
    class ManageStudentsCommand : Command
    {
        private StudentManagementWindow _Window;

        public override bool CanExecute(object parameter) => _Window == null;

        public override void Execute(object parameter)
        {
            var window = new StudentManagementWindow
            {
                Owner = Application.Current.MainWindow
            };

            _Window = window;
            window.Closed += Window_Closed;

            window.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= Window_Closed;
            _Window = null;
        }
    }
}
