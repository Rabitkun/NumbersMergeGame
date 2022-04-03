using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace NumbersMergeGame
{
    public class CellModel : Model
    {
        public event EventHandler<ValueChangedEventArgs> ValueChangedEvent;
        private int _value = 2;
        private int _row;
        private int _column;
        public int Row
        {
            get { return _row; }
        }
        public int Column
        {
            get { return _column; }
        }
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > 0 && value % 2 == 0 )
                    _value = value;
                else
                    throw new ArgumentException("The number must be even and positive!");

                ValueChangedEvent.Invoke(this, new ValueChangedEventArgs(value));
            }
        }

        public CellModel(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public void GradeCellToNextValue()
        {
            Value = Value * 2;
        }
    }
}
