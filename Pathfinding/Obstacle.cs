using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class Obstacle
    {
        public int StartCol { set; get; }
        public int StartRow { set; get; }
        public int OccupyCol { set; get; }
        public int OccupyRow { set; get; }

        private Map m_map;
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
                m_map = null;
            }
            
        }

    }
}
