using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coins;
    public int score;
    
    public GameManager gm;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }

        
    }
    
    public int GetScore()
    {
        return score;
    }

    private void SetScore(int amount)
    {
        //when would we even use this? Why is it private?
        score = amount;
    }

    public void AddScore(int amount)
    {
        score += amount;
        // Your code here: Update the score display
    }
}
