using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{

    

    public GameManager gm;
    public int Score;
    // Start is called before the first frame update

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("we triggered something");
        if (other.gameObject.CompareTag("Coin"))
        {
            print("we triggered a coin");
            gm.coins += 1;
            Score = Score + 1;
            Destroy(other.gameObject);
            Debug.Log("Score: " + Score); // Temporary score display
            print("Coins: " + gm.coins);
        }
    }

    
    


