using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResLoadListener {
    //资源加载回调
    void Finish(object asset);

    void Failure();
}
