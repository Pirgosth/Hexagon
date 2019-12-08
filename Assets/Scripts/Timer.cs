using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private string FormatTime(float time)
    {
        int seconds = ((int)time)%60;
        int ms = (int)((time- (int)time) * 100.0f);
        int minutes = ((int)time) / 60;
        return (minutes < 10 ? "0" : "") + minutes.ToString() + "::" + (seconds < 10 ? "0" : "") + seconds.ToString() + "::" + (ms < 10 ? "0" : "") + ms.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Text>().text = FormatTime(Time.timeSinceLevelLoad);
    }
}
