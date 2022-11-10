using App.ViewModel;

namespace App;

public partial class EmployeePage : ContentPage
{
	private EmployeeViewModel viewModel;
	public EmployeePage(EmployeeViewModel viewModel)
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