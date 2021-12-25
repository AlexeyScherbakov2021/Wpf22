using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf22.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();

        public StudentManagementViewModel StudentManagement => App.Host.Services.GetRequiredService<StudentManagementViewModel>();
    }
}
