using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain;
using CsvHelper; // Nuget packet
using System.Collections.ObjectModel;

namespace DataAccess
{
    // Our own CSV Import class. 
    // It uses CsvHelper library instead of importing data manually from the CSV file.
    public class ImportCSV
    {
        // Path to the CSV file.
        //string path = @"C:\Users\hafst\Documents\00--Skóli\00EAL\2017 - 2018\00--Flextrafik2\Fynbus\TestPseudoData.csv";

        public ObservableCollection<GarantiPrisAttributes> AttributeList(string path)
        {
            List<GarantiPrisAttributes> gpa = new List<GarantiPrisAttributes>();
            ObservableCollection<GarantiPrisAttributes> ret = new ObservableCollection<GarantiPrisAttributes>();

            using (TextReader fileReader = File.OpenText(path))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.Encoding = Encoding.UTF8;

                gpa = csv.GetRecords<GarantiPrisAttributes>().ToList<GarantiPrisAttributes>();
            }

            // Could also just work with lists here and convert it into ObservableData in the ViewModel.

            // Adds the list items to the Observable collection.
            foreach (var item in gpa)
            {
                ret.Add(item);
            }
            return ret;
        }
    }
}
