using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameui : MonoBehaviour
{


    /// <summary>
    /// 分数 当前血量和最高最低血量
    /// </summary>
    public float Point;
    public float Blone;
    public float MaxBlond =100f;
    public float MixBlond = 0f;
    public Text pointText;
    /// <summary>
    /// player
    /// </summary>
    public GameObject qingwa;
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
    #region 可优化
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;

    public Button BtnOne;
    public Button BtnTwo;
    public Button BtnThree;
    public Button BtnFour;

    public AudioClip rightone;
    public AudioClip righttwo;
    public AudioClip rightthree;
    public AudioClip rightfour;
    public AudioClip errone;
    public AudioClip errtwo;
    public AudioClip errthree;
    public AudioClip errfour;
    #endregion
    private void Start()
    {
        a = beijing.transform.position;//锁定背景原来的位置
        b = beiingone.transform.position;
        Fanhui.onClick.AddListener(FanhuiBtnLogic);
        BtnOne.onClick.AddListener(PointButtonone);
        BtnTwo.onClick.AddListener(PointButtontwo);
        BtnThree.onClick.AddListener(PointButtonthree);
        BtnFour.onClick.AddListener(PointButtonfour);
        anil = qingwa.transform.GetComponent<Animator>();
        anil.Play("idle");
        Point = 0f;
    }
    
    private void Update()
    {
        Diaoluo();
        Timer();
        pointText.text = "我是ZBR" + Point;
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
    public void Far(GameObject one, GameObject two,int number)
    {
        float distance = (one.transform.position - two.transform.position).magnitude;
        if (distance > 80)
        {
            AudioPlay(1, number);
            Point -= 100f;
        }
        if (distance < 80 && distance > 70)
        {
            Destroy(one);
            AudioPlay(0, number);
            Point += 100f;
        }
        if (distance < 70 && distance > 60)
        {
            Destroy(one);
            AudioPlay(0, number);
            Point += 150f;
        }
        if (distance < 60 && distance > 30)
        {
            Destroy(one);
            AudioPlay(0, number);
            Point += 200f;
        }
        if (distance < 30 && distance > 0)
        {
            Destroy(one);
            AudioPlay(0, number);
            Point += 300f;
        }
        switch (number)
        {
            case 1:
                listone.Clear();
                break;
            case 2:
                listtwo.Clear();
                break;
            case 3:
                listthree.Clear();
                break;
            case 4:
                listfour.Clear();
                break;
        }
    }

    private Animator anil;
    public void PointButtonone()
    {
        anil.Play("1");
        //判断掉落路径上是否有物品
        if (listone != null)
        {
            foreach (var item in listone)
            {
                if (item != null)

                {
                    Debug.Log(item.name);
                    Far(item,BtnOne.gameObject,1);
                }
                else
                {
                    AudioPlay(1,1);
                    Point -= 100f;
                }
            }
        }
        else
        {
            AudioPlay(1, 1);
            Point -= 100f;
        }
    }
    public void PointButtontwo()
    {
        anil.Play("2");
        //判断掉落路径上是否有物品
        if (listtwo != null)
        {
            foreach (var item in listtwo)
            {
                if (item != null)

                {
                    Far(item, BtnTwo.gameObject,2);
                    Debug.Log(item.name);
                }
                else
                {
                    AudioPlay(1, 2);
                    Point -= 100f;
                }
            }
        }
        else
        {
            AudioPlay(1, 2);
            Point -= 100f;
        }
    }

    public void PointButtonthree()
    {
        anil.Play("3");
        //判断掉落路径上是否有物品
        if (listthree != null)
        {
            foreach (var item in listthree)
            {
                if (item != null)
                {
                    Far(item, BtnThree.gameObject,3);
                    Debug.Log(item.name);
                }
                else
                {
                    AudioPlay(1, 3);
                    Point -= 100f;
                }
            }
        }
        else
        {
            AudioPlay(1, 3);
            Point -= 100f;
        }
    }

    public void PointButtonfour()
    {
        anil.Play("4");
        //判断掉落路径上是否有物品
        if (listfour != null)
        {
            foreach (var item in listfour)
            {
                if (item != null)

                {
                    Far(item, BtnFour.gameObject,4);
                    Debug.Log(item.name);
                }
                else
                {
                    AudioPlay(1, 4);
                    Point -= 100f;
                }
            }
        }
        else
        {
            AudioPlay(1, 4);
            Point -= 100f;
        }
    }


    /// <summary>
    /// 背景移动
    /// </summary>
    private void Timer()//背景场地移动
    {
        ////方法2：
        timer += Time.deltaTime;
        beijing.transform.position -= Vector3.right * speed * Time.deltaTime;
        beiingone.transform.position -= Vector3.right * speed * Time.deltaTime;
        if (timer > 34.16)
        {
            beijing.transform.position = b;
            timer = 0;
        }
    }



    /// <summary>
    /// 音频播放
    /// </summary>
    /// <param name="a">0正确 1 错误</param>
    /// <param name="b">是哪个btn</param>
    public void AudioPlay(int a ,int b)
    {

        Debug.Log(a+"}}}}}}}}"+b);
        if (a==0)
        {
            if (b==1)
            {
                this.GetComponent<AudioSource>().clip = rightone;
            }
            if (b == 2)
            {
                this.GetComponent<AudioSource>().clip = righttwo;
            }
            if (b == 3)
            {

                this.GetComponent<AudioSource>().clip = rightthree;
            }
            if (b == 4)
            {
                this.GetComponent<AudioSource>().clip = rightfour;
            }
        }
        if (a==1)
        {
            if (b == 1)
            {
                this.GetComponent<AudioSource>().clip = errone;
            }
            if (b == 2)
            {
                this.GetComponent<AudioSource>().clip = errtwo;
            }
            if (b == 3)
            {
                this.GetComponent<AudioSource>().clip = errthree;

            }
            if (b == 4)
            {
                this.GetComponent<AudioSource>().clip = errfour;
            }
        }
       
        this.GetComponent<AudioSource>().Play();
        
    }
}
