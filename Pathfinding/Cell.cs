using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    /// <summary>
    /// 寻路系统中的Cell
    /// </summary>
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// 当前Cell的行下标
        /// </summary>
        public int Col { set; get; }
        /// <summary>
        /// 当前Cell的列下标
        /// </summary>
        public int Row { set; get; }
        /// <summary>
        /// 当前Cell是否可走
        /// </summary>
        public bool IsWalkable { set; get; }
        public float F { get { return m_G + m_H; } }
        public float m_G;
        public float m_H;
        /// <summary>
        /// 上一个节点
        /// </summary>
        public Cell Parent { get; set; }
        public bool Equals(Cell other)
        {
            if (other.Col == Col && other.Row == Row)
                return true;
            else
                return false;
        }
    }
}
