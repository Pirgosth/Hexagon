using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TriangleMesh : MonoBehaviour
{
    public Material material;
    public Vector3[] points = new Vector3[] { new Vector3(0, 0.5f, 0f), new Vector3(-0.5f, -0.5f, 0f) , new Vector3(0.5f, -0.5f, 0f) };
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = points;
        mesh.triangles = new int[] { 0, 1, 2 };

        var polyPoints = new Vector2[] { points[0], points[1], points[2]};

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        GetComponent<PolygonCollider2D>().points = polyPoints;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshFilter>().sharedMesh.vertices = points;
        GetComponent<MeshRenderer>().material = material;
        var polyPoints = new Vector2[] { points[0], points[1], points[2] };
        GetComponent<PolygonCollider2D>().points = polyPoints;
    }
}
