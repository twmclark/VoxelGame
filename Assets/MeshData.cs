using System.Collections.Generic;
using UnityEngine;

public class MeshData
{ 
    public List<Vector3> vertices{ get; set; }
    public List<int> triangles { get; set; }
    public List<Vector2> uv { get; set; }
    public List<int> colTriangles { get; set; }
    public List<Vector3> colVertices { get; set; }
    public bool UseRenderDataForCollision { get; set; }
   public MeshData()
   {
       vertices = new List<Vector3>();
       triangles = new List<int>();
       uv = new List<Vector2>();
       colTriangles = new List<int>();
       colVertices = new List<Vector3>();
       
   }
    public void AddQuadTriangles()
    { 
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 3);
        triangles.Add(vertices.Count - 2);
 
        triangles.Add(vertices.Count - 4);
        triangles.Add(vertices.Count - 2);
        triangles.Add(vertices.Count - 1);
        
        if (UseRenderDataForCollision)
        {
            colTriangles.Add(colVertices.Count - 4);
            colTriangles.Add(colVertices.Count - 3);
            colTriangles.Add(colVertices.Count - 2);
            colTriangles.Add(colVertices.Count - 4);
            colTriangles.Add(colVertices.Count - 2);
            colTriangles.Add(colVertices.Count - 1);
        }
    }
    
    public void AddVertex(Vector3 vertex)
    {
        vertices.Add(vertex);
        if (UseRenderDataForCollision)
        {
            colVertices.Add(vertex);
        }
    }
    public void AddTriangle(int tri)
    {
        triangles.Add(tri);
        if (UseRenderDataForCollision)
        {
            colTriangles.Add(tri - (vertices.Count - colVertices.Count));
        }
    }
}