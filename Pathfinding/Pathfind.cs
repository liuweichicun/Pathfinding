﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    public class Pathfind
    {
        private bool[][] openMark;
        private bool[][] closeMark;
        private float[][] costF;
        private Map m_map;
        private List<Cell> m_openList;
        private List<Cell> m_closeList;
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

        public Cell FindPath(Cell start,Cell end)
        {
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
                        item.parent = current;
                        item.G = CalcG(start, item);
                        item.H = CalcH(item, end);
                        m_openList.Add(item);
                        openMark[item.Row][item.Col] = true;
                        closeMark[item.Row][item.Col] = true;

                    }
                    else
                    {
                        float GCost = CalcG(start, item);
                        if (GCost < current.G)
                        {
                            item.parent = current;
                            item.G = CalcG(start, item);
                            item.H = CalcH(item, end);
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