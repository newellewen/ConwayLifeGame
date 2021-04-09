using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConwayLifeGame.Models;

namespace ConwayLifeGame.Controllers
{
    public class GameController
    {
        private List<Cell> cells;

        public void Init(List<Cell> seed)
        {
            cells = seed;
        }

        public void Start()
        {
            try
            {
                if (cells.Where(cell => cell.alive).Count() == 0)
                {
                    throw new Exception("You must start with at least one living cell.");
                }


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


    }
}
