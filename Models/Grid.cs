using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayLifeGame.Models
{
    public class Grid
    {
        private List<Cell> cells;

        public Grid(int rows, int columns)
        {
            Init(rows, columns);
        }

        private void Init(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new Exception("You must have at least 1 row and 1 column.");
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; i < columns; i++)
                {
                    cells.Add(new Cell(i, j));
                }
            }

        }
    }
}
