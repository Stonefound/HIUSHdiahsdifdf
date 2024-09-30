using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameManager gm;
    
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

   private void Update()
    {
        if (gm.health <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("we triggered something");
        if (other.gameObject.CompareTag("Spikes"))
        {
            print("ow oof ah my health");
            gm.ChangeHealth(-1);
            
            
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
        gm.health = 5;
        gm.coins = 0;
    }
    
}
