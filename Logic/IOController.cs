using System.Collections.Generic;
using Domain;
using DataAccess;

namespace Logic
{
    public class IOController
    {
        List<RouteNumber> routeNumberList;
        List<Contractor> contractorList;

        public IOController()
        {
            routeNumberList = new List<RouteNumber>();
        }
       
        public void InitializeExportToPublishList(string filePath, string selector)
        {
            CSVExport ExportToPublishList = new CSVExport(filePath, selector);
            //ExportToPublishList.CreateFile(); 
        }
        public void InitializeExportToCallingList(string filePath, string selector)
        {
            CSVExport ExportCallList = new CSVExport(filePath, selector);
            //ExportCallList.CreateFile();
        }
        public void InitializeImport(string masterDataFilepath, string routeNumberFilepath)
        {
            CSVImport csvImport = new CSVImport();
            csvImport.ImportContractors(masterDataFilepath);
            csvImport.ImportRouteNumbers();
            csvImport.ImportOffers(routeNumberFilepath);
            contractorList = csvImport.SendContractorListToContainer();
            routeNumberList = csvImport.SendRouteNumberListToContainer();
            ListContainer listContainer = ListContainer.GetInstance;
            listContainer.GetLists(routeNumberList, contractorList);
        }
    }
}
