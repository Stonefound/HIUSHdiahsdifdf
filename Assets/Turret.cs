using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    
    private int distance;
    private float cooldown;
    private float firerate;
    private float bullet;
    
    Object projectile;
    Object player;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       void OnTriggerStay2D (Collider2D other) {
            if (other.gameObject.CompareTag("Player") && cooldown <= 0)
            {
                
                bullet = Instantiate(projectile).GetComponent<bullet>();

                bullet.targetPostion = player.transform.Postion;
                
            }
        }
    }
}
