using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMB<T> : MonoBehaviour where T:SingletonMB<T>
{
    static T instance;

    public bool isPersistent;

    private void Awake()
    {
        if(!instance)
        {
            instance = (T) this;
            if (isPersistent)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (!ReferenceEquals(instance, this))
                Destroy(gameObject);
        }
    }

    public static T GetInstance()
    {
        if(!instance)
        {
            instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
            if (instance.isPersistent)
                DontDestroyOnLoad(instance.gameObject);
        }
        return instance;
    }

}
