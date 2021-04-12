using System.Collections.Generic;
using ConwayLifeGame.Controllers;
using ConwayLifeGame.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwayLifeGameTests
{
    [TestClass]
    public class GameControllerTest
    {
        List<Cell> seed1 = new List<Cell>
        {
            new Cell(2, 2, true),
            new Cell(2, 3, true),
            new Cell(3, 3, true),
            new Cell(4, 3, true)
        };

        List<Cell> result1 = new List<Cell>
        {
            new Cell(2, 2, true),
            new Cell(2, 3, true),
            new Cell(3, 3, true),
            new Cell(3, 4, true)
        };

        List<Cell> result2 = new List<Cell>
        {
            new Cell(2, 2, true),
            new Cell(2, 3, true),
            new Cell(2, 4, true),
            new Cell(3, 2, true),
            new Cell(3, 3, true),
            new Cell(3, 4, true)
        };

        List<Cell> result3 = new List<Cell>
        {
            new Cell(1, 3, true),
            new Cell(2, 2, true),
            new Cell(2, 4, true),
            new Cell(3, 2, true),
            new Cell(3, 4, true),
            new Cell(4, 3, true)
        };


        [TestMethod]
        public void TestGo()
        {
            GameController game = new GameController(seed1);
            game.Go();
            CollectionAssert.AreEquivalent(game.GetLivingCells(), result1);
            game.Go();
            CollectionAssert.AreEquivalent(game.GetLivingCells(), result2);
            game.Go();
            CollectionAssert.AreEquivalent(game.GetLivingCells(), result3);
        }
    }
}
