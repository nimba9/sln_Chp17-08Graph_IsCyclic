using System;
using System.Collections.Generic;
using System.Linq;

namespace IsCyclic
{
    public class Graph
    {
        private int[][] childNodes;
        public Graph(int[][] nodes)
        {
            this.childNodes = nodes;
        }

        public int[][] ChildNodes
        {
            get
            {
                return this.childNodes;
            }

            set
            {
                this.childNodes = value;
            }
        }

        public bool IsCyclic()
        {
            Queue<int> nodes = new Queue<int>();
            bool[] visited = new bool[ChildNodes.GetLength(0)];
            nodes.Enqueue(0);
            while (nodes.Count > 0)
            {
                int currentNode = nodes.Dequeue();
                if (visited[currentNode] == true)
                {
                    return true;
                }

                visited[currentNode] = true;
                foreach (int childNode in this.childNodes[currentNode])
                {
                    nodes.Enqueue(childNode);
                }
            }

            return false;
        }
    }

    public class IsCyclic
    {
        public static Graph CreateGraph()
        {
            int vertexCount = int.Parse(Console.ReadLine());
            int[][] graphArray = new int[vertexCount][];
            for (int i = 0; i < vertexCount; i++)
            {
                string sucessors = Console.ReadLine();
                string[] currentVertexSucessors = sucessors.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                graphArray[i] = currentVertexSucessors.Select(item => int.Parse(item)).ToArray();
                Array.Sort(graphArray[i]);
                if (graphArray[i].Contains(i))
                {
                    throw new ApplicationException("A vertex cannot be it's own successor");
                }
            }

            Graph newGraph = new Graph(graphArray);
            return newGraph;
        }

        public static void Main(string[] args)
        {
            Graph myGraph = CreateGraph();
            Console.WriteLine(myGraph.IsCyclic());
        }
    }
}