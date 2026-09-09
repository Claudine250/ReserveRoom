using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReserveRoom.Commands
{
    public abstract class CommandBase : ICommand
    {
        //listen to this event to know when button should be enabled/disabled
        public event EventHandler CanExecuteChanged;
        
        //controls whether button is enabled or disabled by default, can be overrode
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }
        //this is what will be executed when button is clicked on
        public abstract void Execute(object parameter);

        //will be used to re-evaluate can be changed based on states
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    }


