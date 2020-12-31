using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinding
{
    /// <summary>
    /// 寻路系统
    /// </summary>
    public class Pathfind
    {
        private bool[][] openMark;
        private bool[][] closeMark;
        private float[][] costF;
        private Map m_map;
        private List<Cell> m_openList;
        private List<Cell> m_closeList;
        /// <summary>
        /// 初始化寻路系统，在初始化寻路系统中，必须指定寻路系统中的地图
        /// </summary>
        /// <param name="map">必须指定的地图</param>
        public Pathfind(Map map)
        {
            if (map == null) return;
            m_openList = new List<Cell>();
            m_closeList = new List<Cell>();
            openMark = new bool[map.RowCount][];
            closeMark = new bool[map.RowCount][];
            costF = new float[map.RowCount][];
            for (int i = 0; i < map.RowCount; i++)
            {
                openMark[i] = new bool[map.ColCount];
                closeMark[i] = new bool[map.ColCount];
                costF[i] = new float[map.ColCount];
                for (int j = 0; j < map.ColCount; j++)
                {
                    closeMark[i][j] = false;
                    openMark[i][j] = false;
                    costF[i][j] = -1;
                }
            }
            m_map = map;
        }
        /// <summary>
        /// 寻路方法
        /// </summary>
        /// <param name="start">寻路的起点</param>
        /// <param name="end">寻路的终点</param>
        /// <returns>返回一个Cell，这个Cell为终点Cell，其中的Parent变量指向上一个节点</returns>
        public Cell FindPath(Cell start,Cell end)
        {
            // 重置地图状态
            if(m_openList.Count > 0)
            {
                m_openList.Clear();
            }
            if(m_closeList.Count > 0)
            {
                m_closeList.Clear();
            }
            for (int i = 0; i < m_map.RowCount; i++)
            {
                for (int j = 0; j < m_map.ColCount; j++)
                {
                    closeMark[i][j] = false;
                    openMark[i][j] = false;
                    costF[i][j] = -1;
                }
            }

            m_openList.Add(start);
            while (m_openList.Count > 0)
            {
                Cell current = GetLeastCell();
                m_openList.Remove(current);
                m_closeList.Add(current);
                closeMark[current.Row][current.Col] = true;
                foreach (var item in GetSurround(current))
                {
                    if (closeMark[item.Row][item.Col])
                    {
                        continue;
                    }
                    if (!openMark[item.Row][item.Col])
                    {
                        item.Parent = current;
                        item.m_G = CalcG(start, item);
                        item.m_H = CalcH(item, end);
                        m_openList.Add(item);
                        openMark[item.Row][item.Col] = true;
                        closeMark[item.Row][item.Col] = true;

                    }
                    else
                    {
                        float GCost = CalcG(start, item);
                        if (GCost < current.m_G)
                        {
                            item.Parent = current;
                            item.m_G = CalcG(start, item);
                            item.m_H = CalcH(item, end);
                        }

                    }

                    if (item.Col == end.Col && item.Row == end.Row)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private Cell GetLeastCell()
        {
            Cell resultCell = default;
            if (m_openList.Count > 0)
            {
                resultCell = m_openList.First();
                if (m_openList.Count > 1)
                    for (int i = 1; i < m_openList.Count; i++)
                    {
                        if (resultCell.F > m_openList[i].F)
                        {
                            resultCell = m_openList[i];
                        }
                    }
            }
            return resultCell;
        }

        private List<Cell> GetSurround(Cell current)
        {
            List<Cell> surround = new List<Cell>();
            if (current.Col == 0)
            {
                if (m_map.mapCells[current.Row][current.Col + 1].IsWalkable)
                    surround.Add(m_map.mapCells[current.Row][current.Col + 1]);
            }
            else
            {
                if (current.Col < m_map.mapCells[current.Row].Length - 1)
                {
                    if (m_map.mapCells[current.Row][current.Col - 1].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row][current.Col - 1]);
                    if (m_map.mapCells[current.Row][current.Col + 1].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row][current.Col + 1]);
                }
                else
                {
                    if (m_map.mapCells[current.Row][current.Col - 1].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row][current.Col - 1]);
                }
            }

            if (current.Row == 0)
            {
                if (m_map.mapCells[current.Row + 1][current.Col].IsWalkable)
                    surround.Add(m_map.mapCells[current.Row + 1][current.Col]);
            }
            else
            {
                if (current.Row < m_map.mapCells.Length - 1)
                {
                    if (m_map.mapCells[current.Row - 1][current.Col].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row - 1][current.Col]);
                    if (m_map.mapCells[current.Row + 1][current.Col].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row + 1][current.Col]);
                }
                else
                {
                    if (m_map.mapCells[current.Row - 1][current.Col].IsWalkable)
                        surround.Add(m_map.mapCells[current.Row - 1][current.Col]);
                }
            }
            return surround;
        }

        private float CalcG(Cell start,Cell node)
        {
            return Math.Abs(node.Col - start.Col) + Math.Abs(node.Row - start.Row);
        }
        private float CalcH(Cell node, Cell end)
        {
            return Math.Abs(end.Col - node.Col) + Math.Abs(end.Row - node.Row);
        }
    }
}
