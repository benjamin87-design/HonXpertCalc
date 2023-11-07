namespace HonXpertCalc.Views;

public partial class ProfileShiftFactorPage : ContentPage
{
	public ProfileShiftFactorPage(ProfileShiftFactorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
