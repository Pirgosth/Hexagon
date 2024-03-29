﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexagonMesh : MonoBehaviour
{
    public Material material;
    public int radius = 1;
    // Start is called before the first frame update

    Vector3[] getVertices()
    {
        Vector3[] vertices = new Vector3[6];
        for (int i = 0; i < 6; i++)
        {
            vertices[i] = radius * (new Vector3(Mathf.Cos(60.0f / 180.0f * Mathf.PI * i), Mathf.Sin(60.0f / 180.0f * Mathf.PI * i)));
        }
        return vertices;
    }

    Vector2[] getPolyPoints(Vector3[] vertices)
    {
        Vector2[] points = new Vector2[6];
        for(int i=0; i<6; i++)
        {
            points[i] = vertices[i];
        }

        return points;
    }

    void Start()
    {
        Mesh mesh = new Mesh();

        var newVertices = getVertices();

        mesh.vertices = newVertices;
        mesh.triangles = new int[] {0, 1, 4, 1, 2, 3, 1, 3, 4, 0, 4, 5};

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshRenderer>().material = material;
        GetComponent<PolygonCollider2D>().points = getPolyPoints(newVertices);
    }

    // Update is called once per frame
    void Update()
    {
        var newVertices = getVertices();
        GetComponent<MeshFilter>().sharedMesh.vertices = newVertices;
        GetComponent<MeshRenderer>().material = material;
        GetComponent<PolygonCollider2D>().points = getPolyPoints(newVertices);
    }
}
