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

        public event EventHandler CanExecuteChanged = (sender, e) => { };
        //only the CanExecute and Execute are used.

        // Could this method be used to make StartSelection available in MainWindow.
        public bool CanExecute(object parameter) 
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
