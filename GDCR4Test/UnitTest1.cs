using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GDCR4;

namespace GDCR4Test
{
    [TestClass]
    public class UnitTest1
    {
        ABoard board;
        [TestInitialize]
        public void Init()
        {
            board = new ArrayBoardImpl(10, 10);
        }
        [TestMethod]
        public void CellDiesOfNoNeighbours()
        {
            board.SetCell(1, 1);
            var NewBoard = board.NextGen();
            Assert.IsFalse(NewBoard.IsCellAlive(1, 1));
        }
        [TestMethod]
        public void CellDiesOfOneNeighbour()
        {
            board.SetCell(1, 1);

            board.SetCell(1, 2);
            var NewBoard = board.NextGen();
            Assert.IsFalse(NewBoard.IsCellAlive(1, 1));
        }
        [TestMethod]
        public void CellSurviesBecauseOfTwo()
        {
            board.SetCell(1, 1);

            board.SetCell(1, 2);
            board.SetCell(0, 0);
            var NewBoard = board.NextGen();
            Assert.IsTrue(NewBoard.IsCellAlive(1, 1));
        }
        [TestMethod]
        public void CellSurviesBecauseofThree()
        {
            board.SetCell(9, 9);

            board.SetCell(0, 0);
            board.SetCell(9, 0);
            board.SetCell(0, 9);
            var NewBoard = board.NextGen();
            Assert.IsTrue(NewBoard.IsCellAlive(9, 9));
        }
        [TestMethod]
        public void CellDiesBecauseOfFour()
        {
            board.SetCell(9, 9);

            board.SetCell(0, 0);
            board.SetCell(9, 0);
            board.SetCell(0, 9);
            board.SetCell(8, 9);

            var NewBoard = board.NextGen();
            Assert.IsFalse(NewBoard.IsCellAlive(9, 9));
        }
        [TestMethod]
        public void CellBirth()
        {
            board.SetCell(0, 0);
            board.SetCell(9, 0);
            board.SetCell(0, 9);

            var NewBoard = board.NextGen();
            Assert.IsTrue(NewBoard.IsCellAlive(9, 9));
        }
    }
}
