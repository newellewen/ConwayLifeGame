﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayLifeGame.Models
{
    public class Cell
    {
        private bool alive;
        private int x;
        private int y;
        private List<Cell> neighbours;

        public Cell(int _x, int _y)
        {
            x = _x;
            y = _y;
            alive = false;
        }                   
        
        public bool IsAlive()
        {
            return alive;
        }
    }
}
