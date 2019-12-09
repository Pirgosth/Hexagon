using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
        //gameObject.transform.Rotate(Time.fixedDeltaTime*speed*input * Vector3.back);
        gameObject.transform.GetChild(0).transform.RotateAround(Vector3.zero, Vector3.back, Time.fixedDeltaTime * speed * input);
    }
}
