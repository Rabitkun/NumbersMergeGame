using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMergeGame
{
    public class ValueChangedEventArgs : EventArgs
    {
        private int _newValue;
        public int NewValue
        {
            get { return _newValue; }
        }

        public ValueChangedEventArgs(int newValue)
        {
            _newValue = newValue;
        }
    }
}
