using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameManager gm;
    
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D other)
    {
        print("we triggered something");
        if (other.gameObject.CompareTag("Spikes"))
        {
            print("ow oof ah my health");
            gm.ChangeHealth(-1);
            
            
        }
    }
    
}
