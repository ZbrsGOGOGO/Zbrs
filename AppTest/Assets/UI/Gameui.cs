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

    /// <summary>
    /// λ�ü�¼
    /// </summary>
    private Vector3 a;
    void Start()
    {

        a = beijing.transform.position;//��������ԭ����λ��
        Fanhui.onClick.AddListener(FanhuiBtnLogic);
    }

    // Update is called once per frame
    void Update()
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
    /// �����
    /// </summary>
    public GameObject pointone;
    public GameObject pointtwo;
    public GameObject pointthree;
    public GameObject pointfour;

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
    /// ����ж��Ƿ�����
    /// </summary>
    public void Dianji()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    public void Point()
    {

    }

    /// <summary>
    /// //�����ƶ��ٶ�
    /// </summary>
    float speed = 200;
    /// <summary>
    /// //ʱ��
    /// </summary>
    float timer = 0;

    /// <summary>
    /// �����ƶ�
    /// </summary>
    private void Timer()//���������ƶ�
    {
        /*����1���ظ������ĵ��ã�ʹ�����ظ��ƶ���30Ϊ������ĳ���
		float f = Mathf.Repeat(speed * Time.time, 30);
		transform.position = a + Vector3.back * f;
		*/
        //����2��
        timer += Time.deltaTime;//ÿ֡������ʱ��
                                //����λ��
        beijing.transform.position -= Vector3.right * speed * Time.deltaTime;
        if (timer > 11)
        {
            beijing.transform.position = a;
            timer = 0;
        }
    }

}
