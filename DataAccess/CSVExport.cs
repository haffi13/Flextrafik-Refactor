using Domain;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class CSVExport
    {
        Encoding encoding;
        string FilePath;
        List<Offer> winningOfferList;
        public CSVExport(string filePath, string selector)
        {
            FilePath = filePath;
            winningOfferList = ListContainer.GetInstance.outputList;
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
