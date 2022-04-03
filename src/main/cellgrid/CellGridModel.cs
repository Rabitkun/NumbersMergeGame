using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMergeGame
{
    public class CellGridModel : Model
    {
        private int _rows;
        private int _columns;
        private List<CellModel> _cells = new List<CellModel>();
        public IEnumerable<CellModel> Cells
        {
            get { return _cells; }
        }
    }
}
