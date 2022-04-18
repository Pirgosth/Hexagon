using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject soundSystem;
    public GameObject playerInterface;
    public GameObject menu;
    public Timer timer;
    public Spawner spawner;
    public Camera cam;
    private bool play = false;
    public void startGame()
    {
        timer.resetTimer();
        play = true;
        menu.SetActive(false);
        playerInterface.SetActive(true);
        Time.timeScale = 1;
        soundSystem.GetComponent<AudioSource>().pitch = 1;
        soundSystem.GetComponent<AudioLowPassFilter>().enabled = false;
        soundSystem.GetComponent<AudioSource>().Play();
        spawner.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!play && Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
    }
}
