using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Inspector")]
    //[SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI systemText;

    private void Awake()
    {
        Instance = this;
        isDontDestroyed = true;
    }
    //public void SetHpText(int value)
    //{
    //    hpText.text = value.ToString();
    //}

    public void SetSystemMessage(string msg)
    {
        if(string.IsNullOrEmpty(msg))
        {
            systemText.gameObject.SetActive(false);
            return;
        }
        systemText.gameObject.SetActive(true);
        systemText.text = msg;
    }

}
