using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameManager gm;
    private WanderEnemy script;
    public GameObject AxeItem;
    private bool isAxe;
    
    public TopDown_AnimatorController playerScript;
    
    
    void Start()
    {
        playerScript = FindObjectOfType<TopDown_AnimatorController>();
        gm = FindFirstObjectByType<GameManager>();
        isAxe = false;
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
        if (other.gameObject.GetComponent<WanderEnemy>() != null)
        {
            script = other.gameObject.GetComponent<WanderEnemy>();
        }
        
        print("we triggered something");
        if (other.gameObject.CompareTag("Spikes"))
        {
            print("ow oof ah my health");
            gm.ChangeHealth(-1);
        }
       
        if (other.gameObject.CompareTag("Bullet"))
        {
            print("ow oof ah my health");
            gm.ChangeHealth(-1);
        }
        
        if (other.gameObject.CompareTag("Axe"))
        {
            print("collected axe");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Input.GetMouseButton(0))
            {
                print("we gottem");
                Destroy(other.gameObject);
                Instantiate(AxeItem, other.gameObject.transform.position, Quaternion.identity);
                playerScript.SwitchToAxe();
                isAxe = true;
            }
        }
        if (other.gameObject.CompareTag("CaveWood"))
        {
            if (Input.GetMouseButton(0))
            {
                if (isAxe)
                {
                    print("break wall");
                    Destroy(other.gameObject);
                }
            }
        }
    }
    
    
    void Die()
    {
        SceneManager.LoadScene(0);
        gm.health = 5;
        gm.coins = 0;
    }
    
}
