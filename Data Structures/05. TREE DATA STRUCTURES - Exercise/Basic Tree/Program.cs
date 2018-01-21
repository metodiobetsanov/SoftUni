using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Tree
{
    class Program
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        static void Main()
        {
            ReadTree();

            //01. Root Node
            //Console.WriteLine(new string('-', 20));
            //Console.WriteLine($"Root node: {GetRoot().Value}");

            //02. Print Tree
            //Console.WriteLine(new string('-', 20));
            //PrintTree(GetRoot());

            //03. Leaf Nodes
            //Console.WriteLine(new string('-', 20));
            //GetLeafNodes(nodeByValue);

            //04. Middle Nodes
            //Console.WriteLine(new string('-', 20));
            //GetMiddleNodes(nodeByValue);

            //05. Deepest Node
            //Console.WriteLine(new string('-', 20));
            //GetDeepestNode();

            //06. Longest Path
            //Console.WriteLine(new string('-', 20));
            //GetLongestPath();

            //07. Paths With Given Sum
            //Console.WriteLine(new string('-', 20));
            //GetPathsWithGivenSum();

            //08. Subtrees With Given Sum
            //Console.WriteLine(new string('-', 20));
            GetSubtreesWithGivenSum();
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        static void ReadTree()
        {
            int nodeCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodeCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
            }
        }

        static Tree<int> GetRoot()
        {
            return nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
        }

        static void PrintTree(Tree<int> tree, int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(tree.Value);

            foreach (var child in tree.Children)
            {
                PrintTree(child, indent + 1);
            }
        }

        static void GetLeafNodes(Dictionary<int, Tree<int>> nodeByValue)
        {
            var nodes = nodeByValue.Values
                .Where(x => x.Children.Count == 0)
                .Select(x => x.Value).OrderBy(x => x)
                .ToList();

            Console.WriteLine($"Leaf nodes: {string.Join(" ", nodes)}");
        }

        static void GetMiddleNodes(Dictionary<int, Tree<int>> nodeByValue)
        {
            var nodes = nodeByValue.Values
                .Where(x => x.Parent != null && x.Children.Count != 0)
                .Select(x => x.Value).OrderBy(x => x)
                .ToList();

            Console.WriteLine($"Middle nodes: {string.Join(" ", nodes)}");
        }

        static void GetDeepestNode()
        {
            var maxLevel = 0;
            Tree<int> deepest = null;

            DFS(GetRoot(), 1, ref maxLevel, ref deepest);

            Console.WriteLine($"Deepest node: {deepest.Value}");
        }

        static void DFS(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
        {
            if (node == null)
            {
                return;
            }

            if (level > maxLevel)
            {
                deepest = node;
                maxLevel = level;
            }

            foreach (var child in node.Children)
            {
                DFS(child, level + 1, ref maxLevel, ref deepest);
            }
        }

        static void GetLongestPath()
        {
            var maxLevel = 0;
            Tree<int> deepest = null;
            var result = new Stack<int>();

            DFS(GetRoot(), 1, ref maxLevel, ref deepest);

            while (deepest != null)
            {
                result.Push(deepest.Value);
                deepest = deepest.Parent;
            }
           
            Console.WriteLine($"Longest path: {string.Join(" ", result)}");
        }

        static void GetPathsWithGivenSum()
        {
            var targetSum = int.Parse(Console.ReadLine());
            var leafs = new List<Tree<int>>();

            DFSSum(GetRoot(), targetSum, 0, leafs);

            Console.WriteLine($"Paths of sum {targetSum}:");

            foreach (var leaf in leafs)
            {
                PrintPath(leaf);
            }
        }
        
        static void DFSSum(Tree<int> x, int target, int current, List<Tree<int>> leafs)
        {
            if (x == null)
            {
                return;
            }

            current += x.Value;

            if (current == target && x.Children.Count == 0)
            {
                leafs.Add(x);
            }

            foreach (var child in x.Children)
            {
                DFSSum(child, target, current, leafs);
            }
        }

        private static void PrintPath(Tree<int> leaf)
        {
            var currentLeaf = leaf;
            var stack = new Stack<int>();

            while (currentLeaf != null)
            {
                stack.Push(currentLeaf.Value);
                currentLeaf = currentLeaf.Parent;
            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static void GetSubtreesWithGivenSum()
        {
            var targetSum = int.Parse(Console.ReadLine());
            var parents = new List<Tree<int>>();
            
            GetChildrenSum(GetRoot(), targetSum, parents);

            Console.WriteLine($"Subtrees of sum {targetSum}:");

            foreach (var parent in parents)
            {
                PrintSubTree(parent);
            }
        }

        private static void GetChildrenSum(Tree<int> node, int target, List<Tree<int>> parents)
        {
            if (node == null)
            {
                return;
            }

            var current = node.Value;

            foreach (var child in node.Children)
            {
                current += child.Value;
            }

            if (current == target)
            {
                parents.Add(node);
            }

            foreach (var child in node.Children)
            {
                GetChildrenSum(child, target, parents);
            }
        }
        
        private static void PrintSubTree(Tree<int> parent)
        {
            Console.WriteLine($"{parent.Value} {string.Join(" ", parent.Children.Select(x => x.Value))}");
        }
    }
}
