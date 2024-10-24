using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Timeline;

public class WanderEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<Vector3> waypoints = new List<Vector3>();
    public Vector3 playerPosition;
    public float enemyCooldown;
    public TopDown_EnemyAnimator script;
    
    
   public enum States
    {
        Patrol,
        Chase,
        Climb,
        Attack,
        Die
    }
    public States state;
    
    private int num;
    
    void Start()
    {
        state = States.Patrol;
        num = 0;
        enemyCooldown = 4;
        
        script = gameObject.GetComponent<TopDown_EnemyAnimator>();
        
        for (num = 0; num < 5; num++)
        {
            Vector3 temp = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            waypoints.Add(temp);
            
            
            //num += 1;
        }
        num = 0;
    }

    // Update is called once per frame
    
    
    
    void Update()
    {
        //enemyCooldown -= Time.deltaTime;
        script.enemyCooldown = enemyCooldown;
        
        if (state == States.Patrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], 2 * Time.deltaTime);
        }
        if (state == States.Climb)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[num], Time.deltaTime / 2);
        }
        if (state == States.Attack)
        {
            if (enemyCooldown < 0)
            {
                enemyCooldown = 4;
            }
        }
        else
        {
            enemyCooldown = 4;
        }

        if (transform.position == waypoints[num])
        {
            num += 1;
            
            if (num >= waypoints.Count)
            {
                num = 0;
                for (num = 0; num < 5; num++)
                {
                    Vector3 temp = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
                    waypoints.Add(temp);
            
            
                    //num += 1;
                }
            }

        }
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerPosition = other.gameObject.transform.position;
            
            if (Vector3.Distance(transform.position, playerPosition) <= 0.75)
            {
                state = States.Attack;
            }
            else
            {
                state = States.Chase;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 2 * Time.deltaTime);
            
        }

        if (other.gameObject.CompareTag("CollisionTrigger"))
        {
            state = States.Climb;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            state = States.Patrol;
    }
    
    
}
