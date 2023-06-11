using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{

    /// <summary>
    /// 是否被击中
    /// </summary>
    public bool isPoint;
    /// <summary>
    /// 所属id
    /// </summary>
    public int id;

    /// <summary>
    /// 是否被销毁
    /// </summary>
    public bool isDes;

    public float pos;


    private float a = 8;
    void Update()
    {
        pos = transform.position.y;
        if (this.transform.position.y < 209.7709)
        {
            Destroy(this.gameObject);
        }
    }
}
