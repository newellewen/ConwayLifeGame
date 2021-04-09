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

            cells.Add(new Cell(2, 3, true));
            cells.Add(new Cell(2, 4, true));
            cells.Add(new Cell(2, 5, true));
            cells.Add(new Cell(2, 6, true));
            cells.Add(new Cell(2, 7, true));
            cells.Add(new Cell(3, 3, true));
            cells.Add(new Cell(3, 4, true));
            cells.Add(new Cell(3, 5, true));

            GameController game = new GameController(cells);

            game.PrintState();
            game.Go();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            game.PrintState();

        }
    }
}
