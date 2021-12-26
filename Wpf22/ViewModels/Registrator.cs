using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Services;
using Wpf22.Services.Interfaces;

namespace Wpf22.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<StudentManagementViewModel>();

            services.AddTransient<IUserDialogService, WindowsUserDialogService>();
            return services;
        }
    } 
}
