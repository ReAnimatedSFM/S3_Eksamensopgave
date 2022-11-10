using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using Services.Interfaces;
using System.Collections.ObjectModel;

namespace App.ViewModel
{
    public partial class EmployeeViewModel : ObservableObject
    {
        private IEmployeeService employeeService;

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
            Residents = new();
        }

        [ObservableProperty]
        ObservableCollection<Resident> residents;

        [ICommand]
        public async Task Tap(int id)
        {
            await Shell.Current.GoToAsync($"{nameof(ResidentAssignmentDetailPage)}?Id={id}");
        }


        public async Task Initialize()
        {
            List<Resident> tempResidents = await employeeService.GetAllResidentsAsync();
            tempResidents.ForEach(resident => Residents.Add(resident));
        }
    }
}