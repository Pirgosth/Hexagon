using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Timer timer;
    public float speed = 3;
    public GameObject hexagon;
    private int nextLevel = 10;
    // Start is called before the first frame update

    public void addPiece(float radius)
    {
        int i = Random.Range(0, 6);
        var tmp = GameObject.Instantiate(hexagon, Vector3.zero, Quaternion.identity, transform);
        tmp.SetActive(true);
        tmp.transform.Rotate(Vector3.back * i * 60f);
        tmp.GetComponent<OpenHexagonMesh>().radius = radius;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void addPiece()
    {
        int i = Random.Range(0, 6);
        var tmp = GameObject.Instantiate(hexagon, Vector3.zero, Quaternion.identity, transform);
        tmp.SetActive(true);
        tmp.transform.Rotate(Vector3.back * i * 60f);
    }
    void Start()
    {
        addPiece(19);
        addPiece(14);
        addPiece(9);
    }

    // Update is called once per frame
    void Update()
    {
        if((int)timer.getTime() > nextLevel && speed < 60)
        {
            nextLevel += 10;
            speed += 5;
        }
    }
}
