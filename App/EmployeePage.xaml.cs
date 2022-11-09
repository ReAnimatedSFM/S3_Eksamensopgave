using ViewModel;

namespace App;

public partial class EmployeePage : ContentPage
{
	private EmployeeViewModel viewModel;
	public EmployeePage(EmployeeViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = viewModel;
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{

	}

	private async void Window_Loaded(object sender, EventArgs e)
	{
		await viewModel.Initialize();
	}
}