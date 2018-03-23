using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Domain; //Move to viewmodel
using Logic;

namespace View
{
    /// <summary>
    /// Interaction logic for TilbudsOplysningerWindow.xaml
    /// </summary>
    public partial class TilbudsOplysningerWindow : Window
    {
        public TilbudsOplysningerWindow()
        {
            InitializeComponent();

            // For some reason the xaml does not want to set this as the data context.
            DataContext = new TilbudsOplysningerWindowViewModel();
        }
    }
}
