using Logic;
using Microsoft.Win32;
using System.Windows;
using System;
using Domain;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace View
{
    public class MainWindowViewModel : BaseViewModel
    {
        //As of now I allow the ViewModel to use System.Windows to show message boxes...
        //Have yet to find a good way to do this correctly...

        IOController iOController;
        SelectionController selectionController;
        List<Offer> Results;

        private ObservableCollection<Offer> outputList;
        private string masterDataFilePath;
        private string routeNumberFilePath;
        private bool importDone;
        private bool selectionDone;
        private ListContainer container;
        
        public RelayCommand MasterDataFilePathSelect { get; set; }
        public RelayCommand RouteNumberFilePathSelect { get; set; }
        public RelayCommand Import { get; set; }
        public RelayCommand StartSelection { get; set; }
        public RelayCommand SavePublish { get; set; }
        public RelayCommand SaveCall { get; set; }

        public ListContainer Container
        {
            get { return container; }
            set { container = value; }
        }

        public ObservableCollection<Offer> OutputList
        {
            get { return outputList; }
            set
            {
                outputList = value;
                OnPropertyChanged();
            }
        }

        public bool ImportDone
        {
            get { return importDone; }
            set
            {
                importDone = value;
                OnPropertyChanged();
            }
        }

        public bool SelectionDone
        {
            get { return selectionDone; }
            set
            {
                selectionDone = value;
                OnPropertyChanged();
            }
        }

        public string MasterDataFilePath
        {
            get { return masterDataFilePath; }
            set
            {
                masterDataFilePath = value;
                OnPropertyChanged();
            }
        }

        public string RouteNumberFilePath
        {
            get { return routeNumberFilePath; }
            set
            {
                routeNumberFilePath = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            iOController = new IOController();
            selectionController = new SelectionController();
            ImportDone = false;

            this.MasterDataFilePathSelect = new RelayCommand(ExecuteMasterDataFilePathSelect);
            this.RouteNumberFilePathSelect = new RelayCommand(ExecuteRouteNumberFilePathSelect);
            this.Import = new RelayCommand(ExecuteImport);
            this.StartSelection = new RelayCommand(ExecuteStartSelection);
            this.SavePublish = new RelayCommand(ExecuteSavePublish);
            this.SaveCall = new RelayCommand(ExecuteSaveCall);
        }

        #region ExecuteClicksRegion
        // PickCSVFile() is inherited from BaseViewModel
        private void ExecuteMasterDataFilePathSelect()
        {
            MasterDataFilePath = PickCSVFile();
        }

        private void ExecuteRouteNumberFilePathSelect()
        {
            RouteNumberFilePath = PickCSVFile();
        }

        private void ExecuteImport()
        {
            try
            {
                if (MasterDataFilePath == string.Empty || RouteNumberFilePath == string.Empty)
                {
                    MessageBox.Show("Vælg venligst begge filer inden import startes");
                }
                else if ((MasterDataFilePath == string.Empty && RouteNumberFilePath == string.Empty))
                {
                    MessageBox.Show("Vælg venligst filerne inden import startes");
                }
                else
                {
                    ImportCSV(MasterDataFilePath, RouteNumberFilePath);
                    MessageBox.Show("Filerne er nu importeret");
                    ImportDone = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ExecuteStartSelection() //gæti verið að þetta virki ekki...þarf að prufa þetta
        {
            try
            {
                InitializeSelection();
                Container = ListContainer.GetInstance;
                Results = Container.outputList.OrderBy(x => x.UserID).ToList();
                OutputList = new ObservableCollection<Offer>();
                if(Results != null)
                {
                    foreach (var item in Results)
                    {
                        OutputList.Add(item);
                    }
                }
                MessageBox.Show("Udvælgelsen er nu færdig");
            }
            catch (Exception x)
            {
                PromptWindow promptWindow = new PromptWindow(x.Message);
                promptWindow.Show();
            }
        }

        private void ExecuteSavePublish()
        {
            try
            {
                SaveCSV("publish");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void ExecuteSaveCall()
        {
            try
            {
                SaveCSV("call");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        #endregion

        public void ImportCSV(string masterDataFilepath, string routeNumberFilepath)
        {
            iOController.InitializeImport(masterDataFilepath, routeNumberFilepath);
        }
        
        public void SaveCSV(string selector)
        {
            if (SelectionDone == true)
            {
                SaveFileDialog saveDlg = new SaveFileDialog
                {
                    Filter = "CSV filer (*.csv)|*.csv|All files (*.*)|*.*",
                    InitialDirectory = @"C:\%USERNAME%\"
                };
                saveDlg.ShowDialog();

                string path = saveDlg.FileName;

                switch (selector)
                {
                    case "call":
                        iOController.InitializeExportToCallingList(path, selector);
                        break;
                    case "publish":
                        iOController.InitializeExportToPublishList(path, selector);
                        break;
                    default:
                        //error
                        break;
                }
                MessageBox.Show("Filen er gemt.");
            }
            else
            {
                MessageBox.Show("Du har ikke udvalgt vinderne endnu.. Kør Udvælgelse først!");
            }
        }

        public void InitializeSelection()
        {
            if (ImportDone)
            {
                SelectionDone = true;
            }
            else
            {
                MessageBox.Show("Du skal importere filerne først.");
            }
            selectionController.SelectWinners();
        }
    }
}
