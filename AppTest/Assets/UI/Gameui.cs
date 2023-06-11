using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameui : MonoBehaviour
{
    /// <summary>
    /// ���ذ�ť
    /// </summary>
    public Button Fanhui;
    /// <summary>
    /// ������
    /// </summary>
    public GameObject ShangyigePanel;
    /// <summary>
    /// ��ǰ����
    /// </summary>
    public GameObject ThisPanel;
    /// <summary>
    /// �ر�
    /// </summary>
    public GameObject clone;
    /// <summary>
    /// ����ͼ
    /// </summary>
    public Image beijing;
    public Image beiingone;
    /// <summary>
    /// λ�ü�¼
    /// </summary>
    private Vector3 a;
    private Vector3 b;
    /// <summary>
    /// �����
    /// </summary>
    public GameObject pointone;
    public GameObject pointtwo;
    public GameObject pointthree;
    public GameObject pointfour;
    /// <summary>
    /// //�����ƶ��ٶ�
    /// </summary>
    float speed = 100;
    /// <summary>
    /// //ʱ��
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
        a = beijing.transform.position;//��������ԭ����λ��
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
    /// ����������
    /// </summary>
    public void FanhuiBtnLogic()
    {
        ShangyigePanel.gameObject.SetActive(true);
        ThisPanel.gameObject.SetActive(false);
    }


    /// <summary>
    /// ��ʱ��
    /// </summary>
    public float time = 2f;

    /// <summary>
    /// �����ʱ
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
    /// ����ĸ������
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
    /// ���ֹ������ж��Ƿ�����
    /// </summary>
    /// <param name="one"></param>
    /// <param name="two"></param>
    public void Far(GameObject one, GameObject two)
    {
        float distance = (one.transform.position - two.transform.position).magnitude;
        if (distance > 80)
        {
            Debug.Log("0�����岻����ʧ");
        }
        if (distance < 80 && distance > 70)
        {
            Destroy(one);
        }
        if (distance < 70 && distance > 60)
        {
            Destroy(one);
            Debug.Log("2��������ʧ");
        }
        if (distance < 60 && distance > 30)
        {
            Destroy(one);
            Debug.Log("3��������ʧ");
        }
        if (distance < 30 && distance > 0)
        {
            Destroy(one);
            Debug.Log("5��������ʧ");
        }
    }


    public void PointButtonone()
    {
        //�жϵ���·�����Ƿ�����Ʒ
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
            Debug.Log("û����Ʒ����");
        }
    }
    public void PointButtontwo()
    {
        //�жϵ���·�����Ƿ�����Ʒ
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
            Debug.Log("û����Ʒ����");
        }
    }

    public void PointButtonthree()
    {
        //�жϵ���·�����Ƿ�����Ʒ
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
            Debug.Log("û����Ʒ����");
        }
    }

    public void PointButtonfour()
    {
        //�жϵ���·�����Ƿ�����Ʒ
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
            Debug.Log("û����Ʒ����");
        }
    }


    /// <summary>
    /// �����ƶ�
    /// </summary>
    private void Timer()//���������ƶ�
    {

        //float f = Mathf.Repeat(speed * Time.time, 1920);
        //beijing.transform.position = a - Vector3.right * f;
        //beiingone.transform.position = b - Vector3.right * f;

        ////����2��
        timer += Time.deltaTime;//ÿ֡������ʱ��
                                //����λ��
        beijing.transform.position -= Vector3.right * speed * Time.deltaTime;
        beiingone.transform.position -= Vector3.right * speed * Time.deltaTime;
        if (timer > 34.16)
        {
            beijing.transform.position = b;
            timer = 0;
        }
    }

}
