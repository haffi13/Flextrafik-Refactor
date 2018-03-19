using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace View
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        public RelayCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };   //--Seems to work without the sender..is never used in current solution
        //only the CanExecute and Execute are used.

        public bool CanExecute(object parameter) //setja check hérna seinna meir...mvvm exercise 2 er með þessi checks held ég...
        {

            //ef það er ekkert inní search field return false, else return true...væri líka hægt að gera convertible check t.d. á id's
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
