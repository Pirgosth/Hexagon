using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piece : MonoBehaviour
{
    public Spawner spawner;
    private bool trigger = false;

    public void Trigger()
    {
        trigger = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<OpenHexagonMesh>().radius -= Time.deltaTime * spawner.getSpeed()/10;
        if(GetComponent<OpenHexagonMesh>().radius <= 9 && !trigger)
        {
            spawner.addPiece();
            trigger = true;
        }
        if(GetComponent<OpenHexagonMesh>().radius <= 1)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Triangle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
