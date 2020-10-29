using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pathfinding
{
    /// <summary>
    /// 寻路系统中的Map
    /// </summary>
    public class Map
    {
        /// <summary>
        /// 寻路系统地图静态实例
        /// </summary>
        public static Map Instance;
        public static Map GetMapInstance()
        {
            if (Instance == null)
                throw new Exception("init first!");
            else
                return Instance;
        }

        /// <summary>
        /// 寻路系统中地图Cell
        /// </summary>
        public Cell[][] mapCells;
        /// <summary>
        /// 初始化寻路系统中地图要指定的行
        /// </summary>
        public int ColCount { set; get; }
        /// <summary>
        /// 初始化寻路系统中地图要指定的列
        /// </summary>
        public int RowCount { set; get; }
        /// <summary>
        /// 初始化寻路系统中的地图
        /// </summary>
        /// <param name="colCount">初始化的行数</param>
        /// <param name="rowCount">初始化的列数</param>
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
            Instance = this;
        }
    }
}
