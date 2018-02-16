using System;
using System.Collections.Generic;

public class AStar
{
    private char[,] maze { get; set; }

    public AStar(char[,] map)
    {
        this.maze = map;
    } 

    public static int GetH(Node current, Node goal)
    {
        int deltaRow = Math.Abs(current.Row - goal.Row);
        int deltaCol = Math.Abs(current.Col - goal.Col);

        return deltaRow + deltaCol;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();
        Dictionary<Node, Node > parents = new Dictionary<Node, Node>();
        Dictionary<Node, int> gCost = new Dictionary<Node, int>();

        gCost.Add(start, 0);
        parents.Add(start, null);
        priorityQueue.Enqueue(start);

        while(priorityQueue.Count > 0)
        {
            Node current = priorityQueue.Dequeue();

            if (current == goal)
            {
                break;
            }

            List<Node> nearNodes = AddNearbyNodes(current);
            int newCost = gCost[current] + 1;

            foreach (var node in nearNodes)
            {
                if (!gCost.ContainsKey(node) || newCost < gCost[node])
                {
                    node.F = newCost + GetH(node, goal);
                    parents[node] = current;
                    gCost[node] = newCost;
                    priorityQueue.Enqueue(node);
                }
            }
        }

        return this.ReconstructPath(parents, goal, start);
    }

    private IEnumerable<Node> ReconstructPath(Dictionary<Node, Node> parents, Node goal, Node start)
    {
        Stack<Node> path = new Stack<Node>();

        if (!parents.ContainsKey(goal))
        {
            path.Push(start);
            return path;
        }

        Node current = parents[goal];
        path.Push(goal);

        while (current != start)
        {
            path.Push(current);
            current = parents[current];
        }

        path.Push(start);
        return path;
    }

    private List<Node> AddNearbyNodes(Node current)
    {
        List<Node> result = new List<Node>();

        int row = current.Row;
        int col = current.Col;

        int rowUp = row + 1;
        int rowDown = row - 1;
        int colLeft = col - 1;
        int colRight = col + 1;

        this.AddToQueue(result, rowUp, col);
        this.AddToQueue(result, rowDown, col);
        this.AddToQueue(result, row, colLeft);
        this.AddToQueue(result, row, colRight);

        return result;
    }

    private void AddToQueue(List<Node> result, int row, int col)
    {
        if (IsInBounds(row, col) && !IsWall(row,col))
        {
            Node newNode = new Node(row, col);
            result.Add(newNode);
        }
    }

    private bool IsInBounds(int row, int col)
    {
        return (row >= 0 && row < this.maze.GetLength(0))
            && (col >= 0 && col < this.maze.GetLength(1));
    }

    private bool IsWall(int row, int col)
    {
        return this.maze[row, col] == 'W';
    }
}

