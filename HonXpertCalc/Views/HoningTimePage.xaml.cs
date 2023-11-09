namespace HonXpertCalc.Views;

public partial class HoningTimePage : ContentPage
{
	public HoningTimePage(HoningTimeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}