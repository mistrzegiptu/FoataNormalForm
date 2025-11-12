using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class MazurkiewiczGraph
    {
        private readonly List<Vertex> _vertices = [];

        public List<Vertex> Vertices => [.._vertices];

        public MazurkiewiczGraph(List<Vertex> vertices)
        {
            _vertices = vertices;
        }

        public MazurkiewiczGraph() { }

        public void BuildGraph(string word, Relations relations)
        {
            _vertices.Clear();

            for(int i = 0; i < word.Length; i++)
                _vertices.Add(new Vertex(i, word[i].ToString()));

            for (int step = 1; step < word.Length - 1; step++)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if(i+step >= word.Length)
                        break;

                    if (relations.AreDependent(_vertices[i].Data, _vertices[i + step].Data) &&
                        !AreConnected(_vertices[i], _vertices[i + step]))
                    {
                        _vertices[i].ConnectVertex(_vertices[i + step]);
                    }
                }
            }
        }

        private static bool AreConnected(Vertex vertexA, Vertex vertexB)
        {
            return DfsSearch(vertexA, vertexB, []);
        }

        private static bool DfsSearch(Vertex current, Vertex target, HashSet<Vertex> visited)
        {
            if(visited.Contains(current)) 
                return false;

            if (current == target)
                return true;

            visited.Add(current);

            return current.ConnectedVertices.Any(neighbour => DfsSearch(neighbour, target, visited)); //Who even needs python anymore?
        }

        public void RemoveVertices(List<Vertex> verticesToRemove)
        {
            foreach (var vertex in verticesToRemove)
            {
                vertex.Remove();
                _vertices.Remove(vertex);
            }
        }
    }
}
