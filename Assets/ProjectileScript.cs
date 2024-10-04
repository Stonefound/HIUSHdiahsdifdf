using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPosition;
    private float timer;
    void Start()
    {
        timer = 2;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
            timer = 2;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
    }
}
