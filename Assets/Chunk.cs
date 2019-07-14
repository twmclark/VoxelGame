using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Chunk: MonoBehaviour
{
    private Block[,,] _blocks;
    public static int ChunkSize = 16;
    public bool update = true;

    MeshFilter _filter;
    MeshCollider _collider;
    void Start()
    {
        _filter = gameObject.GetComponent<MeshFilter>();
        _collider = gameObject.GetComponent<MeshCollider>();
        
        _blocks = new Block[ChunkSize, ChunkSize, ChunkSize];
 
        for (var x = 0; x < ChunkSize; x++)
        {
            for (var y = 0; y < ChunkSize; y++)
            {
                for (var z = 0; z < ChunkSize; z++)
                {
                    _blocks[x, y, z] = new BlockAir();
                }
            }
        }
 
        _blocks[3, 5, 2] = new Block();
        _blocks[4, 5, 2] = new BlockGrass();
        UpdateChunk();
    }

    void Update()
    {
        
    }

    public Block GetBlock(int x, int y, int z)
    {
        return _blocks[x, y, z];
    }

    void UpdateChunk()
    {
        var meshData = new MeshData();

        for (var x = 0; x < ChunkSize; x++)
        {
            for (var y = 0; y < ChunkSize; y++)
            {
                for (var z = 0; z < ChunkSize; z++)
                {
                    meshData = _blocks[x, y, z].BlockData(this, x, y, z, meshData);
                }
            }
        }
        RenderMesh(meshData);
    }
    void RenderMesh(MeshData meshData)
    {
        _filter.mesh.Clear();
        _filter.mesh.vertices = meshData.vertices.ToArray();
        _filter.mesh.triangles = meshData.triangles.ToArray();
        _filter.mesh.uv = meshData.uv.ToArray();
        _filter.mesh.RecalculateNormals();
        
        _collider.sharedMesh = null;
        Mesh mesh = new Mesh();
        mesh.vertices = meshData.colVertices.ToArray();
        mesh.triangles = meshData.colTriangles.ToArray();
        mesh.RecalculateNormals();
  
        _collider.sharedMesh = mesh;
    }
}