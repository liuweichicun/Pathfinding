using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace TestCode
{
    class PathfindingDemo
    {
        static void Main(string[] args)
        {
            Map map = new Map(100,100);
            Pathfind pd = new Pathfind(map);

            Cell startCell = new Cell();
            startCell.Col = map.RowCount - 1;
            startCell.Row = map.ColCount - 1;

            Cell endCell = new Cell();
            endCell.Row = 0;
            endCell.Col = 0;

            Obstacle obstacle = new Obstacle();
            obstacle.StartCol = 10;
            obstacle.StartRow = 0;
            obstacle.OccupyCol = 1;
            obstacle.OccupyRow = 10;
            obstacle.RegisterInMap(map);
            Obstacle obstacle1 = new Obstacle();
            obstacle1.StartCol = 0;
            obstacle1.StartRow = 10;
            obstacle1.OccupyCol = 9;
            obstacle1.OccupyRow = 1;
            obstacle1.RegisterInMap(map);

            Cell path = pd.FindPath(startCell,endCell);

            List<Cell> pathList = new List<Cell>();
            while (true)
            {
                if (path == null) break;
                if (path.Col == startCell.Col && path.Row == startCell.Row)
                {
                    Console.Write("[{0:D2},{1:D2}]", path.Col, path.Row);
                    pathList.Add(path);
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.Write("[{0:D2},{1:D2}] <-", path.Col, path.Row);
                    pathList.Add(path);
                    path = path.Parent;
                }
            }

            PrintPath(map, pathList);
            Console.ReadLine();
        }

        static void PrintPath(Map map,List<Cell> pathList)
        {

            for (int i = 0; i < map.RowCount; i++)
            {
                for (int j = 0; j < map.ColCount; j++)
                {
                    if (pathList.Contains(map.mapCells[i][j]))
                    {
                        if (map.mapCells[i][j].Col == pathList[pathList.Count - 1].Col && map.mapCells[i][j].Row == pathList[pathList.Count - 1].Row)
                            Console.Write("☆");
                        else if (map.mapCells[i][j].Col == pathList.First().Col && map.mapCells[i][j].Row == pathList.First().Row)
                        {
                            Console.Write("★");
                        }
                        else
                            Console.Write("◆");
                    }
                    else
                    {
                        if (map.mapCells[i][j].IsWalkable)
                        {
                            Console.Write("◇");
                        }
                        else
                        {
                            Console.Write("■");
                        }

                    }

                }
                Console.WriteLine();
            }
        }

    }
}
