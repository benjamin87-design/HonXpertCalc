namespace HonXpertCalc.ViewModels;

public partial class StockRemovalViewModel : BaseViewModel
{
    //strings
    [ObservableProperty]
    private string mdkFinishPart;
    [ObservableProperty]
    private string mdkRawPart;
    [ObservableProperty]
    private string numberOfTeeth;
    [ObservableProperty]
    private string modul;
    [ObservableProperty]
    private string pressureAngle;
    [ObservableProperty]
    private string helixAngle;
    [ObservableProperty]
    private string measuringBall;

    [ObservableProperty]
    private string even;
    [ObservableProperty]
    private string odd;
    [ObservableProperty]
    private string result;

    public StockRemovalViewModel()
    {

    }

    //Calculate stockremoval on button click
    [RelayCommand]
    private async Task Calculate()
    {
        if (!double.TryParse(MdkRawPart, out double a))
        {
            await Shell.Current.DisplayAlert("Error", "Mdk raw part is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(MdkFinishPart, out double b))
        {
            await Shell.Current.DisplayAlert("Error", "Mdk finish part is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(NumberOfTeeth, out double c))
        {
            await Shell.Current.DisplayAlert("Error", "Number of teeth is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(Modul, out double d))
        {
            await Shell.Current.DisplayAlert("Error", "Modul is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(PressureAngle, out double f))
        {
            await Shell.Current.DisplayAlert("Error", "Pressure angle is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(HelixAngle, out double g))
        {
            await Shell.Current.DisplayAlert("Error", "Helix angle is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(MeasuringBall, out double h))
        {
            await Shell.Current.DisplayAlert("Error", "Measuring ball is not a valid number!", "OK");
            return;
        }

        double i = ((d * c) / (Math.Cos(g * Math.PI / 180))); // Teilkreisdurchmesser
        double j = (Math.Atan(Math.Tan(f * Math.PI / 180) / Math.Cos(g * Math.PI / 180)) * 180 / Math.PI); // Stirneingriffswinkel
        double k = (Math.Tan(j * Math.PI / 180) - j * Math.PI / 180); // Excel B19
        double l = (i * Math.Cos(j * Math.PI / 180)); // Grundkreisdurchmesser 
        if (c % 2 == 0)
        {
            Even = (Math.Acos(l / (a - h)) * 180 / Math.PI).ToString();
        }
        else
        {
            Even = (Math.Acos((l * Math.Cos(Math.PI / (2 * c))) / (a - h)) * 180 / Math.PI).ToString(); // B21
        }

        if (c % 2 == 0)
        {
            Odd = (Math.Acos(l / (b - h)) * 180 / Math.PI).ToString();
        }
        else
        {
            Odd = (Math.Acos((l * Math.Cos(Math.PI / (2 * c))) / (b - h)) * 180 / Math.PI).ToString(); // C21
        }

        double m = Convert.ToDouble(Even);
        double n = Convert.ToDouble(Odd);

        double o = ((Math.PI + 2 * c * (Math.Tan(m * Math.PI / 180) - m * Math.PI / 180 - h / (c * d * Math.Cos(f * Math.PI / 180) - k)) / (4 * Math.Tan(f * Math.PI / 180)))); // Profilverschiebungsfaktor Rohteil 
        double p = ((Math.PI + 2 * c * (Math.Tan(n * Math.PI / 180) - n * Math.PI / 180 - h / (c * d * Math.Cos(f * Math.PI / 180) - k)) / (4 * Math.Tan(f * Math.PI / 180)))); // Profilverschiebungsfaktor Fertigteil


        Result = ((o - p) * d * Math.Sin(f * Math.PI / 180)).ToString("0.####");
    }
}
