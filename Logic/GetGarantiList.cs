using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Domain;

namespace Logic
{
    public class GetGarantiList
    {
        ImportCSV importCSV;
        public GetGarantiList()
        {
            importCSV = new ImportCSV();
        }
        public ObservableCollection<GarantiPrisAttributes> GarantiList(string filepath)
        {
            return importCSV.AttributeList(filepath);
        }
    }
}
