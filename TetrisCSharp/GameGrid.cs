﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace TetrisCSharp
{
    public class GameGrid
    {
        private readonly int[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public SoundPlayer WinSound { get; private set; }
        public SoundPlayer Music { get; private set; }
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
            //WinSound = new SoundPlayer();
            //Music = new SoundPlayer();
            //this.WinSound.SoundLocation = @"C:\Users\Tarzan\Desktop\CVs\Projects\TetrisCSharp\TetrisCSharp\bin\Debug\cute-level-up-2-189851.wav";
            //this.Music.SoundLocation = @"C:\Users\Tarzan\Desktop\CVs\Projects\TetrisCSharp\TetrisCSharp\bin\Debug\tetris-theme-korobeiniki.wav";
            //this.Music.PlayLooping();
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }
        
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for (int c =0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearRow(int r)

        {
            //this.WinSound.Play();
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
            
            
        }


        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
