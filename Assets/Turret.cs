using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //Start is called before the first frame update

    private int distance;
    private int cooldown;
    private float firerate;
    
    private object script;

    //public GameObject projectilePrefab;
    public GameObject projectile;


    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            
            GameObject clone = Instantiate(projectile, transform.position, Quaternion.identity);

            ProjectileScript script = clone.GetComponent<ProjectileScript>();
            
            script.targetPostion = other.GameObject().transform.position;
            print("summoned bullet at" + other.GameObject().transform.position);


        }
    }
    
}
