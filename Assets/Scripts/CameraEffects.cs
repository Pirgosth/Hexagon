using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public float timeout = 5.0f;
    public float speed = 40f;
    public float p = 0.7f;
    public float size = 5.0f;
    public float bounceFrequency = 2.25f;
    public float bounciness = 1f;
    public float amortissementPercentage = 70.0f;
    public float tau = 0.05f;
    private int rotationDirection = 1;
    private float rotationTimer = 0;

    private float getCamSize(float time)
    {
        float period = 1.0f / bounceFrequency;
        float t = time % period;
        float Ttrans = ((100-amortissementPercentage) / 100.0f) * period;
        float alpha = (2 * bounciness) / (Mathf.Exp(-Ttrans / tau) - Mathf.Exp(-period / tau));
        float beta = size - bounciness - alpha * Mathf.Exp(-period / tau);
        if(t >= 0 && t <= Ttrans)
        {
            return (2 * bounciness / Ttrans) * t + (size - bounciness);
        }
        else
        {
            return alpha * Mathf.Exp(-t / tau) + beta;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad-rotationTimer > timeout)
        {
            rotationTimer = Time.timeSinceLevelLoad;
            rotationDirection *= Random.value < p ? (-1) : 1;
        }
        transform.Rotate(rotationDirection * Vector3.forward * Time.fixedDeltaTime * speed);

        GetComponent<Camera>().orthographicSize = getCamSize(Time.timeSinceLevelLoad);
    }
}
