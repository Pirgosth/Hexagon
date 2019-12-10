using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ColorTintMesh : MonoBehaviour
{
    public Material material;
    void Start()
    {
        GetComponent<MeshRenderer>().material = material;
    }
}
