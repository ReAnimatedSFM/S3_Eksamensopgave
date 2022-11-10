using App.ViewModel;
using Entities;
using Services;
using Services.Interfaces;

namespace App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<EmployeePage>();
            builder.Services.AddTransient<EmployeeViewModel>();

            builder.Services.AddTransient<IAssignmentService, AssignmentService>();
            builder.Services.AddTransient<ResidentAssignmentDetailPage>();
            builder.Services.AddTransient<ResidentAssignmentDetailViewModel>();

            return builder.Build();
        }
    }
}