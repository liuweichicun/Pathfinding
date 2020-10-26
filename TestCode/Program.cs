//using System;
//using System.Collections.Generic;
//using System.Linq;
//namespace TestCode
//{

//    class Cell : IEquatable<Cell>
//    {
//        public int col;
//        public int row;
//        public bool isWalkable;
//        public float F { get { return G + H; } }
//        public float G;
//        public float H;
//        public Cell parent;

//        public bool Equals(Cell other)
//        {
//            if (other.col == col && other.row == row)
//                return true;
//            else
//                return false;
//        }
//    }
//    class Program
//    {
//        //static void Main(string[] args)
//        //{ 

//        //    int row = 20;

//        //    int col = 20;

//        //    MapPoints m = new MapPoints(0, 0, 1, 1, row, col);
//        //    foreach (var item in m.m_mapPoints)
//        //    {
//        //        foreach (var i in item)
//        //        {
//        //            Console.Write(i.X + ":" + i.Y + " ");
//        //        }
//        //        Console.WriteLine();
//        //    }
//        //    Console.WriteLine();
//        //    Obstacle o = new Obstacle();
//        //    o.m_startPosX = 0;
//        //    o.m_startPoxY = 0;
//        //    o.OccupyX = 2;
//        //    o.OccupyY = 3;
//        //    //o.SettleInMapPoints(m);

//        //    foreach (var item in m.m_mapPoints)
//        //    {
//        //        foreach (var i in item)
//        //        {
//        //            Console.Write(i.m_isWarkable + " ");
//        //        }
//        //        Console.WriteLine();
//        //    }

//        //    //Console.WriteLine();
//        //    //o.UnSettleInMapPoints();

//        //    //foreach (var item in m.m_mapPoints)
//        //    //{
//        //    //    foreach (var i in item)
//        //    //    {
//        //    //        Console.Write(i.m_isWarkable + " ");
//        //    //    }
//        //    //    Console.WriteLine();
//        //    //}


//        //    Console.WriteLine();
//        //    Pathfind p = new Pathfind(m);
//        //    Point2D nood = new Point2D(-row, -col);
//        //    Point2D endPoint = new Point2D(row, col);
//        //    List<Point2D> openList;
//        //    List<Point2D> closeList;
//        //    int mili = DateTime.Now.Millisecond;
//        //    int sec = DateTime.Now.Second;
//        //    Point2D path = p.FindPath(nood, endPoint, out openList, out closeList);
//        //    int mi = DateTime.Now.Millisecond - mili;
//        //    int sc = DateTime.Now.Second - sec;
//        //    Console.WriteLine("sec:" + sc + " : " + mi);
//        //    int count = 0;
//        //    while (!(path.X == nood.X && path.Y == nood.Y))
//        //    {
//        //        Console.Write(path.X + ":" + path.Y + " ->");
//        //        path = path.Parent;
//        //        count++;
//        //    }
//        //    Console.Write(path.X + ":" + path.Y);
//        //    Console.WriteLine();
//        //    Console.Write(count);

//        //    //foreach (var item in openList)
//        //    //{
//        //    //    Console.WriteLine(item);
//        //    //}
//        //    //Console.WriteLine("");
//        //    //foreach (var item in closeList)
//        //    //{
//        //    //    Console.WriteLine(item);
//        //    //}
//        //    Console.ReadLine();
//        //}

//        static bool[][] closeMark;
//        static bool[][] openMark;
//        static float[][] costF;
//        static Cell[][] mapPoint;
//        static List<Cell> openList;
//        static List<Cell> closeList;
//        static List<Cell> pathList;
//        static int col;
//        static int row;
        

//        static void MainDemo(string[] args)
//        {
//            if (args.Length > 1)
//            {
//                col = int.Parse(args[0]);
//                row = int.Parse(args[1]);
//            }else
//            {
//                col = 100;
//                row = 100;
//            }

//            closeMark = new bool[row][];
//            openMark = new bool[row][];
//            costF = new float[row][];
//            mapPoint = new Cell[row][];
//            closeList = new List<Cell>();
//            openList = new List<Cell>();
//            for (int i = 0; i < row; i++)
//            {
//                closeMark[i] = new bool[col];
//                costF[i] = new float[col];
//                mapPoint[i] = new Cell[col];
//                openMark[i] = new bool[col];
//                for (int j = 0; j < col; j++)
//                {
//                    Cell c = new Cell();
//                    c.isWalkable = true;
//                    c.row = i;
//                    c.col = j;
//                    mapPoint[i][j] = c;
//                    closeMark[i][j] = false;
//                    openMark[i][j] = false;
//                    costF[i][j] = -1;
//                }
//            }

//            Cell startCell = new Cell();
//            startCell.col = 49;
//            startCell.row = 30;
//            Cell endCell = new Cell();
//            endCell.col = col -1;
//            endCell.row = row -1;

//            //for (int i = 0; i < mapPoint.Length; i++)
//            //{
//            //    for (int j = 0; j < mapPoint[i].Length; j++)
//            //    {
//            //        Console.Write("[{0:D2},{1:D2}] ", mapPoint[i][j].col, mapPoint[i][j].row);
//            //    }
//            //    Console.WriteLine();
//            //    Console.WriteLine();
//            //}
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //for (int i = 0; i < mapPoint.Length; i++)
//            //{
//            //    for (int j = 0; j < mapPoint[i].Length; j++)
//            //    {
//            //        Console.Write("[{0}] ", mapPoint[i][j].isWalkable);
//            //    }
//            //    Console.WriteLine();
//            //    Console.WriteLine();
//            //}

//            for (int i = 0; i < mapPoint.Length; i++)
//            {
//                for (int j = 0; j < mapPoint[i].Length; j++)
//                {
//                    if (i <= row - 2 && j == col / 2) mapPoint[i][j].isWalkable = false;
//                    if (i == row - row / 2 && j <= col / 2 && j != 0) mapPoint[i][j].isWalkable = false;
//                    if (i <= row / 2 && i != 0 && j == row / 2 - 2) mapPoint[i][j].isWalkable = false;
//                }
//            }

//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //Console.WriteLine();
//            //for (int i = 0; i < mapPoint.Length; i++)
//            //{
//            //    for (int j = 0; j < mapPoint[i].Length; j++)
//            //    {
//            //        Console.Write("[{0}] ", mapPoint[i][j].isWalkable);
//            //    }
//            //    Console.WriteLine();
//            //    Console.WriteLine();
//            //}
//            pathList = new List<Cell>();

//            DateTime start, end;
//            start = DateTime.Now;
//            Cell path = FindPath(startCell, endCell,out int loopCount);
//            end = DateTime.Now;
//            while (true)
//            {
//                if(path.col == startCell.col && path.row == startCell.row)
//                {
//                    Console.Write("[{0:D2},{1:D2}]", path.col, path.row);
//                    pathList.Add(path);
//                    break;
//                }else
//                {
//                    Console.Write("[{0:D2},{1:D2}] <-", path.col, path.row);
//                    pathList.Add(path);
//                    path = path.parent;
//                }
//            }
            
//            Console.WriteLine();
//            Console.WriteLine();
//            //Console.WriteLine("openList");

//            //foreach (var item in oolist)
//            //{
//            //    Console.WriteLine("[{0}] ", item.F);
//            //}
//            //Console.WriteLine("closeList");
//            //foreach (var item in oclist)
//            //{
//            //    Console.WriteLine("[{0}] ", item.F);
//            //}

//            PrintPath();
//            TimeSpan span = new TimeSpan(end.Ticks - start.Ticks);
//            Console.WriteLine();
//            Console.WriteLine(loopCount);
//            Console.WriteLine("---------------");
//            Console.WriteLine("在 {0} X {1} 的地图中找到路径", col, row);
//            Console.WriteLine(span.Minutes + " 分 " + span.Seconds + " 秒 " + span.Milliseconds + " 毫秒 ");
//            Console.ReadLine();
//        }

//        static Cell FindPath(Cell start,Cell end,out int loopCount)
//        {
//            loopCount = 0;
//            openList.Add(start);         
//            while (openList.Count > 0)
//            {              
//                Cell current = GetLeastCell();
//                openList.Remove(current);
//                closeList.Add(current);
//                closeMark[current.row][current.col] = true;
                
//                foreach (var item in GetSurround(current))
//                {                   
//                    if (closeMark[item.row][item.col])
//                    {
//                        continue;
//                    }
//                    loopCount++;
//                    if (!openMark[item.row][item.col])
//                    {
//                        item.parent = current;
//                        item.G = CalcG(start, item);
//                        item.H = CalcH(item, end);
//                        openList.Add(item);
//                        openMark[item.row][item.col] = true;
//                        closeMark[item.row][item.col] = true;
                        
//                    }
//                    else
//                    {
//                        float GCost = CalcG(start, item);
//                        if (GCost < current.G)
//                        {
//                            item.parent = current;
//                            item.G = CalcG(start, item); 
//                            item.H = CalcH(item, end);
//                        }

//                    }

//                    if (item.col == end.col && item.row == end.row)
//                    {
//                        return item;
//                    }
//                }
//            }
//            return null;
//        }

//        static Cell GetLeastCell()
//        {
//            Cell resultCell = default;
//            if (openList.Count > 0)
//            {
//                resultCell = openList.First();
//                if (openList.Count > 1)
//                    for (int i = 1; i < openList.Count; i++)
//                    {
//                        if (resultCell.F > openList[i].F)
//                        {
//                            resultCell = openList[i];
//                        }
//                    }
//            }
//            return resultCell;
//        }

//        static List<Cell> GetSurround(Cell current)
//        {
//            List<Cell> surround = new List<Cell>();
//            if (current.col == 0)
//            {
//                if(mapPoint[current.row][current.col +1].isWalkable)
//                    surround.Add(mapPoint[current.row][current.col + 1]);
//            }
//            else
//            {
//                if (current.col < mapPoint[current.row].Length - 1)
//                {
//                    if (mapPoint[current.row][current.col - 1].isWalkable)
//                        surround.Add(mapPoint[current.row][current.col - 1]);
//                    if (mapPoint[current.row][current.col + 1].isWalkable)
//                        surround.Add(mapPoint[current.row][current.col + 1]);
//                }
//                else
//                {
//                    if (mapPoint[current.row][current.col - 1].isWalkable)
//                        surround.Add(mapPoint[current.row][current.col - 1]);
//                }
//            }

//            if (current.row == 0)
//            {
//                if (mapPoint[current.row + 1][current.col].isWalkable)
//                    surround.Add(mapPoint[current.row + 1][current.col]);
//            }
//            else
//            {
//                if (current.row < mapPoint.Length - 1)
//                {
//                    if (mapPoint[current.row - 1][current.col].isWalkable)
//                        surround.Add(mapPoint[current.row - 1][current.col]);
//                    if (mapPoint[current.row + 1][current.col].isWalkable)
//                        surround.Add(mapPoint[current.row + 1][current.col]);
//                }
//                else
//                {
//                    if (mapPoint[current.row - 1][current.col].isWalkable)
//                        surround.Add(mapPoint[current.row - 1][current.col]);
//                }
//            }
//            return surround;
//        }

//        static float CalcG(Cell start,Cell node)
//        {
//            return Math.Abs(node.col - start.col) + Math.Abs(node.row - start.row);
//        }
//        static float CalcH(Cell node,Cell end)
//        {
//            return Math.Abs(end.col - node.col) + Math.Abs(end.row - node.row);
//        }

//       static void PrintPath()
//        {
            
//            for (int i = 0; i < row; i++)
//            {
//                for (int j = 0; j < col; j++)
//                {
//                    if (pathList.Contains(mapPoint[i][j]))
//                    {
//                        if (mapPoint[i][j].col == pathList[pathList.Count - 1].col && mapPoint[i][j].row == pathList[pathList.Count - 1].row)
//                            Console.Write("☆");
//                        else if(mapPoint[i][j].col == pathList.First().col && mapPoint[i][j].row == pathList.First().row)
//                        {
//                            Console.Write("★");
//                        }
//                        else
//                            Console.Write("◆");
//                    }
//                    else
//                    {
//                        if (mapPoint[i][j].isWalkable)
//                        {
//                            Console.Write("◇");
//                        }                     
//                        else
//                        {
//                            Console.Write("■");
//                        }
                            
//                    }
                    
//                }
//                Console.WriteLine();

//            }
//        }

//    }

//    //    public List<Point2D> GetSurroundPoints(Point2D nood,MapPoints m)
//    //    {
//    //        List<Point2D> surroundPoints = new List<Point2D>();
//    //        m.RowAndColInMapPoint(nood.X, nood.Y, out int col, out int row);
//    //        for (int i = 0; i < CheckHorzontal(col, row,m).Length; i++)
//    //        {
//    //            if (CheckHorzontal(col, row,m)[i].m_isWarkable)
//    //                surroundPoints.Add(CheckHorzontal(col, row,m)[i]);
//    //        }
//    //        for (int i = 0; i < CheckVertical(col, row,m).Length; i++)
//    //        {
//    //            if (CheckVertical(col, row,m)[i].m_isWarkable)
//    //                surroundPoints.Add(CheckVertical(col, row,m)[i]);
//    //        }
//    //        return surroundPoints;
//    //    }
//    //    private Point2D[] CheckHorzontal(int col, int row,MapPoints m_mapPoints)
//    //    {
//    //        if (col == 0)
//    //        {
//    //            return new Point2D[] { m_mapPoints.m_mapPoints[row][col + 1] };
//    //        }
//    //        else
//    //        {
//    //            if (col < m_mapPoints.m_mapPoints[row].Length - 1)
//    //                return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1], m_mapPoints.m_mapPoints[row][col + 1] };
//    //            else
//    //                return new Point2D[] { m_mapPoints.m_mapPoints[row][col - 1] };
//    //        }
//    //    }

//    //    private Point2D[] CheckVertical(int col, int row,MapPoints m_mapPoints)
//    //    {
//    //        if (row == 0)
//    //        {
//    //            return new Point2D[] { m_mapPoints.m_mapPoints[row + 1][col] };
//    //        }
//    //        else
//    //        {
//    //            if (row < m_mapPoints.m_mapPoints.Length - 1)
//    //                return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col], m_mapPoints.m_mapPoints[row + 1][col] };
//    //            else
//    //                return new Point2D[] { m_mapPoints.m_mapPoints[row - 1][col] };
//    //        }
//    //    }
//    //}
//}