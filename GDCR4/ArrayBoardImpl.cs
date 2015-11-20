using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCR4
{
    public class ArrayBoardImpl : ABoard
    {
        private bool[,] data;

        public ArrayBoardImpl(int x, int y) : base(x,y)
        {
            data = new bool[x,y];
        }
        public override bool IsCellAlive(int x, int y)
        {
            return data[x, y];
        }
        public override void SetCell(int x, int y)
        {
            data[x, y] = true;
        }
        public override ABoard CreateEmptyBoard()
        {
            return new ArrayBoardImpl(X,Y);
        }
    }
}
