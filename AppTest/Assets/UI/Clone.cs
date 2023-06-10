using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    private float a = 12;


    public int id;

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
