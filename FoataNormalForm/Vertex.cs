using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class Vertex
    {
        public int Id { get; }
        public string Data { get; }
        private readonly List<Vertex> _connectedVertices;
        private readonly List<Vertex> _incomingVertices;

        public List<Vertex> ConnectedVertices => [.._connectedVertices];
        public List<Vertex> IncomingVertices => [.._incomingVertices];

        public Vertex(int id, string data)
        {
            Id = id;
            Data = data;
            _connectedVertices = [];
            _incomingVertices = [];
        }

        public void ConnectVertex(Vertex vertex)
        {
            _connectedVertices.Add(vertex);
            vertex._incomingVertices.Add(this);
        }

        public void Remove()
        {
            foreach (var vertex in ConnectedVertices)
            {
                vertex._incomingVertices.Remove(this);
            }
        }
    }
}
