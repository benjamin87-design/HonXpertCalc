namespace HonXpertCalc.Views;

public partial class FrequencyToOrderPage : ContentPage
{
	public FrequencyToOrderPage(FrequencyToOrderViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
