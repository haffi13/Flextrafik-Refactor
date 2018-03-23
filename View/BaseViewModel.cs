using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace View
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Must be a generic way to open a file dialog. OpenFileDialog uses Microsoft.Win32
        public string PickCSVFile()
        {
            OpenFileDialog openFileDialog;
            string filename = "Ingen fil er valgt";
            openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "CVS filer (*.csv)|*.csv|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                return filename;
            }
            return filename;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
