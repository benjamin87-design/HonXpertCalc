using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonXpertCalc.ViewModels
{
    public partial class ToothMeshingFrequenciesViewModel : BaseViewModel
    {
        //Strings
        [ObservableProperty]
        private string numberOfTeethWP; //D6
        [ObservableProperty]
        private string numberOfTeethT; //D7
        [ObservableProperty]
        private string rpmC;        //D8
        [ObservableProperty]
        private string oscillationSpeed; //D10
        [ObservableProperty]
        private string oscillationLength; //D11
        [ObservableProperty]
        private string uLengthOfStay; //D12
        [ObservableProperty]
        private string frequencySearched; //D14

        [ObservableProperty]
        private string meshingFrequency1;
        [ObservableProperty]
        private string meshingFrequency2;
        [ObservableProperty]
        private string meshingFrequency3;

        public ToothMeshingFrequenciesViewModel()
        {

        }

        //Calc tooth meshing frequency 
        [RelayCommand]
        private void Calculate()
        {
            double ratioWP_T = Convert.ToDouble(NumberOfTeethT) / Convert.ToDouble(NumberOfTeethWP); //I5
            double ratioT_WP = Convert.ToDouble(NumberOfTeethWP) / Convert.ToDouble(NumberOfTeethT); //J5
            double oscillationTime = (Convert.ToDouble(OscillationLength) / Convert.ToDouble(OscillationSpeed)) * 60; //I7
            double rpmB = Convert.ToDouble(RpmC) / ratioWP_T; //I14

            //turn frequency 
            double turnFrequencyB = rpmB / 60; //E14
            double turnFrequencyC = Convert.ToDouble(RpmC) / 60; //E15

            //time U pause
            double lengthOfStayU = Convert.ToDouble(ULengthOfStay) / turnFrequencyB; //I8

            //time for one complete oscillation
            double oscillationCycleTime = (oscillationTime * 2) + (lengthOfStayU * 2); //I9

            //oscillation frequency
            double frequencyOscillation = 1 / oscillationCycleTime; //I17

            //tooth meshing frequency
            double teethMeshingFrequency1 = turnFrequencyB * Convert.ToDouble(NumberOfTeethWP); //E18
            double teethMeshingFrequency2 = turnFrequencyB * Convert.ToDouble(NumberOfTeethT); //E19
            double teethMeshingFrequency3 = turnFrequencyC * Convert.ToDouble(NumberOfTeethT); //E20

            //time for one complete turn (WP)
            double teethTimeOneRound = Convert.ToDouble(NumberOfTeethT) / turnFrequencyC; //E24

            //Frequency B and C to Order
            double orderC = Convert.ToDouble(FrequencySearched) / turnFrequencyC; //I23
            double orderB = Convert.ToDouble(FrequencySearched) / turnFrequencyB; //I24

            MeshingFrequency1 = teethMeshingFrequency1.ToString("0.###");
            MeshingFrequency2 = teethMeshingFrequency2.ToString("0.###");
            MeshingFrequency3 = teethMeshingFrequency3.ToString("0.###");


        }
    }
}