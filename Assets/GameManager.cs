//using System.Collections;
//using System.Collections.Generic;

using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins; 
    public int health;
    private string coinstring;
    private string healthstring;
    private string verticalstring;

    
    
    static GameManager gm;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI debugText;

    private void Awake()
    {
        health = 5;
        
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

    public void ChangeHealth(int amount)
    {
        health += amount;

    }

    private void Update()
    {
        coinstring = coins.ToString();
        healthstring = health.ToString();
        verticalstring = Input.GetAxis("Vertical").ToString();
        coinText.text = "coins: " + coinstring;
        healthText.text = "health: " + healthstring;
        debugText.text = verticalstring;

    }
}