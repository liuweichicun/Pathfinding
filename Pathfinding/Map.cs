using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class Map
    {
        public Cell[][] mapCells;
        public int ColCount { set; get; }
        public int RowCount { set; get; }
        public Map(int colCount,int rowCount)
        {
            ColCount = colCount;
            RowCount = rowCount;
            mapCells = new Cell[RowCount][];
            for (int i = 0; i < RowCount; i++)
            {
                mapCells[i] = new Cell[ColCount];
                for (int j = 0; j < ColCount; j++)
                {
                    mapCells[i][j] = new Cell();
                    mapCells[i][j].Row = i;
                    mapCells[i][j].Col = j;
                    mapCells[i][j].IsWalkable = true;
                }
            }
        }
    }
}
