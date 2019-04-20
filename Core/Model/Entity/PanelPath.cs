using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPath {
    public string name;
    public string path;
    public override string ToString()
    {
        return string.Format("name:{0}", "path:{1}", name, path);
    }
}
