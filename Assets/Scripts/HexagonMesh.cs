using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonMesh : MonoBehaviour
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

    void Start()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = getVertices();
        mesh.triangles = new int[] { 0, 1, 6, 1, 6, 7, 1, 7, 8, 1, 2, 8, 2, 8, 9, 2, 3, 9, 3, 9, 10, 3, 4, 10, 5, 10, 11, 4, 5, 10, 0, 5, 11, 0, 6, 11 };

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshRenderer>().material = material;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshFilter>().mesh.vertices = getVertices();
    }
}
