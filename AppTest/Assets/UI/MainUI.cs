using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    /// <summary>
    /// ��Ұ�ť
    /// </summary>
    public Button Gold;
    /// <summary>
    /// ��ʼ��ťi
    /// </summary>
    public Button Begin;
    /// <summary>
    /// ��һ������
    /// </summary>
    public GameObject NextPanel;
    /// <summary>
    /// ��ǰ����
    /// </summary>
    public GameObject ThisPanel;

    void Start()
    {
        Begin.onClick.AddListener(BeginBtnLogic);
    }

    void Update()
    {

    }
    /// <summary>
    /// ��ʼ��Ϸ ��ת����Ϸ����
    /// </summary>
    public void BeginBtnLogic()
    {
        NextPanel.gameObject.SetActive(true);
        ThisPanel.gameObject.SetActive(false);
    }
}
