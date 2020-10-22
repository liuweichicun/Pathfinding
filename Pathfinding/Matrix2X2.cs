/*
 *  author: Kele
 *  email: liuweichicun@outlook.com
 *  data: 2020/10/20
 */

namespace Pathfinding
{
    public class Matrix2X2
    {
        public Vector2D m_i;
        public Vector2D m_j;
        public Matrix2X2() { }
        public Matrix2X2(float i_x, float i_y, float j_x, float j_y)
        {
            m_i = new Vector2D(i_x, i_y);
            m_j = new Vector2D(j_x, j_y);
        }
    }
}
