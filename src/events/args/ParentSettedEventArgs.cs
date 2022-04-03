using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMergeGame
{
    public class ParentSettedEventArgs : EventArgs
    {
        private ModelNode2D _parent;
        public ModelNode2D Parent
        {
            get { return _parent; }
        }

        public ParentSettedEventArgs(ModelNode2D parent)
        {
            _parent = parent;
        }
    }
}
