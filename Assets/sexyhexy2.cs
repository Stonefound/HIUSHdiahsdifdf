using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sexyhexy2 : MonoBehaviour
{
    float currentRot;
    // Start is called before the first frame update
    void Start()
    {
        currentRot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentRot = currentRot + 1;
        transform.Rotate(0, 0, currentRot * Time.deltaTime);
    }
}
