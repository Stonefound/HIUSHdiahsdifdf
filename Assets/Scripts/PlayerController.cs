using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public GameManager gm;

    public bool overworld;

    float xspeed;
    float xdirection;
    float xvector;
    float ydirection;
    float yvector;

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld;

        gm = FindFirstObjectByType<GameManager>();

        xspeed = 4;
        xdirection = 0;
        xvector = 0;
        ydirection = 0;
        yvector = 0;

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        if (overworld)
        {
            ydirection = Input.GetAxis("Vertical");
        }
        xvector = xspeed * xdirection;
        yvector = xspeed * ydirection;

        transform.Translate(xvector * Time.deltaTime, yvector * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Spikes"))
        {
            
        }
        
    }

    //for organization, put other built-in Unity functions here





    //after all Unity functions, your own functions can go here
}