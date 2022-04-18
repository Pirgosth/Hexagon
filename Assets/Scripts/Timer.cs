using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime = 0f;
   
    public void resetTimer()
    {
        startTime = Time.timeSinceLevelLoad;
    }
    public float getTime()
    {
        return Time.timeSinceLevelLoad - startTime;
    }
    private string FormatTime(float time)
    {
        time -= startTime;
        int seconds = ((int)time)%60;
        int ms = (int)((time- (int)time) * 100.0f);
        int minutes = ((int)time) / 60;
        string sep = ".";
        return (minutes == 0 ? "" :((minutes < 10 ? "0" : "") + minutes.ToString()) + sep) + (seconds < 10 ? "0" : "") + seconds.ToString() + sep + (ms < 10 ? "0" : "") + ms.ToString();
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
