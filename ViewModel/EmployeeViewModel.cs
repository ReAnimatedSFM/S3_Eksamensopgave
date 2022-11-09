using CommunityToolkit.Mvvm.ComponentModel;
using Entities;
using Services.Interfaces;
using System.Collections.ObjectModel;

namespace ViewModel
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


        public async Task Initialize()
        {
            List<Resident> tempResidents = await employeeService.GetAllResidentsAsync();
            tempResidents.ForEach(resident => Residents.Add(resident));
        }
    }
}