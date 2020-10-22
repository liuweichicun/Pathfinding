/*
 *  author: Kele
 *  email: liuweichicun@outlook.com
 *  data: 2020/10/20
 */
using System.Collections.Generic;

namespace Pathfinding
{
    public class Agent
    {
        public float m_posX;
        public float m_posY;

        public List<Point2D> pathPoints = new List<Point2D>();

        public int Col { get { return col; } }
        private int col;
        public int Row { get { return row; } }
        private int row;

        /// <summary>
        /// 注册Agent所处位置，在每次开始寻路前注册
        /// </summary>
        /// <param name="mapPoints"></param>
        public void RegisterAgentInMapPoints(MapPoints mapPoints)
        {
            mapPoints.RowAndColInMapPoint(m_posX, m_posY, out col, out row);
        }
        public void FindPathPoints()
        {

        }
    }
}
