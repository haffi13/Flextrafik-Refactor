using System;
using System.ComponentModel;
using System.Windows;
using Domain;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Just kept this here as we're opening up another window
        private void tilbudsOplysningerBtn_Click(object sender, RoutedEventArgs e)
        {
            // Should not do dis!
            TilbudsOplysningerWindow tow = new TilbudsOplysningerWindow();
            tow.Show();
        }
    }
}
