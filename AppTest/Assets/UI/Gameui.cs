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
    public Image beiingone;
    /// <summary>
    /// 位置记录
    /// </summary>
    private Vector3 a;
    private Vector3 b;
    /// <summary>
    /// 掉落点
    /// </summary>
    public GameObject pointone;
    public GameObject pointtwo;
    public GameObject pointthree;
    public GameObject pointfour;
    /// <summary>
    /// //背景移动速度
    /// </summary>
    float speed = 100;
    /// <summary>
    /// //时间
    /// </summary>
    float timer = 0;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;

    public Button BtnOne;
    public Button BtnTwo;
    public Button BtnThree;
    public Button BtnFour;
    private void Start()
    {
        a = beijing.transform.position;//锁定背景原来的位置
        b = beiingone.transform.position;
        Fanhui.onClick.AddListener(FanhuiBtnLogic);
        BtnOne.onClick.AddListener(PointButtonone);
        BtnTwo.onClick.AddListener(PointButtontwo);
        BtnThree.onClick.AddListener(PointButtonthree);
        BtnFour.onClick.AddListener(PointButtonfour);
    }

    private void Update()
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

    public List<GameObject> listone;
    public List<GameObject> listtwo;
    public List<GameObject> listthree;
    public List<GameObject> listfour;
    /// <summary>
    /// 随机四个点掉落
    /// </summary>
    public void Diao()
    {
        float a = Random.Range(0, 5);
        GameObject Sphere = GameObject.Instantiate(clone) as GameObject;
        time = 3f;
        Sphere.transform.SetParent(ThisPanel.transform);
        Sphere.AddComponent<Clone>();
        if (a == 1)
        {
            Sphere.transform.position = pointone.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = one;
            listone.Add(Sphere);
        }
        if (a == 2)
        {
            Sphere.transform.position = pointtwo.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = two;
            listtwo.Add(Sphere);

        }
        if (a == 3)
        {
            Sphere.transform.position = pointthree.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = three;
            listthree.Add(Sphere);

        }
        if (a == 4)
        {
            Sphere.transform.position = pointfour.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = four;
            listfour.Add(Sphere);
        }
    }


    /// <summary>
    /// 积分规则点击判断是否命中
    /// </summary>
    /// <param name="one"></param>
    /// <param name="two"></param>
    public void Far(GameObject one, GameObject two)
    {
        float distance = (one.transform.position - two.transform.position).magnitude;
        if (distance > 80)
        {
            Debug.Log("0分物体不会消失");
        }
        if (distance < 80 && distance > 70)
        {
            Destroy(one);
        }
        if (distance < 70 && distance > 60)
        {
            Destroy(one);
            Debug.Log("2分物体消失");
        }
        if (distance < 60 && distance > 30)
        {
            Destroy(one);
            Debug.Log("3分物体消失");
        }
        if (distance < 30 && distance > 0)
        {
            Destroy(one);
            Debug.Log("5分物体消失");
        }
    }


    public void PointButtonone()
    {
        //判断掉落路径上是否有物品
        if (listone != null)
        {
            foreach (var item in listone)
            {
                if (item != null)

                {
                    Debug.Log(item.name);
                    Far(item,BtnOne.gameObject);
                }
                else
                {
                    Debug.Log("sss");
                }
            }
        }
        else
        {
            Debug.Log("没有物品掉落");
        }
    }
    public void PointButtontwo()
    {
        //判断掉落路径上是否有物品
        if (listtwo != null)
        {
            foreach (var item in listtwo)
            {
                if (item != null)

                {
                    Far(item, BtnTwo.gameObject);
                    Debug.Log(item.name);
                }
                else
                {
                    Debug.Log("sss");
                }
            }
        }
        else
        {
            Debug.Log("没有物品掉落");
        }
    }

    public void PointButtonthree()
    {
        //判断掉落路径上是否有物品
        if (listthree != null)
        {
            foreach (var item in listthree)
            {
                if (item != null)
                {
                    Far(item, BtnThree.gameObject);
                    Debug.Log(item.name);
                }
                else
                {
                    Debug.Log("sss");
                }
            }
        }
        else
        {
            Debug.Log("没有物品掉落");
        }
    }

    public void PointButtonfour()
    {
        //判断掉落路径上是否有物品
        if (listfour != null)
        {
            foreach (var item in listfour)
            {
                if (item != null)

                {
                    Far(item, BtnFour.gameObject);
                    Debug.Log(item.name);
                }
                else
                {
                    Debug.Log("sss");
                }
            }
        }
        else
        {
            Debug.Log("没有物品掉落");
        }
    }


    /// <summary>
    /// 背景移动
    /// </summary>
    private void Timer()//背景场地移动
    {

        //float f = Mathf.Repeat(speed * Time.time, 1920);
        //beijing.transform.position = a - Vector3.right * f;
        //beiingone.transform.position = b - Vector3.right * f;

        ////方法2：
        timer += Time.deltaTime;//每帧的增加时间
                                //背景位移
        beijing.transform.position -= Vector3.right * speed * Time.deltaTime;
        beiingone.transform.position -= Vector3.right * speed * Time.deltaTime;
        if (timer > 34.16)
        {
            beijing.transform.position = b;
            timer = 0;
        }
    }

}
