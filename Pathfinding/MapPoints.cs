/*
 *  author: Kele
 *  email: liuweichicun@outlook.com
 *  data: 2020/10/20
 */

namespace Pathfinding
{
    
    public class MapPoints
    {
        public Point2D[][] m_mapPoints;
        protected float m_pivotX;
        protected float m_pivotY;
        public float StepX { get; }
        public float StepY { get; }
        /// <summary>
        /// 创建地图寻路点
        /// </summary>
        /// <param name="pivotX">中心x坐标</param>
        /// <param name="pivotY">中心y坐标</param>
        /// <param name="stepX">x方向步长</param>
        /// <param name="stepY">y方向步长</param>
        /// <param name="xHalfCount">x方向不含定点半轴增加数量(路径点数增加2n + 1)</param>
        /// <param name="yHalfCount">y方向不含中心点半轴增加数量(路径点数增加 2n + 1)</param>
        public MapPoints(float pivotX, float pivotY, float stepX, float stepY, int xHalfCount, int yHalfCount)
        {
            m_pivotX = pivotX;
            m_pivotY = pivotY;
            int xCount = 2 * xHalfCount + 1;
            int yCount = 2 * yHalfCount + 1;
            StepX = stepX;
            StepY = stepY;
            m_mapPoints = new Point2D[yCount][];
            for (int i = 0; i < yCount; i++)
            {
                m_mapPoints[i] = new Point2D[xCount];
                for (int j = 0; j < xCount; j++)
                {
                    m_mapPoints[i][j] = new Point2D(m_pivotX + (j - xHalfCount) * stepX, m_pivotY + (yHalfCount - i) * stepY);
                }
            }
        }

        /// <summary>
        /// 变换地图寻路点
        /// </summary>
        /// <param name="matrix">变换矩阵</param>
        public void Translation(Matrix2X2 matrix)
        {
            for (int i = 0; i < m_mapPoints.Length; i++)
            {
                for (int j = 0; j < m_mapPoints[i].Length; j++)
                {
                    m_mapPoints[i][j] = m_mapPoints[i][j].Translation(matrix);
                }
            }
        }

        public void RowAndColInMapPoint(float posX,float posY,out int col,out int row)
        {
            bool xIsCertain = false;
            col = 0;
            row = 0;
            for (int i = 0; i < m_mapPoints.Length; i++)
            {
                if (!xIsCertain)
                {
                    for (int j = 0; j < m_mapPoints[i].Length; j++)
                    {
                        if (posX <= m_mapPoints[i][j].X + StepX / 2)
                        {
                            col = j;
                            break;
                        }
                        else continue;
                    }
                }
                if (posY >= m_mapPoints[i][col].Y - StepY / 2)
                {
                    row = i;
                    break;
                }
            }
        }
    }
}
