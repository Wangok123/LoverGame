using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _intance;

    public static T Instance
    {
        get
        {
            if (_intance == null)
            {
                _intance = GameObject.FindObjectOfType<T>();
                if (_intance == null)
                {
                    GameObject go = new GameObject();
                    go.AddComponent<T>();
                    go.name = "["+typeof(T).Name+"]";
                    _intance = go.GetComponent<T>();
                }
            }
            return _intance;
        }
    }




}