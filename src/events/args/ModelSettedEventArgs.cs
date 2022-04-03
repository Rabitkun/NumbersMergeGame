using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMergeGame
{
    public class ModelSettedEventArgs : EventArgs
    {
        private Model _model;
        public Model Model
        {
            get { return _model; }
        }

        public ModelSettedEventArgs(Model model)
        {
            _model = model;
        }
    }
}
