using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entities;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel
{
    [QueryProperty("Id", "Id")]
    public partial class ResidentAssignmentDetailViewModel : ObservableObject
    {
        private IAssignmentService assignmentService;

        public ResidentAssignmentDetailViewModel(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
            Assignments = new();
        }

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string updatedNotes;

        [ObservableProperty]
        ObservableCollection<Assignment> assignments;

        public async Task Initialize()
        {
            List<Assignment> tempAssignments = await assignmentService
                .GetAssignmentsByResidentAsync(Id);
            tempAssignments.ForEach(@assignment => Assignments.Add(@assignment));
        }

        [ICommand]
        public async Task Update(int id)
        {
            Assignment assignment = await assignmentService.GetSingleAssignmentAsync(id);

            assignment.Notes = UpdatedNotes;
            assignment.Finished = true;

            await assignmentService.UpdateAssignmentNotesAsync(assignment);
        }

        [ICommand]
        public async Task Return()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
