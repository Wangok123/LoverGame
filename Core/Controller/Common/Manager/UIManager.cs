using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

    Dictionary<View, GameObject> openUIs = new Dictionary<View, GameObject>();
    Dictionary<string, string> panelPathDic = JsonTools.ReadPanelPath(Application.dataPath + "/PanelPath.json");
    Transform uiParent = null;

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

    /// <summary>
    /// 打开UI
    /// </summary>
    /// <param name="panelName"></param>
    public void CreateUI(View panelName)
    {
        if (openUIs.ContainsKey(panelName))
            return;

        GameObject go = GameObject.Instantiate(Resources.Load(panelName.name)) as GameObject;

        if (!go)
            Debug.LogError("UIManager : Cant find " + panelName.name);

        go.transform.SetParent(UIParent);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        openUIs[panelName] = go;
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    /// <param name="panelName"></param>
    public void CloseUI(View panelName)
    {
        if (!openUIs.ContainsKey(panelName))
            return;
        Destroy(openUIs[panelName]);
        openUIs.Remove(panelName);
    }
}
