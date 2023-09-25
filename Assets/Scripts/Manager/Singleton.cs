using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 상속 받은 후에 Awake에 아래 구문 필요
    // private void Awake()
    // {
    //     Instance = this;
    //     isDontDestroyed = true;
    // }

    private static T instance;
    public static T Instance
    {
        get { return instance; }
        set 
        {
            if(instance != null)
            {
                Destroy(value.gameObject);
                return;
            }
            instance = value;
            if(isDontDestroyed)
                DontDestroyOnLoad(value.gameObject);
        }
    }

    protected static bool isDontDestroyed = true;


    public static bool Exist()
    {
        if(instance == null)
            return false;
        return true;
    }
}
