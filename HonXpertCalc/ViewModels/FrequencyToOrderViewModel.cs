using System.Runtime.Intrinsics.Arm;

namespace HonXpertCalc.ViewModels;

public partial class FrequencyToOrderViewModel : BaseViewModel
{
    //Strings
    [ObservableProperty]
    private string order;
    [ObservableProperty]
    private string rpm;
    [ObservableProperty]
    private string frequency;

    public FrequencyToOrderViewModel()
    {

    }

    //Calculate Frequency to Order
    [RelayCommand]
    private void CalcFreqToOrder()
    {
        //Turn frequency
        double turnFrequency = Convert.ToDouble(Rpm) / 60;

        //Hz / rps = Frequency
        double orderFromFrequency = Convert.ToDouble(Frequency) / turnFrequency;

        Order = orderFromFrequency.ToString("0.####");
    }

    //Calculate Order to Frequency
    [RelayCommand]
    private async Task CalcOrderToFreq()
    {

    }
}
