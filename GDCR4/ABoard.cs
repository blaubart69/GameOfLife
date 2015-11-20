using System;

namespace GDCR4
{
    public abstract class ABoard
    {
        private enum DIRECTION
        {
            BACK = -1,
            FORWARD = 1
        }

        private readonly int X;
        private readonly int Y;

        public ABoard(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public abstract bool IsCellAlive(int x, int y);
        public abstract void SetCell(int x, int y);
        public abstract ABoard CreateEmptyBoard(int x, int y);

        public ABoard NextGen()
        {
            ABoard NewBoard = CreateEmptyBoard(X, Y);

            for ( int x=0; x < X; x++)
            {
                for ( int y=0; y < Y; y++ )
                {
                    int countNeighbours = getCountOfNeighbours(x, y);
                    if ( IsCellAlive(x,y) )
                    {
                        if (countNeighbours == 2 || countNeighbours == 3)
                        {
                            NewBoard.SetCell(x, y);
                        }
                    }
                    else
                    {
                        if ( countNeighbours == 3 )
                        {
                            NewBoard.SetCell(x, y);
                        }
                    }
                }
            }

            return NewBoard;
        }
        private static int getWrapAroundIndex(int idx, DIRECTION direction, int maxIndex)
        {
            if ( idx == 0 && direction == DIRECTION.BACK )
            {
                return maxIndex;
            }
            else if ( idx == maxIndex && direction == DIRECTION.FORWARD )
            {
                return 0;
            }
            else
            {
                return idx + (int)direction;
            }
        }
        private int getCountOfNeighbours(int x, int y)
        {
            int xLeft  = getWrapAroundIndex(x, DIRECTION.BACK,    X - 1);
            int xRight = getWrapAroundIndex(x, DIRECTION.FORWARD, X - 1);
            int yUp    = getWrapAroundIndex(y, DIRECTION.BACK,    Y - 1);
            int yDown  = getWrapAroundIndex(y, DIRECTION.FORWARD, Y - 1);

            int count = 0;
            count += IsCellAlive(xLeft , yUp  ) ? 1 : 0;
            count += IsCellAlive(x     , yUp  ) ? 1 : 0;
            count += IsCellAlive(xRight, yUp  ) ? 1 : 0;

            count += IsCellAlive(xLeft , y    ) ? 1 : 0;
            count += IsCellAlive(xRight, y    ) ? 1 : 0;

            count += IsCellAlive(xLeft , yDown) ? 1 : 0;
            count += IsCellAlive(x     , yDown) ? 1 : 0;
            count += IsCellAlive(xRight, yDown) ? 1 : 0;

            return count;
        }
    }
}