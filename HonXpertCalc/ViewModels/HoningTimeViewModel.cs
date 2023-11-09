using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonXpertCalc.ViewModels
{
    public partial class HoningTimeViewModel : BaseViewModel
    {
        //RPM
        [ObservableProperty]
        private string cRpm;
        [ObservableProperty]
        private string numberOfToothWP;
        [ObservableProperty]
        private string numberOfToothT;

        //Distances
        [ObservableProperty]
        private string touching1Distance;
        [ObservableProperty]
        private string touching2Distance;
        [ObservableProperty]
        private string working1Distance;
        [ObservableProperty]
        private string working2Distance;

        //Feed for distance
        [ObservableProperty]
        private string plungingFeed;
        [ObservableProperty]
        private string touching1Feed;
        [ObservableProperty]
        private string touching2Feed;
        [ObservableProperty]
        private string working1Feed;
        [ObservableProperty]
        private string working2Feed;

        //scillation
        [ObservableProperty]
        private string oscillationDistance;
        [ObservableProperty]
        private string sparkOut;
        [ObservableProperty]
        private string oscillationFeedSpartOut;
        [ObservableProperty]
        private string pauseUB;
        [ObservableProperty]
        private string total;

        public HoningTimeViewModel()
        {

        }

        //Calculate honing time 
        [RelayCommand]
        private void Calculate()
        {
            var turnFrequencyB = Convert.ToDouble(CRpm) / (Convert.ToDouble(NumberOfToothT) / Convert.ToDouble(NumberOfToothWP)) / 60;
            var lengthOfStayU = Convert.ToDouble(PauseUB) / turnFrequencyB;
            var oscillationTime = (Convert.ToDouble(OscillationDistance) / Convert.ToDouble(OscillationFeedSpartOut)) * 60;
            
            var timesparkout = (oscillationTime * 2) + (lengthOfStayU * 2) * Convert.ToDouble(SparkOut);
            var timetouching1 = 60 / Convert.ToDouble(Touching1Feed) * Convert.ToDouble(Touching1Distance);
            var timetouching2 = 60 / Convert.ToDouble(Touching2Feed) * Convert.ToDouble(Touching2Distance);
            var timeworking1 = 60 / Convert.ToDouble(Working1Feed) * Convert.ToDouble(Working1Distance);
            var timeworking2 = 60 / Convert.ToDouble(Working2Feed) * Convert.ToDouble(Working2Distance);

            Total = (timetouching1 + timetouching2 + timeworking1 + timeworking2 + timesparkout).ToString();
        }
    }
}
