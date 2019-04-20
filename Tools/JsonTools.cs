using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class JsonTools{
    /// <summary>
    /// 读取PanelPath的Json并使用键值对存储
    /// </summary>
    public static Dictionary<string,string> ReadPanelPath(string path)
    {
        StreamReader streamreader = new StreamReader(path);
        JsonReader js = new JsonReader(streamreader);
        List<PanelPath> list = JsonMapper.ToObject <List<PanelPath>>(js);
        Dictionary<string, string> tempDic = new Dictionary<string, string>();

        foreach(var item in list)
        {
            if (tempDic.ContainsKey(item.name))
            {
                Debug.LogError("Json中存在重复数据，请检查");
                return null;
            }
            tempDic.Add(item.name, item.path);
        }
        return tempDic;
    }
    

}
