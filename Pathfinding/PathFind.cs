using System;
using System.Collections.Generic;
using System.Linq;
namespace Pathfinding
{
    public class Pathfind
    {
        private List<Point2D> m_openList = new List<Point2D>();
        private List<Point2D> m_closeList = new List<Point2D>();
        private MapPoints m_mapPoints;

        public Pathfind(MapPoints mapPoints) { m_mapPoints = mapPoints; }
        public Point2D FindPath(Point2D origin,Point2D endPoint,out List<Point2D> openList,out List<Point2D> closeList)
        {
            m_openList.Add(new Point2D(origin.X,origin.Y));
            while(m_openList.Count > 0)
            {
                Point2D current = GetLeastFPoint();
                m_openList.Remove(current);   
                m_closeList.Add(current);                
                foreach (var target in GetSurroundPoints(current))
                {
                    if(!m_openList.Contains(target))
                    {
                        
                        target.Parent = current;
                        target.m_G = CalcH(target,endPoint);
                        target.m_H = CalcG(current, target);
                        target.m_F = CalcF(target);
                        m_openList.Add(target);
                    }
                    else
                    {
                        float tempG = CalcG(current, target);
                        if(tempG<target.m_G)
                        {
                            target.Parent = current;
                            target.m_G = tempG;
                            target.m_F = CalcF(target);
                        }
                    }
                    openList = m_openList;
                    closeList = m_closeList;
                    if (m_openList.Contains(endPoint))
                    {
                        return target;
                    }

                }
            }
            openList = m_openList;
            closeList = m_closeList;
            return null;
        }

        private Point2D GetLeastFPoint()
        {
            Point2D resultPoint = default;
            if(m_openList.Count > 0)
            {
                resultPoint =  m_openList.First();
                if (m_openList.Count > 1)
                    for (int i = 1; i < m_openList.Count; i++)
                    {
                        if (resultPoint.m_F > m_openList[i].m_F)
                        {
                            resultPoint = m_openList[i];
                        }
                    }
            }
            return resultPoint;
        }

        public List<Point2D> GetSurroundPoints(Point2D nood)
        {
            List<Point2D> surroundPoints = new List<Point2D>();
            m_mapPoints.RowAndColInMapPoint(nood.X, nood.Y, out int col, out int row);
            for (int i = 0; i < CheckHorzontal(col,row).Length; i++)
            {
                if(CheckHorzontal(col,row)[i].m_isWarkable)
                    surroundPoints.Add(CheckHorzontal(col, row)[i]);
            }
            for (int i = 0; i < CheckVertical(col,row).Length; i++)
            {
                if (CheckVertical(col, row)[i].m_isWarkable)
                    surroundPoints.Add(CheckVertical(col, row)[i]);
            }
            return surroundPoints;
        }

        private Point2D[] CheckHorzontal(int col,int row)
        {
            if (col == 0)
            {
                return new Point2D[] { m_mapPoints.m_mapPoints[row][col + 1] };
            }
            else
            {
                if (col < m_mapPoints.m_mapPoints[row].Length - 1)
                    return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1], m_mapPoints.m_mapPoints[row][col + 1] };
                else
                    return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1] };
            }
        }

        private Point2D[] CheckVertical(int col,int row)
        {
            if(row == 0)
            {
                return new Point2D[] { m_mapPoints.m_mapPoints[row + 1][col] };
            }else
            {
                if (row < m_mapPoints.m_mapPoints.Length - 1)
                    return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col], m_mapPoints.m_mapPoints[row + 1][col] };
                else
                    return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col] };
            }
        }

        private float CalcH(Point2D target,Point2D endPoint)
        {
            return Math.Abs(endPoint.X - target.X) + Math.Abs(endPoint.Y - target.Y);
        }
        private float CalcG(Point2D current,Point2D target)
        {
            return Math.Abs(target.X - current.X) + Math.Abs(target.Y - current.Y);
        }
        private float CalcF(Point2D point)
        {
            return point.m_H + point.m_G;
        }
    }
}
