namespace HonXpertCalc.Views;

public partial class ToothMeshingFrequenciesPage : ContentPage
{
	public ToothMeshingFrequenciesPage(ToothMeshingFrequenciesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}