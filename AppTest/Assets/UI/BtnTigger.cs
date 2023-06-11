using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTigger : MonoBehaviour
{

    public AudioClip right;
    public AudioClip err;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.name);
    }
}
