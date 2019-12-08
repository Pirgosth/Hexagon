using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public float timeout = 10.0f;
    public float speed = 15f;
    public float p = 0.01f;
    private int i = 1;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.timeSinceLevelLoad;
        Debug.Log(timer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad-timer > timeout)
        {
            Debug.Log("Reverse Time !");
            timer = Time.timeSinceLevelLoad;
            Debug.Log(i);
            i *= Random.value < p ? (-1) : 1;
        }
        transform.Rotate(i * Vector3.forward * Time.fixedDeltaTime * speed);
    }
}
