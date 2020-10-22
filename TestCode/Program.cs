using System;
using System.Collections.Generic;
using Pathfinding;
namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                return;
            }

            int row = int.Parse(args[0]);

            int col = int.Parse(args[1]);

            MapPoints m = new MapPoints(0, 0, 1, 1, row, col);
            foreach (var item in m.m_mapPoints)
            {
                foreach (var i in item)
                {
                    Console.Write(i.X + ":" + i.Y + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Obstacle o = new Obstacle();
            o.m_startPosX = 0;
            o.m_startPoxY = 0;
            o.OccupyX = 2;
            o.OccupyY = 3;
            //o.SettleInMapPoints(m);

            foreach (var item in m.m_mapPoints)
            {
                foreach (var i in item)
                {
                    Console.Write(i.m_isWarkable + " ");
                }
                Console.WriteLine();
            }

            //Console.WriteLine();
            //o.UnSettleInMapPoints();

            //foreach (var item in m.m_mapPoints)
            //{
            //    foreach (var i in item)
            //    {
            //        Console.Write(i.m_isWarkable + " ");
            //    }
            //    Console.WriteLine();
            //}


            Console.WriteLine();
            Pathfind p = new Pathfind(m);
            Point2D nood = new Point2D(-row, -col);
            Point2D endPoint = new Point2D(row, col);
            List<Point2D> openList;
            List<Point2D> closeList;
            int mili = DateTime.Now.Millisecond;
            int sec = DateTime.Now.Second;
            Point2D path = p.FindPath(nood, endPoint, out openList, out closeList);
            int mi = DateTime.Now.Millisecond - mili;
            int sc = DateTime.Now.Second - sec;
            Console.WriteLine("sec:" + sc + " : " + mi);
            int count = 0;
            while (!(path.X == nood.X && path.Y == nood.Y))
            {
                Console.Write(path.X + ":" + path.Y + " ->");
                path = path.Parent;
                count++;
            }
            Console.Write(path.X + ":" + path.Y);
            Console.WriteLine();
            Console.Write(count);

            //foreach (var item in openList)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("");
            //foreach (var item in closeList)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();
        }
    }

    //    public List<Point2D> GetSurroundPoints(Point2D nood,MapPoints m)
    //    {
    //        List<Point2D> surroundPoints = new List<Point2D>();
    //        m.RowAndColInMapPoint(nood.X, nood.Y, out int col, out int row);
    //        for (int i = 0; i < CheckHorzontal(col, row,m).Length; i++)
    //        {
    //            if (CheckHorzontal(col, row,m)[i].m_isWarkable)
    //                surroundPoints.Add(CheckHorzontal(col, row,m)[i]);
    //        }
    //        for (int i = 0; i < CheckVertical(col, row,m).Length; i++)
    //        {
    //            if (CheckVertical(col, row,m)[i].m_isWarkable)
    //                surroundPoints.Add(CheckVertical(col, row,m)[i]);
    //        }
    //        return surroundPoints;
    //    }
    //    private Point2D[] CheckHorzontal(int col, int row,MapPoints m_mapPoints)
    //    {
    //        if (col == 0)
    //        {
    //            return new Point2D[] { m_mapPoints.m_mapPoints[row][col + 1] };
    //        }
    //        else
    //        {
    //            if (col < m_mapPoints.m_mapPoints[row].Length - 1)
    //                return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1], m_mapPoints.m_mapPoints[row][col + 1] };
    //            else
    //                return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1] };
    //        }
    //    }

    //    private Point2D[] CheckVertical(int col, int row,MapPoints m_mapPoints)
    //    {
    //        if (row == 0)
    //        {
    //            return new Point2D[] { m_mapPoints.m_mapPoints[row + 1][col] };
    //        }
    //        else
    //        {
    //            if (row < m_mapPoints.m_mapPoints.Length - 1)
    //                return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col], m_mapPoints.m_mapPoints[row + 1][col] };
    //            else
    //                return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col] };
    //        }
    //    }
    //}
}