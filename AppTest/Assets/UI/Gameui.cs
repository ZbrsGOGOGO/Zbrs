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
        BtnOne.onClick.AddListener(PointButton);
        BtnTwo.onClick.AddListener(PointButton);
        BtnThree.onClick.AddListener(PointButton);
        BtnFour.onClick.AddListener(PointButton);
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



    public float aa;
    public float bb;
    public float cc;
    public float dd;
    

    /// <summary>
    /// ����ĸ������
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
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = one;
            Sphere.GetComponent<Clone>().id = 1;
            float distance = (Sphere.transform.position - BtnOne.transform.position).magnitude;
            Debug.Log("1"+ distance);
        }
        if (a == 2)
        {
            Sphere.transform.position = pointtwo.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = two;
            Sphere.GetComponent<Clone>().id = 2;
            float distance = (Sphere.transform.position - BtnTwo.transform.position).magnitude;
            Debug.Log("2" + distance);
        }
        if (a == 3)
        {
            Sphere.transform.position = pointthree.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = three;
            Sphere.GetComponent<Clone>().id = 3;
            float distance = (Sphere.transform.position - BtnThree.transform.position).magnitude;
            Debug.Log("3" + distance);
        }
        if (a == 4)
        {
            Sphere.transform.position = pointfour.transform.position;
            Sphere.transform.GetChild(0).transform.GetComponent<Image>().sprite = four;
            Sphere.GetComponent<Clone>().id = 4;
            float distance = (Sphere.transform.position - BtnFour.transform.position).magnitude;
            Debug.Log("4" + distance);
        }
    }


    /// <summary>
    /// ���ֹ������ж��Ƿ�����
    /// </summary>
    /// <param name="one"></param>
    /// <param name="two"></param>
    public void  Far(GameObject one ,GameObject two)
    {
       float distance = (one.transform.position - two.transform.position).magnitude;
        if (distance>3)
        {
            Debug.Log("0�����岻����ʧ");
        }
        if (distance<3||distance>2)
        {
            Debug.Log("1��������ʧ");
        }
        if (distance < 2 || distance > 1)
        {
            Debug.Log("2��������ʧ");
        }
        if (distance < 1 || distance > 0.5)
        {
            Debug.Log("3��������ʧ");
        }
        if (distance < 0.5 || distance > 0)
        {
            Debug.Log("5��������ʧ");
        }
    }


    public void PointButton()
    {
        if (true)
        {

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
