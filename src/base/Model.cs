using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMergeGame
{
    public class Model
    {
        public event EventHandler<ParentSettedEventArgs> ParentSettedEvent;
        private ModelNode2D _parent;
        public ModelNode2D Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                ParentSettedEvent.Invoke(this, new ParentSettedEventArgs(value));
            }
        }
    }
}
