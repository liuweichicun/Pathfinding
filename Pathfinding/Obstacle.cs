/*
 *  author: Kele
 *  email: liuweichicun@outlook.com
 *  data: 2020/10/20
 */

using System;

namespace Pathfinding
{
    public class Obstacle
    {
        public float m_startPosX;
        public float m_startPoxY;

        protected int m_startCol;
        protected int m_startRow;

        public int OccupyX { get; set; }
        public int OccupyY { get; set; }

        MapPoints m_mapPoints;

        public void SettleInMapPoints(MapPoints mapPoints)
        {
            m_mapPoints = mapPoints;
            m_mapPoints.RowAndColInMapPoint(m_startPosX, m_startPoxY, out m_startCol, out m_startRow);
            for (int i = 0; i < OccupyY; i++)
            {
                for (int j = 0; j < OccupyX; j++)
                {
                    m_mapPoints.m_mapPoints[m_startRow + i][m_startCol + j].m_isWarkable = false;
                }
            }
        }
        public void UnSettleInMapPoints()
        {
            for (int i = 0; i < OccupyY; i++)
            {
                for (int j = 0; j < OccupyX; j++)
                {
                    m_mapPoints.m_mapPoints[m_startRow + i][m_startCol + j].m_isWarkable = true;
                }
            }
            m_mapPoints = null;
        }
    }
}
