/*
 *  author: Kele
 *  email: liuweichicun@outlook.com
 *  data: 2020/10/20
 */

using System;

namespace Pathfinding
{
    public class Point2D:IComparable<Point2D>,IEquatable<Point2D>
    {
        public float X { get { return m_x; } }
        private float m_x;
        public float Y { get { return m_y; } }
        private float m_y;
        public bool m_isWarkable;
        public float m_F, m_G, m_H; // m_F = m_G + m_H
        public Point2D Parent { set; get; }
        public Point2D(float x, float y)
        {
            m_x = x;
            m_y = y;
            m_isWarkable = true;
        }
        /// <summary>
        /// 变化路径点
        /// </summary>
        /// <param name="matrix">变换矩阵</param>
        /// <returns></returns>
        public Point2D Translation(Matrix2X2 matrix)
        {
            m_x = matrix.m_i.x * m_x + matrix.m_j.x * m_y;
            m_y = matrix.m_i.y * m_x + matrix.m_j.y * m_y;
            return this;
        }

        public override string ToString()
        {
            return "x:" + X + " y:" + Y;
        }

        public int CompareTo(Point2D other)
        {
            if (m_F > other.m_F) return 1;
            if (m_F == other.m_F) return 0;
            if (m_F < other.m_F) return -1;
            return -2;
        }

        public bool Equals(Point2D other)
        {
            if (other == null) return false;
            if (X == other.X && Y == other.Y)
                return true;
            else
                return false;
        }
    }
}
