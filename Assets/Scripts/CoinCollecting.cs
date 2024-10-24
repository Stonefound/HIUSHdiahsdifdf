//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{



    public GameManager gm;
    // Start is called before the first frame update

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("we triggered something");
        if (other.gameObject.CompareTag("Coin"))
        {
            print("we triggered a coin");
            gm.coins += 1;
            Destroy(other.gameObject);
            print("Coins: " + gm.coins);
        }
    }
}

    
    


