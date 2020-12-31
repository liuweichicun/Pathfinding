namespace Pathfinding
{
    /// <summary>
    /// 寻路系统中放置后不可行走的物体
    /// </summary>
    public class Obstacle
    {
        /// <summary>
        /// 起始行下标
        /// </summary>
        public int StartCol { set; get; }
        /// <summary>
        /// 起始列下标
        /// </summary>
        public int StartRow { set; get; }
        /// <summary>
        /// 行占据数量
        /// </summary>
        public int OccupyCol { set; get; }
        /// <summary>
        /// 列占据数量
        /// </summary>
        public int OccupyRow { set; get; }

        private Map m_map;
        /// <summary>
        /// 在地图中注册位置，注册后寻路系统中的Cell标记为不可行走
        /// </summary>
        /// <param name="map">要注册的地图</param>
        public void RegisterInMap(Map map)
        {        
            if(map != null)
            {
                m_map = map;
                for (int i = StartRow; i < StartRow + OccupyRow && StartRow + OccupyRow <map.mapCells.Length; i++)
                {
                    for (int j = StartCol; j < StartCol + OccupyCol && StartCol + OccupyCol < map.mapCells.Length; j++)
                    {
                        map.mapCells[i][j].IsWalkable = false;
                    }
                }
            }
        }
        /// <summary>
        /// 在地图中取消注册，取消注册后寻路系统中的Cell标记为可行走
        /// </summary>
        public void UnRegisterInMap()
        {
            if (m_map != null)
            {
                for (int i = StartRow; i < StartRow + OccupyRow && StartRow + OccupyRow < m_map.mapCells.Length; i++)
                {
                    for (int j = StartCol; j < StartCol + OccupyCol && StartCol + OccupyCol < m_map.mapCells.Length; j++)
                    {
                        m_map.mapCells[i][j].IsWalkable = true;
                    }
                }
            }
        }

    }
}
