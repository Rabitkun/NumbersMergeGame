using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace NumbersMergeGame
{
    public class ModelNode2D : Node2D
    {
        public event EventHandler<ModelSettedEventArgs> ModelSettedEvent;
        private Model _model;
        public Model Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                ModelSettedEvent.Invoke(this, new ModelSettedEventArgs(value));
            }
        }
    }
}
