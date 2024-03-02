using Inversity_group_Challange.Json_Obj;

namespace Inversity_group_Challange
{
    public partial class MainPage : ContentPage
    {

        CarInfo Audi = new CarInfo()
        {
            Model = "55 Auto Quattro",
            Year = 2019,
            InitialBatterySize = 95,
            Range = 237

        };

        CarInfo Golf = new CarInfo()
        {
            Model = "e-Golf Auto",
            Year = 2020,
            InitialBatterySize = 35.8,
            Range = 144
        };

        List<CarInfo> Cars = new List<CarInfo>();

        public MainPage()
        {
            InitializeComponent();

            Cars.Add(Golf);
            Cars.Add(Audi);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
            int selected_car = 0;
            bool Cartrue = false;
            for(int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].Model == ModelEntry.Text)
                {
                    selected_car=i;

                    Form.IsVisible = false;
                    Form_Back.IsVisible = false;
                    DetailsForm.IsVisible = true;
                    Form_Details.IsVisible = true;
                    Back.IsVisible = true;
                    Cartrue = true;

                    double Depriciation = float.Parse(MilageEntry.Text) * 0.00046;
                    double Battery_Depriciation = Cars[selected_car].InitialBatterySize * ((100 - Depriciation) / 100);
                    double Range_Left = Cars[selected_car].Range * ((100 - Depriciation) / 100);
                    double Miles_Left = (100 - Depriciation) / 0.00046;

                    BatteryPrediction.Text = $"{Math.Round(Miles_Left, 2).ToString()}Miles";
                    BatteryHealth.Text = $"{(100 - Depriciation).ToString()}%";
                    BatteryDescription.Text = $"{Math.Round(Battery_Depriciation, 2)} / {Cars[selected_car].InitialBatterySize}kWh";
                    Range.Text = $"{Math.Round(Range_Left, 2)} / {Cars[selected_car].Range}Miles";
                }
            }
            if (Cartrue == false) 
            {
                DisplayAlert("Model is not recognised","OK","OK");
            }
            

        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Form.IsVisible = true;
            Form_Back.IsVisible = true;
            DetailsForm.IsVisible = false;
            Form_Details.IsVisible = false;
            Back.IsVisible = false;
        }
    }

}
