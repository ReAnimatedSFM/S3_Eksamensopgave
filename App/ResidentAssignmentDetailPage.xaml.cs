using App.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Entities;
using System.Collections.ObjectModel;

namespace App;

public partial class ResidentAssignmentDetailPage : ContentPage
{
	private ResidentAssignmentDetailViewModel viewModel;

	public ResidentAssignmentDetailPage(ResidentAssignmentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = this.viewModel;
	}

	private async void Window_Loaded(object sender, EventArgs e)
	{
		await viewModel.Initialize();
	}

}