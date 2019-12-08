using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OpenHexagonMesh : MonoBehaviour
{
    public Material material;
    public int radius = 1;
    public float thickness = 0.2f;
    // Start is called before the first frame update

    Vector3[] getVertices()
    {
        Vector3[] vertices = new Vector3[12];
        for (int i = 0; i < 6; i++)
        {
            vertices[i] = radius * (new Vector3(Mathf.Cos(60.0f / 180.0f * Mathf.PI * i), Mathf.Sin(60.0f / 180.0f * Mathf.PI * i)));
        }

        for (int i = 0; i < 6; i++)
        {
            vertices[6 + i] = (radius - thickness) * (new Vector3(Mathf.Cos(60.0f / 180.0f * Mathf.PI * i), Mathf.Sin(60.0f / 180.0f * Mathf.PI * i)));
        }
        return vertices;
    }

    Vector2[] getPolyPoints(Vector3[] vertices)
    {
        Vector2[] points = new Vector2[12];
        int[] order = new int[] {1, 7, 6, 11, 10, 9, 8, 2, 3, 4, 5, 0};
        for(int i = 0; i<12; i++)
        {
            points[i] = vertices[order[i]];
        }
        return points;
    }

    void Start()
    {
        Mesh mesh = new Mesh();

        var vertices = getVertices();

        mesh.vertices = vertices;
        mesh.triangles = new int[] { 0, 1, 6, 1, 6, 7, 2, 8, 9, 2, 3, 9, 3, 9, 10, 3, 4, 10, 5, 10, 11, 4, 5, 10, 0, 5, 11, 0, 6, 11 };

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        GetComponent<PolygonCollider2D>().points = getPolyPoints(vertices);
    }

    // Update is called once per frame
    void Update()
    {
        var vertices = getVertices();
        GetComponent<MeshFilter>().mesh.vertices = vertices;
        GetComponent<PolygonCollider2D>().points = getPolyPoints(vertices);
        GetComponent<MeshRenderer>().material = material;
    }
}
