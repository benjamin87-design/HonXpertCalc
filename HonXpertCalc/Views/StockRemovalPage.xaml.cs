namespace HonXpertCalc.Views;

public partial class StockRemovalPage : ContentPage
{
	public StockRemovalPage(StockRemovalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
