using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CourseWork
{
    class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;
        public int weight;
        public Edge()
        {
            v1 = v2 = -1;
            weight = -1;
        }
        public Edge(int v1, int v2, int weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen redPen;
        Pen blackPen;
        Pen lightBluePen;
        Graphics g;
        Font font;
        Brush brush;
        PointF point;
        int radius = 20; 
        public int Radius
        {
            get { return radius; }
        }
        public Graphics GetGraphics() { return g; }
        public DrawGraph(int w, int h) 
        {
            bitmap = new Bitmap(w, h);
            g = Graphics.FromImage(bitmap);
            ClearSheet();
            redPen = new Pen(Color.Red);
            blackPen = new Pen(Color.Black);
            lightBluePen = new Pen(Color.LightBlue);
            redPen.Width = 3;
            blackPen.Width = 3;
            lightBluePen.Width = 3;
            brush = Brushes.Black;
            font = new Font("Times New Roman", 15);
        }
        public void ClearSheet()
        {
            g.Clear(Color.White);
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        //check functions
        public bool IsConnected(int amountOfVertices, List<Edge> e)
        {
            bool[] visited = new bool[amountOfVertices];
            List<int>[] matrix = new List<int>[amountOfVertices];
            for (int i = 0; i < amountOfVertices; i++)
            {
                matrix[i] = new List<int>();
            }

            for (int i = 0; i < amountOfVertices; i++)
                for (int j = 0; j < amountOfVertices; j++)
                    matrix[i].Add(0);
            for (int i = 0; i < e.Count; i++)
            {
                matrix[e[i].v1].Add(e[i].v2);
                matrix[e[i].v2].Add(e[i].v1);
            }

            DFS(0, visited, matrix);

            // Check if all vertices were visited
            for (int i = 0; i < amountOfVertices; i++)
            {
                if (!visited[i])
                    return false;
            }

            return true;
        }
        private void DFS(int v, bool[] visited, List<int>[] adj)
        {
            visited[v] = true;

            foreach (int neighbor in adj[v])
            {
                if (!visited[neighbor])
                    DFS(neighbor, visited,adj);
            }
        }

        //draw functions
        public void DrawVertex(int x, int y, string num)
        {
            g.FillEllipse(Brushes.White, x-Radius, y-Radius, 2 * Radius, 2 * Radius);
            g.DrawEllipse(blackPen, x - Radius, y - Radius, 2 * Radius, 2 * Radius);
            point = new PointF(x-10, y-15);
            g.DrawString(num, font, brush, point);
        }
        public void DrawSelectedVertex(int x, int y)
        {
            g.DrawEllipse(redPen, x-Radius, y-Radius, 2 * Radius, 2 * Radius);
        }
        public void DrawEdge(Vertex vertex1, Vertex vertex2, Edge edge) {
            g.DrawLine(lightBluePen, vertex1.x, vertex1.y, vertex2.x, vertex2.y);
            point = new PointF((vertex1.x + vertex2.x) / 2, (vertex1.y + vertex2.y) / 2);
            g.DrawString(edge.weight.ToString(), font, brush, point);
            DrawVertex(vertex1.x, vertex1.y, (edge.v1+1).ToString());
            DrawVertex(vertex2.x, vertex2.y, (edge.v2+1).ToString());
        }
        public void DrawWholeGraph(List<Edge>edges, List<Vertex> vertices)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                g.DrawLine(lightBluePen, vertices[edges[i].v1].x, vertices[edges[i].v1].y, vertices[edges[i].v2].x, vertices[edges[i].v2].y);
                point = new PointF((vertices[edges[i].v1].x + vertices[edges[i].v2].x) / 2, (vertices[edges[i].v1].y + vertices[edges[i].v2].y) / 2);
                g.DrawString(edges[i].weight.ToString(), font, brush, point);

            }
            for (int i = 0; i < vertices.Count; i++)
            {
                DrawVertex(vertices[i].x, vertices[i].y, (i + 1).ToString());
            }
        }

        //matrix
        public void FillWeightMatrix(List<Edge> e, int amount, int[,] matrix)
        {
            for (int i = 0; i < amount; i++)
                for (int j = 0; j < amount; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < e.Count; i++)
            {
                matrix[e[i].v1, e[i].v2] = e[i].weight;
                matrix[e[i].v2, e[i].v1] = e[i].weight;
            }
        }

        //prim's algorythm
        int MinVertex(List<int> value, List<bool> set, int v)
        {
            int minimum = int.MaxValue;
            int vertex = 0;
            for (int i = 0; i < v; ++i)
            {
                if (set[i] == false && value[i] < minimum)
                {
                    vertex = i;
                    minimum = value[i];
                }
            }
            return vertex;
        }
        public List<Edge> MST_prim(List<Vertex> vertices, List<Edge> edges, ref int comparisons)
        {
            int[,] graph = new int[vertices.Count, vertices.Count];
            FillWeightMatrix(edges, vertices.Count, graph);

            int[] parent = new int[vertices.Count];
            List<int> value = Enumerable.Repeat(int.MaxValue, vertices.Count).ToList();
            List<bool> set = Enumerable.Repeat(false, vertices.Count).ToList();

            parent[0] = -1;
            value[0] = 0;

            for (int i = 0; i < vertices.Count - 1; i++)
            {
                int u = MinVertex(value, set, vertices.Count);
                set[u] = true;
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (graph[u,j]!=0 && set[j] == false && graph[u, j] < value[j])
                    {
                        value[j] = graph[u, j];
                        parent[j] = u;
                    }
                    comparisons++;
                }
            }

            List<Edge> result = new List<Edge>();
            for (int i = 1; i < vertices.Count; i++)
            {
                result.Add(new Edge(parent[i], i, graph[parent[i], i]));
            }
            return result;
        }

        //kruskal's algorythm
        public void InsertionSort(List<Edge> edges, ref int comparisons)
        {
            for (int i = 1; i < edges.Count; i++)
            {
                Edge key = edges[i];
                int j = i - 1;

                while (j >= 0)
                {
                    comparisons++;
                    if (edges[j].weight > key.weight)
                    {
                        edges[j + 1] = edges[j];
                        j--;
                    }
                    else
                        break;
                }
                edges[j + 1] = key;
            }
        }
        public List<Edge> MST_kruskal(List<Vertex> vertices, List<Edge> edges, ref int comparisons)
        {
            List<Edge> result = new List<Edge>();
            List<int> rank = Enumerable.Repeat(0, vertices.Count).ToList();
            List<int> parent = new List<int>();
            int i;
            for (i = 0; i < vertices.Count; i++)
                parent.Add(i);

            int index = 0;
            InsertionSort(edges, ref comparisons);

            i = 0;
            while(index < vertices.Count - 1)
            {
                Edge next = new Edge();
                next = edges[i++];

                int x = Find(parent, next.v1);
                int y = Find(parent, next.v2);

                if(x!=y)
                {
                    result.Add(new Edge());
                    result[index++] = next;
                    UnionSet(parent, rank, x, y);
                }
                comparisons++;  
            }
            return result;
        }


        //boruvka's algorythm
        private int Find(List<int> parent, int i)
        {
            if (parent[i] == i)
            {
                return i;
            }
            return Find(parent, parent[i]);
        }
        private void UnionSet(List<int> parent, List<int> rank, int x, int y)
        {
            int xroot = Find(parent, x);
            int yroot = Find(parent, y);

            if (rank[xroot] < rank[yroot])
            {
                parent[xroot] = yroot;
            }
            else if (rank[xroot] > rank[yroot])
            {
                parent[yroot] = xroot;
            }
            else
            {
                parent[yroot] = xroot;
                rank[xroot]++;
            }
        }
        public List<Edge> MST_boruvka(List<Vertex> vertices, List<Edge> edges, ref int comparisons)
        {
            List<int> parent = new List<int>();
            List<int> rank = new List<int>();
            List<Edge> cheapest = new List<Edge>();
            List<Edge> result = new List<Edge>();
            int numTrees = vertices.Count;

            for (int node = 0; node < vertices.Count; node++)
            {
                parent.Add(node);
                rank.Add(0);
                Edge temp = new Edge(-1, -1, -1);
                cheapest.Add(temp);
            }

            while (numTrees > 1)
            {
                for (int i = 0; i < edges.Count; i++)
                {
                    int u = edges[i].v1, v = edges[i].v2;
                    int w = edges[i].weight;
                    int set1 = Find(parent, u), set2 = Find(parent, v);
                    if (set1 != set2)
                    {
                        if (cheapest[set1].weight == -1 || cheapest[set1].weight > w)
                        {
                            cheapest[set1] = new Edge(u, v, w);
                        }
                        if (cheapest[set2].weight == -1 || cheapest[set2].weight > w)
                        {
                            cheapest[set2] = new Edge(u, v, w);
                        }
                    }
                    comparisons++;
                }

                for (int node = 0; node < vertices.Count; node++)
                {
                    if (cheapest[node].weight != -1)
                    {
                        int u = cheapest[node].v1, v = cheapest[node].v2;
                        int w = cheapest[node].weight;
                        int set1 = Find(parent, u), set2 = Find(parent, v);
                        if (set1 != set2)
                        {
                            UnionSet(parent, rank, set1, set2);
                            result.Add(new Edge(u, v, w));
                            numTrees--;
                            comparisons++;
                        }
                    }
                }

                for (int node = 0; node < vertices.Count; node++)
                {
                    cheapest[node].weight = -1;
                }
            }
            return result;
        }
    }
}