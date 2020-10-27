using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class Cell : IEquatable<Cell>
    {
        public int Col { set; get; }
        public int Row { set; get; }
        public bool IsWalkable { set; get; }
        public float F { get { return m_G + m_H; } }
        public float m_G;
        public float m_H;
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
