using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ��� ���� �Ŀ� Awake�� �Ʒ� ���� �ʿ�
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
