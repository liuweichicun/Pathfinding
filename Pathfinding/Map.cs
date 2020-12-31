namespace Pathfinding
{
    /// <summary>
    /// 寻路系统中的Map
    /// </summary>
    public class Map
    {
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
        }


        /// <summary>
        /// 将障碍物注册到 NavMap 中
        /// </summary>
        /// <param name="obs">要注册的障碍物</param>
        public void RegisteObstacleInNavMap(Obstacle obs)
        {
            ObstacleStateChage(obs, false);
        }

        
        /// <summary>
        /// 将障碍物从 NavMap 中取消注册
        /// </summary>
        /// <param name="obs">要取消注册的障碍物</param>
        public void UnRegisteObstacleInNavMap (Obstacle obs)
        {
            ObstacleStateChage(obs, true);
        }

        private void ObstacleStateChage(Obstacle obs,bool state)
        {
            for (int i = obs.StartRow; i < obs.StartRow + obs.OccupyRow; i++)
            {
                for (int j = obs.StartCol; j < obs.StartCol + obs.OccupyCol; j++)
                {
                    mapCells[i][j].IsWalkable = state;
                }
            }
        }
    }
}
