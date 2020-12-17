using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialization();
            Kruskal();
            Output();
            Console.ReadKey();
        }

        class Edge
        {
            public int vertex1, vertex2;
        }


        static int[,] graph; 
        static List<int> vertexs; 
        static List<Edge> edges; 


        static void Kruskal()
        {
            List<Edge> lstEdge;
            int[] Label;
            int n = graph.GetLength(0);

            lstEdge = new List<Edge>(); // danh sach canh
            Label = new int[n];
            for (int i = 0; i < n; i++)
            {
                Label[i] = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (graph[i, j] != 0)
                    {
                        Edge e = new Edge();
                        e.vertex1 = i; e.vertex2 = j;
                        lstEdge.Add(e);
                    }
                }
            }

            Console.WriteLine("Общий вид: (вершина1, вершина2) : вес");
            foreach (Edge e in lstEdge)
            {
                Console.WriteLine("({0},{1}) : {2}", e.vertex1, e.vertex2, graph[e.vertex1, e.vertex2]);
            }
            Console.WriteLine();

            for (int i = 0; i < lstEdge.Count - 1; i++)
            {
                for (int j = i + 1; j < lstEdge.Count; j++)
                {
                    if (CompareEdge(lstEdge[i], lstEdge[j]) == 1)
                    {
                        Edge t = lstEdge[i];
                        lstEdge[i] = lstEdge[j];
                        lstEdge[j] = t;
                    }
                }
            }


            foreach (Edge e in lstEdge)
            {
                if (Label[e.vertex1] != Label[e.vertex2])
                {
 
                    edges.Add(e);

                    if (!vertexs.Contains(e.vertex1)) 
                        vertexs.Add(e.vertex1);
                    if (!vertexs.Contains(e.vertex2)) 
                        vertexs.Add(e.vertex2);


                    int lab1 = (Label[e.vertex1] < Label[e.vertex2]) ? Label[e.vertex1] : Label[e.vertex2]; 
                    int lab2 = (Label[e.vertex1] > Label[e.vertex2]) ? Label[e.vertex1] : Label[e.vertex2]; 
                    for (int i = 0; i < n; i++)
                    {
                        if (Label[i] == lab2) 
                            Label[i] = lab1;
                    }
                }
            }
        }

        static int CompareEdge(Edge e1, Edge e2)
        {
            if (graph[e1.vertex1, e1.vertex2] > graph[e2.vertex1, e2.vertex2]) 
                return 1;
            else if (graph[e1.vertex1, e1.vertex2] == graph[e2.vertex1, e2.vertex2]) 
                return 0;
            return -1;
        }

        static void Initialization()
        {
            //graph = new int[,]
            //{
            //    {0,5,0,3,0},
            //    {5,0,0,8,10},
            //    {0,0,0,7,0},
            //    {3,8,7,0,1},
            //    {0,10,0,1,0}
            //};

            graph = new int[,]
            {
                {0,7,0,5,0,0,0},
                {7,0,8,9,7,0,0},
                {0,8,0,0,5,0,0},
                {5,9,0,0,15,6,0},
                {0,7,5,15,0,8,9},
                {0,0,0,6,8,0,11},
                {0,0,0,0,9,11,0}
            };
            vertexs = new List<int>();
            edges = new List<Edge>();
        }

        static void Output()
        {
            Console.Write("Вершины: ");
            foreach (int i in vertexs)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.Write("Ребра: ");
            foreach (Edge e in edges)
            {
                Console.Write($"({e.vertex1}, {e.vertex2}) ");
            }
        }
    }
}
