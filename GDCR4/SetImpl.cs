using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCR4
{
    public class SetImpl : ABoard
    {
        private ISet<Tuple<int, int>> data;

        public SetImpl(int xWidth, int yWidth) : base(xWidth, yWidth)
        {
            data = new HashSet<Tuple<int, int>>();
        }

        public override ABoard CreateEmptyBoard()
        {
            return new SetImpl(this.X, this.Y);
        }

        public override bool IsCellAlive(int x, int y)
        {
            return data.Contains(Tuple.Create(x,y));
        }

        public override void SetCell(int x, int y)
        {
            data.Add(Tuple.Create(x, y));
        }
    }
}
