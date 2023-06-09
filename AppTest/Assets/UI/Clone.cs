using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    private float a = 12;
   

    // Update is called once per frame
    void Update()
    {
        a -= Time.deltaTime;
        if (a<0)
        {
            Destroy(this);
        }
    }
}
