using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Logic;

namespace View
{
    public class TilbudsOplysningerWindowViewModel : BaseViewModel
    {
        public ObservableCollection<GarantiPrisAttributes> GarantiList { get; set; }
        ObservableCollection<GarantiPrisAttributes> temp;
        GetGarantiList getGarantiList;
        MainWindowViewModel mwvm;
        TypeOfDaysEachYear typeOfDays;
        GarantiPrisValueConverter valueConverter;

        public TilbudsOplysningerWindowViewModel()
        {
            mwvm = new MainWindowViewModel();
            getGarantiList = new GetGarantiList();
            typeOfDays = new TypeOfDaysEachYear();
            valueConverter = new GarantiPrisValueConverter();
            string filepath = mwvm.ChooseCSVFile();
            temp = getGarantiList.GarantiList(filepath);
            CalculateKontraktsum();
            
        }

        // Populate GarantiList with correct kontraktsum
        public void CalculateKontraktsum()
        {
            GarantiList = new ObservableCollection<GarantiPrisAttributes>();
            int[] days = typeOfDays.GetNumberOfDays();
            int weekdays = days[0];
            int weekenddays = days[1];

            foreach (var item in temp)
            {
                int weekdayGarantiTimer = valueConverter.GetNumberOfHours(item.GarantiPeriodeHverdag);
                int weekenddayGarantiTimer = valueConverter.GetNumberOfHours(item.GarantiPeriodeWeekend);
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
