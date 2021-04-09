using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using ConwayLifeGame.Models;

namespace ConwayLifeGame.Controllers
{
    public class GameController
    {
        private List<Cell> cells;
        Task EvaluateCells;
        public static void Iterate()
        {

        }

        private Task CheckGrid()
        {
            return Task.Factory.StartNew(delegate ()
            {
                foreach (Cell cell in cells)
                {
                    int liveNeighbours = cell.neighbours.Count();
                    if (cell.IsAlive())
                    {
                        if (liveNeighbours < 2 || liveNeighbours > 3)
                        {
                            cell.Kill();
                        }
                    } else
                    {
                        if (liveNeighbours == 3)
                        {
                            cell.Resurrect();
                        }
                    }

                }
            });
        }

    }
}
