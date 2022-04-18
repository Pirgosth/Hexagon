using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTintMesh : MonoBehaviour
{
    public float speed = 2.0f;
    public int min = 0;
    public int max = 255;
    public float darkOpacity = 230f;
    public float liteOpacity = 70f;
    public Material darkMaterial;
    public Material liteMaterial;
    private int cc = 2;
    private int signe = 1;
    void Start()
    {
        darkMaterial.color = new Color(min/255f, min / 255f, max/255f, darkOpacity/255f);
        liteMaterial.color = new Color(min / 255f, min / 255f, max/255f, liteOpacity/255.0f);
    }

    void Update()
    {
        switch(cc){
            case 0:
                darkMaterial.color += new Color(speed * Time.deltaTime * signe/255f, 0, 0, 0);
                liteMaterial.color += new Color(speed * Time.deltaTime * signe/255f, 0, 0, 0);
                if(darkMaterial.color.r >= max/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(max / 255f, color.g, color.b, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(max / 255f, color.g, color.b, color.a);
                    cc = 1;
                    signe *= -1;
                }
                if(darkMaterial.color.r <= min/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(min / 255f, color.g, color.b, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(min / 255f, color.g, color.b, color.a);
                    cc = 1;
                    signe *= -1;
                }
                break;
            case 1:
                darkMaterial.color += new Color(0, speed * Time.deltaTime * signe/255f, 0, 0);
                liteMaterial.color += new Color(0, speed * Time.deltaTime * signe/255f, 0, 0);
                if (darkMaterial.color.g >= max/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(color.r, max / 255f, color.b, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(color.r, max / 255f, color.b, color.a);
                    cc = 2;
                    signe *= -1;
                }
                if (darkMaterial.color.g <= min/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(color.r, min / 255f, color.b, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(color.r, min / 255f, color.b, color.a);
                    cc = 2;
                    signe *= -1;
                }
                break;
            case 2:
                darkMaterial.color += new Color(0, 0, speed * Time.deltaTime * signe/255f, 0);
                liteMaterial.color += new Color(0, 0, speed * Time.deltaTime * signe/255f, 0);
                if (darkMaterial.color.b >= max/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(color.r, color.g, max / 255f, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(color.r, color.g, max / 255f, color.a);
                    cc = 0;
                    signe *= -1;
                }
                if (darkMaterial.color.b <= min/255f)
                {
                    var color = darkMaterial.color;
                    darkMaterial.color = new Color(color.r, color.g, min / 255f, color.a);
                    color = liteMaterial.color;
                    liteMaterial.color = new Color(color.r, color.g, min / 255f, color.a);
                    cc = 0;
                    signe *= -1;
                }
                break;
            default:
                break;
        }
    }

    void OnDestroy()
    {
        darkMaterial.color = new Color(min / 255f, min / 255f, max / 255f, darkOpacity / 255f);
        liteMaterial.color = new Color(min / 255f, min / 255f, max / 255f, liteOpacity / 255.0f);
    }
}
