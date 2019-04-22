using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    Dictionary<string, GameObject> openUIs = new Dictionary<string, GameObject>();
    Dictionary<string, string> panelPathDic = null;
    Transform uiParent = null;
    Transform downCanvas = null;
    Transform middleCanvas = null;
    Transform upCanvas = null;

    //UI节点
    Transform UIParent
    {
        get
        {
            if (uiParent == null)
            {
                GameObject go = GameObject.Find("UIRoot");
                uiParent = go.transform;
            }
            return uiParent;
        }
    }

    //缓存三个画布
    Transform DownCanvas
    {
        get
        {
            if (downCanvas == null)
            {
                GameObject go = GameObject.FindWithTag("DownCanvas");
                downCanvas = go.transform;
            }
            return downCanvas;
        }
    }

    Transform MiddleCanvas
    {
        get
        {
            if (middleCanvas == null)
            {
                GameObject go = GameObject.FindWithTag("MiddleCanvas");
                middleCanvas = go.transform;
            }
            return middleCanvas;
        }
    }

    Transform UpCanvas
    {
        get
        {
            if (downCanvas == null)
            {
                GameObject go = GameObject.FindWithTag("DownCanvas");
                downCanvas = go.transform;
            }
            return downCanvas;
        }
    }

    private void Awake()
    {
        panelPathDic = JsonTools.ReadPanelPath(Application.dataPath + "/PanelPath.json");
    }

    /// <summary>
    /// 打开UI
    /// </summary>
    /// <param name="panelName"></param>
    public void CreateUI<T>()where T:View
    {
        if (openUIs.ContainsKey(typeof(T).Name))
            return;

        GameObject go = GameObject.Instantiate(Resources.Load(panelPathDic[typeof(T).Name])) as GameObject;

        if (!go)
            Debug.LogError("UIManager : Cant find " + typeof(T).Name);

        go.transform.SetParent(MiddleCanvas,false);//暂时使用直接放在中层的方式
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        openUIs[typeof(T).Name] = go;
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    /// <param name="panelName"></param>
    public void CloseUI<T>()
    {
        if (!openUIs.ContainsKey(typeof(T).Name))
            return;
        Destroy(openUIs[typeof(T).Name]);
        openUIs.Remove(typeof(T).Name);
    }
}
