namespace HonXpertCalc.ViewModels;

public partial class ProfileShiftFactorViewModel : BaseViewModel
{
    //strings
    [ObservableProperty]
    private string mdkFinishPart;
    [ObservableProperty]
    private string middleMdk;
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
    private string profileShiftFactorIs;

    [ObservableProperty]
    private string even;
    [ObservableProperty]
    private string odd;
    [ObservableProperty]
    private string result;

    public ProfileShiftFactorViewModel()
    {

    }

    //Calculate profile shift factor on button click
    [RelayCommand]
    private async Task Calculate()
    {
        if (!double.TryParse(MdkFinishPart, out double a))
        {
            await Shell.Current.DisplayAlert("Error", "Mdk finish part is not a valid number!", "OK");
            return;
        }
        if (!double.TryParse(MiddleMdk, out double b))
        {
            await Shell.Current.DisplayAlert("Error", "Middle Mdk is not a valid number!", "OK");
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
        if (!double.TryParse(ProfileShiftFactorIs, out double r))
        {
            await Shell.Current.DisplayAlert("Error", "Profile shift factor is not a valid number!", "OK");
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

        double o = ((Math.PI + 2 * c * (Math.Tan(m * Math.PI / 180) - m * Math.PI / 180 - h / (c * d * Math.Cos(f * Math.PI / 180) - k)) / (4 * Math.Tan(f * Math.PI / 180)))); // Profilverschiebungsfaktor gehont 
        double p = ((Math.PI + 2 * c * (Math.Tan(n * Math.PI / 180) - n * Math.PI / 180 - h / (c * d * Math.Cos(f * Math.PI / 180) - k)) / (4 * Math.Tan(f * Math.PI / 180)))); // Profilverschiebungsfaktor mitte

        double q = (o - p);

        Result = (q + r).ToString("0.####");
    }
}
