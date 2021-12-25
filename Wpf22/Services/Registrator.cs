using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wpf22.Services.Students;

namespace Wpf22.Services
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<StudentsRepository>();
            services.AddSingleton<GroupsRepository>();
            services.AddSingleton<StudentManager>();

            return services;
        }
    }
}
