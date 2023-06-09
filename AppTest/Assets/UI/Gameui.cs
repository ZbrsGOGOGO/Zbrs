using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameui : MonoBehaviour
{

    /// <summary>
    /// 返回按钮
    /// </summary>
    public Button Fanhui;
    /// <summary>
    /// 主界面
    /// </summary>
    public GameObject ShangyigePanel;
    /// <summary>
    /// 当前界面
    /// </summary>
    public GameObject ThisPanel;
    /// <summary>
    /// 关闭
    /// </summary>
    public GameObject clone;
    /// <summary>
    /// 背景图
    /// </summary>
    public Image beijing;

    /// <summary>
    /// 位置记录
    /// </summary>
    private Vector3 a;
    void Start()
    {

        a = beijing.transform.position;//锁定背景原来的位置
        Fanhui.onClick.AddListener(FanhuiBtnLogic);
    }

    // Update is called once per frame
    void Update()
    {
        Diaoluo();
        Timer();
    }

    /// <summary>
    /// 返回主界面
    /// </summary>
    public void FanhuiBtnLogic()
    {
        ShangyigePanel.gameObject.SetActive(true);
        ThisPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// 掉落点
    /// </summary>
    public GameObject pointone;
    public GameObject pointtwo;
    public GameObject pointthree;
    public GameObject pointfour;

    /// <summary>
    /// 计时器
    /// </summary>
    public float time = 2f;

    /// <summary>
    /// 掉落计时
    /// </summary>
    public void Diaoluo()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Diao();
        }
    }

    /// <summary>
    /// 随机四个点掉落
    /// </summary>
    public void Diao()
    {
        float a = Random.Range(0, 5);
        GameObject Sphere = GameObject.Instantiate(clone) as GameObject;
        time = 3f;
        Sphere.transform.SetParent(ThisPanel.transform);
        if (a == 1)
        {
            Sphere.transform.position = pointone.transform.position;
        }
        if (a == 2)
        {
            Sphere.transform.position = pointtwo.transform.position;
        }
        if (a == 3)
        {
            Sphere.transform.position = pointthree.transform.position;
        }
        if (a == 4)
        {
            Sphere.transform.position = pointfour.transform.position;
        }
    }

    /// <summary>
    /// 点击判断是否命中
    /// </summary>
    public void Dianji()
    {

    }
    /// <summary>
    /// 积分
    /// </summary>
    public void Point()
    {

    }

    /// <summary>
    /// //背景移动速度
    /// </summary>
    float speed = 200;
    /// <summary>
    /// //时间
    /// </summary>
    float timer = 0;

    /// <summary>
    /// 背景移动
    /// </summary>
    private void Timer()//背景场地移动
    {
        /*方法1：重复函数的调用，使背景重复移动，30为背景板的长度
		float f = Mathf.Repeat(speed * Time.time, 30);
		transform.position = a + Vector3.back * f;
		*/
        //方法2：
        timer += Time.deltaTime;//每帧的增加时间
                                //背景位移
        beijing.transform.position -= Vector3.right * speed * Time.deltaTime;
        if (timer > 11)
        {
            beijing.transform.position = a;
            timer = 0;
        }
    }

}
