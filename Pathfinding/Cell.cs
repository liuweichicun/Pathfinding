using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    /// <summary>
    /// 寻路系统中的Cell
    /// </summary>
    [Serializable]
    public class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// 当前Cell的行下标
        /// </summary>
        public int Col;
        /// <summary>
        /// 当前Cell的列下标
        /// </summary>
        public int Row;
        /// <summary>
        /// 当前Cell是否可走
        /// </summary>
        public bool IsWalkable { set; get; }
        internal float F { get { return m_G + m_H; } }
        internal float m_G;
        internal float m_H;
        /// <summary>
        /// 上一个节点
        /// </summary>
        public Cell Parent { get; set; }

        /// <summary>
        /// default custructor
        /// </summary>
        public Cell()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public Cell(int col,int row)
        {
            Col = col;
            Row = row;
        }

        /// <summary>
        /// 判等函数
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Cell other)
        {
            if (other.Col == Col && other.Row == Row)
                return true;
            else
                return false;
        }
    }
}
