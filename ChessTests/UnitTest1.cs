using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Classes;

namespace ChessTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Board board = new Board();
            board.Setup(Chess.GameType.Classic);
            
        }
    }
}
