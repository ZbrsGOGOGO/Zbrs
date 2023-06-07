using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    /// <summary>
    /// 金币按钮
    /// </summary>
    public Button Gold;
    /// <summary>
    /// 开始按钮i
    /// </summary>
    public Button Begin;
    /// <summary>
    /// 下一个界面
    /// </summary>
    public GameObject NextPanel;
    /// <summary>
    /// 当前界面
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
    /// 开始游戏 跳转到游戏界面
    /// </summary>
    public void BeginBtnLogic()
    {
        NextPanel.gameObject.SetActive(true);
        ThisPanel.gameObject.SetActive(false);
    }
}
