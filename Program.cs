using System;
using System.Linq;
using System.Collections.Generic;
using ConwayLifeGame.Controllers;
using ConwayLifeGame.Models;


namespace ConwayLifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cell> cells = new List<Cell>();

            cells.Add(new Cell(2, 4, true));
            cells.Add(new Cell(2, 5, true));
            cells.Add(new Cell(3, 5, true));
            cells.Add(new Cell(4, 3, true));
            cells.Add(new Cell(5, 3, true));
            cells.Add(new Cell(5, 4, true));

            GameController game = new GameController(cells);

            game.PrintState();

        }
    }
}
