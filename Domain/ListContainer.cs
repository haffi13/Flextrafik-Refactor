using System.Collections.Generic;

namespace Domain
{
    public sealed class ListContainer
    {
        // The class is instanciated here when any member of the class is referenced
        private static readonly ListContainer instance = new ListContainer();

        public List<RouteNumber> routeNumberList;
        public List<Contractor> contractorList;
        public List<Offer> outputList;
        public List<Offer> conflictList;

        private ListContainer()
        {
            routeNumberList = new List<RouteNumber>(); 
            contractorList = new List<Contractor>();
            outputList = new List<Offer>();
            conflictList = new List<Offer>();
        }

        // When other classes want to use ListContainer they get the instance from here.
        public static ListContainer GetInstance
        {
            get
            {
                return instance;
            }
        }
        public void GetLists(List<RouteNumber> routeNumberList, List<Contractor> contractorList)
        {
            this.routeNumberList = routeNumberList;
            this.contractorList = contractorList;
        }
    }
}
