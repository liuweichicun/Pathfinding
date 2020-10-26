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
        public float F { get { return G + H; } }
        public float G;
        public float H;
        public Cell parent;
        public bool Equals(Cell other)
        {
            if (other.Col == Col && other.Row == Row)
                return true;
            else
                return false;
        }
    }
}
