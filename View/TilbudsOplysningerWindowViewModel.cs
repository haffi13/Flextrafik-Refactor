using System;
using System.Collections.ObjectModel;
using Domain;
using Logic;

//By using the dialog boxes we are breaking MVVM.
namespace View
{
    public class TilbudsOplysningerWindowViewModel : BaseViewModel
    {
        // ListView in xaml is bound to this.
        public ObservableCollection<GarantiPrisAttributes> GarantiList { get; set; }
        
        GetGarantiList getGarantiList;
        TypeOfDaysEachYear typeOfDays;
        GarantiPrisValueConverter valueConverter;

        public TilbudsOplysningerWindowViewModel()
        {
            getGarantiList = new GetGarantiList();
            typeOfDays = new TypeOfDaysEachYear();
            valueConverter = new GarantiPrisValueConverter();
            string filepath = PickCSVFile(); //PickCSVFile is inherited from BaseViewModel
            ObservableCollection<GarantiPrisAttributes>temp = getGarantiList.GarantiList(filepath);
            CalculateKontraktsum(temp);            
        }

        // Populate GarantiList with correct kontraktsum
        public void CalculateKontraktsum(ObservableCollection<GarantiPrisAttributes> temp)
        {
            GarantiList = new ObservableCollection<GarantiPrisAttributes>();
            int[] days = typeOfDays.GetNumberOfDays();
            int weekdays = days[0];
            int weekenddays = days[1];

            // We have not implemented the ferie uger but we have a method which gives us the number of weeks
            // the car must be on a vacation. Also haven't implemented the tvungne lukkedage.
            foreach (var item in temp)
            {
                int weekdayGarantiTimer = valueConverter.NumberOfHours(item.GarantiPeriodeHverdag);
                int weekenddayGarantiTimer = valueConverter.NumberOfHours(item.GarantiPeriodeWeekend);
                int pris = Convert.ToInt32(item.Timepris);

                int yearlyCost = ((weekdayGarantiTimer * weekdays)
                               + (weekenddayGarantiTimer * weekenddays))
                               * pris;
                item.Timepris = yearlyCost.ToString();
                GarantiList.Add(item);
            }
        }
    }
}
