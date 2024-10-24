using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHex : MonoBehaviour
{
    // Start is called before the first frame update

    private int zangle = 0;

    // Update is called once per frame
    void Update()
    {
        zangle += 1;
        if (zangle >= 360)
        {
            zangle = 0;
        }

        if (zangle / 2 == 2)
        {
            transform.Rotate(zangle, 0, zangle*2);
        }
    }
}
