using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CSVExport
    {
        Encoding encoding;
        string FilePath;
        //ListContainer listContainer;
        List<Offer> winningOfferList;
        public CSVExport(string filePath, string selector)
        {
            FilePath = filePath;
            //listContainer = ListContainer.GetInstance;
            winningOfferList = ListContainer.GetInstance.outputList;
            //winningOfferList = listContainer.outputList;
            encoding = Encoding.GetEncoding("iso-8859-1");

            switch (selector)
            {
                case "call":
                    ExportToCallList();
                    break;
                case "publish":
                    ExportToPublishList();
                    break;
            }
        }

        public void ExportToCallList()
        {
            CSVExportToCallList callList = new CSVExportToCallList();
            callList.CreateFile(encoding, FilePath, winningOfferList);
        }

        public void ExportToPublishList()
        {
            CSVExportToPublishList publishList = new CSVExportToPublishList();
            publishList.CreateFile(encoding, FilePath, winningOfferList);
        }
    }
}
